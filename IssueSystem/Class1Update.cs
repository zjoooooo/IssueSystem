using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.OleDb;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;


namespace IssueSystem
{
    public partial class Class1Update : Form
    {
        Dictionary<string, string> CarParkList = new Dictionary<string, string>();
        Dictionary<string, string> CarParkList2 = new Dictionary<string, string>();
        private List<string> x = new List<string>();
        private List<string> y = new List<string>();
        private List<string> w = new List<string>();
        private List<string> z = new List<string>();
        Thread thr;
        Main main;
        public Class1Update(Main main)
        {
            InitializeComponent();
            this.main = main;
   
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Class1 Update Program";
            toolStripStatusLabel2.Text = "Designed By Justin Zhang";
            label4.Text = "";
            label5.Text = "";
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            string commandtext = "select * from carpark.dbo.HDB";
            DataSet ds = SqlHelper.ExecuteDataset(main.constr, CommandType.Text, commandtext);        
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                CarParkList.Add(dr[0].ToString(),dr[1].ToString());
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            openFileDialog1.FileName = "";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string DBString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + this.openFileDialog1.FileName + ";Extended Properties=Excel 12.0";
                OleDbConnection con = new OleDbConnection(DBString);
                con.Open();
                DataTable datatable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //获取表单的名字
                String sheet = datatable.Rows[0][2].ToString().Trim();
                // string sheet = "Sheet1";
                OleDbDataAdapter ole = new OleDbDataAdapter("select * from [" + sheet + "]", con);
                DataSet ds = new DataSet();
                ole.Fill(ds);
                con.Close();
                foreach (DataRow col in ds.Tables[0].Rows)
                {
                    //    MessageBox.Show(col[0].ToString());
                    x.Add(col[1].ToString());   //vehicle
                    y.Add(col[2].ToString());   //iu
                    w.Add(col[3].ToString());  //expired date
                    z.Add(col[4].ToString());  //type
                }
            }
        }
          
        private string method(string iu_no, string vehicle_no, string expired_date, string casetype)
        {
            if (casetype == "NEW")
                return @"declare @x INT
                                   select @x = (select count(*) from season_mst)
                                   declare @y INT
                                   select @y = (select count(*) from season_mst)
                                   If EXISTS(SELECT * FROM [dbo].[season_mst] where season_no='" + iu_no + @"')
                                   begin 
                                   if(SELECT holder_type FROM [dbo].[season_mst] where season_no='" + iu_no + @"')=11
                                   BEGIN
                                   update season_mst set s_status=1,date_to='" + expired_date + @"',vehicle_no='" + vehicle_no + @"',holder_type=11,update_dt=GETDATE() where season_no='" + iu_no + @"'
                                   INSERT INTO [dbo].[season_mst_his](multi_season,rate_type,operator,season_id,season_type,s_status,holder_type,season_no,date_from,date_to,vehicle_no,add_dt,update_dt)
                                   VALUES
                                   (1,7,'LSync',@y+1,2,1,11,'" + iu_no + @"',convert(char(10),GetDate(),120),'" + expired_date + @"','" + vehicle_no + @"',GETDATE(),GETDATE())
                                   END
                                   else
                                   BEGIN
                                   if(SELECT s_status FROM [dbo].[season_mst] where season_no='" + iu_no + @"')!=1
                                       BEGIN  
                                   update season_mst set s_status=1,date_to='" + expired_date + @"',vehicle_no='" + vehicle_no + @"',holder_type=11,update_dt=GETDATE() where season_no='" + iu_no + @"'
                                   INSERT INTO [dbo].[season_mst_his](multi_season,rate_type,operator,season_id,season_type,s_status,holder_type,season_no,date_from,date_to,vehicle_no,add_dt,update_dt)
                                   VALUES
                                    (1,7,'LSync',@y+1,2,1,11,'" + iu_no + @"',convert(char(10),GetDate(),120),'" + expired_date + @"','" + vehicle_no + @"',GETDATE(),GETDATE())
                                       END 
                                     else
                                     BEGIN
                                     SET IDENTITY_INSERT season_mst_future ON
                                     INSERT INTO [dbo].[season_mst_future](multi_season,rate_type,operator,season_id,season_type,s_status,holder_type,season_no,date_from,date_to,vehicle_no,add_dt,update_dt,zone_id,sub_zone_id)
                                     VALUES
                                     (1,7,'LSync',@y+1,2,1,11,'" + iu_no + @"',convert(char(10),GetDate(),120),'" + expired_date + @"','" + vehicle_no + @"',GETDATE(),GETDATE(),'0','0')
                                     SET IDENTITY_INSERT season_mst_future OFF
                                     END                                     
                                   END
                                   end
                                   else 
                                   BEGIN
                                   INSERT INTO [dbo].[season_mst](multi_season,rate_type,operator,season_id,season_type,s_status,holder_type,season_no,date_from,date_to,vehicle_no,add_dt,update_dt)
                                   VALUES
                                   (1,7,'LSync',@x+1,2,1,11,'" + iu_no + @"',convert(char(10),GetDate(),120),'" + expired_date + @"','" + vehicle_no + @"',GETDATE(),GETDATE())
                                   INSERT INTO [dbo].[season_mst_his](multi_season,rate_type,operator,season_id,season_type,s_status,holder_type,season_no,date_from,date_to,vehicle_no,add_dt,update_dt)
                                   VALUES
                                   (1,7,'LSync',@y+1,2,1,11,'" + iu_no + @"',convert(char(10),GetDate(),120),'" + expired_date + @"','" + vehicle_no + @"',GETDATE(),GETDATE())
                                   end";
            else if (casetype == "DELETE")

                return @"If EXISTS(SELECT * FROM [dbo].[season_mst] where season_no='" + iu_no + @"')
                            Begin
                            delete from season_mst where season_no='" + iu_no + @"' and holder_type=11
                            End";
            else if (casetype == "CHANGEIU")

                return @"declare @x INT
                                    select @x = (select count(*) from season_mst)
                                    declare @y INT
                                    select @y = (select count(*) from season_mst_his)
                                    If EXISTS(SELECT * FROM [dbo].[season_mst] where vehicle_no='" + vehicle_no + @"')
                                        begin
                                          if EXISTS(SELECT * FROM [dbo].[season_mst] where vehicle_no='" + vehicle_no + @"' and holder_type=11)
                                              begin
                                               if not EXISTS(SELECT season_no FROM [dbo].[season_mst] where season_no='" + iu_no + @"')     
                                                 begin
                                                    update season_mst set s_status=1,date_to='" + expired_date + @"',season_no='" + iu_no + @"',holder_type=11,update_dt=GETDATE() where vehicle_no='" + vehicle_no + @"' and holder_type=11;
                                                    INSERT INTO [dbo].[season_mst_his](multi_season,rate_type,operator,season_id,season_type,s_status,holder_type,season_no,date_from,date_to,vehicle_no,add_dt,update_dt)
                                                    VALUES
                                                    (1,7,'LSync',@y+1,2,1,11,'" + iu_no + @"',convert(char(10),GetDate(),120),'" + expired_date + @"','" + vehicle_no + @"',GETDATE(),GETDATE())
                                                  end
                                              end
                                        end
                                    else
                                        begin
                                           if not EXISTS(SELECT season_no FROM [dbo].[season_mst] where season_no='" + iu_no + @"')  
                                            begin
                                                INSERT INTO [dbo].[season_mst](multi_season,rate_type,operator,season_id,season_type,s_status,holder_type,season_no,date_from,date_to,vehicle_no,add_dt,update_dt)
                                                VALUES
                                                (1,7,'LSync',@x+1,2,1,11,'" + iu_no + @"',convert(char(10),GetDate(),120),'" + expired_date + @"','" + vehicle_no + @"',GETDATE(),GETDATE())
                                                INSERT INTO [dbo].[season_mst_his](multi_season,rate_type,operator,season_id,season_type,s_status,holder_type,season_no,date_from,date_to,vehicle_no,add_dt,update_dt)
                                                VALUES
                                                (1,7,'LSync',@y+1,2,1,11,'" + iu_no + @"',convert(char(10),GetDate(),120),'" + expired_date + @"','" + vehicle_no + @"',GETDATE(),GETDATE())
                                             end
                                        end";//change iu

            else return "is null,Transmit type incorrect";
        }

        public bool Ping(string ip)
        {
            try
            {
                if (!(ip == null))
                {

                    int timeout = 2500;
                    string data = "Test Data!";
                    Ping p = new Ping();
                    PingOptions options = new PingOptions();
                    options.DontFragment = true; byte[] buffer = Encoding.ASCII.GetBytes(data);
                    PingReply reply = p.Send(ip, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success) return true;return false;
                }
               return false;
            }
            catch (PingException)
            { MessageBox.Show("No Ping Reply From" + ip); return false;}

        }


        private void button2_Click(object sender, EventArgs e)
        {
            thr = new Thread(new ThreadStart(update));
            thr.Start();
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (thr.IsAlive)
            {
                thr.Abort();
            }
        }

        private void update()
        {
            if (!(Directory.Exists(Application.StartupPath + "/log/Class1 Update")))
                Directory.CreateDirectory(Application.StartupPath + "/log/Class1 Update");
            StreamWriter sw = new StreamWriter(Application.StartupPath + "/log/Class1 Update/" + DateTime.Now.ToString("MMdd") + ".log", true);
            sw.WriteLine("-----------------------------------------------------------");
            sw.WriteLine(DateTime.Now.ToString());
            label4.Text = "";
            // Display the ProgressBar control.
            pBar1.Visible = true;

            // Set Minimum to 1 to represent the first file being copied.
            pBar1.Minimum = 1;

            // Set Maximum to the total number of files to copy.
            pBar1.Maximum = CarParkList.Count;

            // Set the initial value of the ProgressBar.
            pBar1.Value = 1;

            // Set the Step property to a value of 1 to represent each file being copied.
            pBar1.Step = 1;
          //  CarParkList2.Add("C10","192.168.188.4");
          //  CarParkList2.Add("U30","192.168.162.4");
          //  CarParkList2.Add("U31","192.168.162.5");
            int fcc = 0;
            int fcp = 0;
            foreach (KeyValuePair<string, string> kv in CarParkList)
            {
                fcc = 0;
                sw.WriteLine("-----------------------------------------------------------");
                toolStripStatusLabel1.Text = kv.Key;
                if (!(Ping(kv.Value)))
                { sw.WriteLine(DateTime.Now.ToString("hh:mm:ss ") + kv.Key + " No Ping Rely"); fcp++; continue; }
                else
                    sw.WriteLine(DateTime.Now.ToString("hh:mm:ss ") + kv.Key + " Conected");
                Application.DoEvents();
                string connectString1 = "Data Source=" + kv.Value + ";uid=sa;pwd=yzhh2007;database=" + kv.Key + ";Connection Timeout=15";
                SqlConnection sqlcn = null;
                SqlCommand cmd = null;
                pBar2.Visible = true;
                pBar2.Minimum = 1;
                pBar2.Value = 1;
                pBar2.Step = 1;
                pBar2.Maximum = x.Count;
                sw.WriteLine(DateTime.Now.ToString("hh:mm:ss ") + kv.Key + " Starting Update:");
                sqlcn = new SqlConnection(connectString1);
                sqlcn.Open();
                cmd = new SqlCommand();
                for (int i = 0; i < x.Count; i++)
                {


                    string IU = (string)y[i];
                    string VEH = (string)z[i];
                    string date = (string)w[i];
                    string type = (string)z[i];
                    try
                    {





                        cmd.CommandText = method((string)y[i], (string)x[i], (string)w[i], (string)z[i]);
                      //  sw.WriteLine(cmd.CommandText);
                        cmd.Connection = sqlcn;

                        int count = cmd.ExecuteNonQuery();
                      //  if (count >= 1)
                     
                      //  else
                      //  { sw.WriteLine(DateTime.Now.ToString("hh:mm:ss ") + IU + " Insert Fail！"); fcc++; }
                        Application.DoEvents();
                        { sw.WriteLine(DateTime.Now.ToString("hh:mm:ss ") + IU + " Insert Success！"); }
                        label4.Text = "Processing:" + pBar2.Value + " Data / Total:" + x.Count + " Data / Fail: " + fcc + " Data";
                        pBar2.PerformStep();

                    }
                    catch (SqlException)
                    { sw.WriteLine(DateTime.Now.ToString("hh:mm:ss ") + IU + " Command Insert fail"); fcc++; }
                    finally
                    {
                      
                    }
                    Application.DoEvents();

                }
                if (cmd != null)
                    try
                    { cmd.Dispose(); }
                    catch (SqlException)
                    { sw.WriteLine(DateTime.Now.ToString("hh:mm:ss ") + "Can not Close SqlCmd Connection"); }
                if (sqlcn != null)
                    try
                    { sqlcn.Close(); }
                    catch (SqlException)
                    { sw.WriteLine(DateTime.Now.ToString("hh:mm:ss ") + "Can not Close Sql Connection"); }
                pBar1.PerformStep();
                label5.Text = "Processing : " + pBar1.Value + "  / Total : " + CarParkList.Count + " /Fail : " + fcp;
                sw.WriteLine(DateTime.Now.ToString("hh:mm:ss ") + kv.Key + " Finished!");
                sw.Flush();
            }


            label1.Text = "COMPLETE";

            sw.Close();
        
        }

       
             
  
 

    }       
           
}
    

