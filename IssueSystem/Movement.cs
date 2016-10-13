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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Reflection;
using System.Net.NetworkInformation;

namespace IssueSystem
{
    public partial class Movement : Form
    {
        Thread objThread = null;
        DataTable table = new DataTable();
        Dictionary<string, string> carparklist = new Dictionary<string, string>();
        Main main;
        delegate void Datagridadd(DataTable dt);
        delegate void Progressbar();
        delegate void Labeldisplay(string str);
        delegate void button2enable();
        public Movement(Main main)
        {
            InitializeComponent();
            this.main = main;
        }
        private void InitCarparkList()
        {
            carparklist.Clear();
            string constr = "Data Source=172.16.1.89;uid=secure;pwd=weishenme;database=carpark";
            string CommandText = @"select name,ip,batch from Whole where batch not in('IPD','commercial')";
         //   string CommandText = @"select name,ip,batch from Whole where name='KLM'";
            DataSet ds = null;


            try
            {
                ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, CommandText);
                foreach (DataRow ls in ds.Tables[0].Rows)
                {
                    carparklist.Add(ls[0].ToString(), ls[1].ToString());
                }

            }
            catch (SqlException e)
            {
                LogClass.WirteLogForMovement("Fail To Get Car Park List : " + e.ToString());
            }
            finally
            {
                try
                {
                    if (ds != null)
                        ds.Dispose();
                }
                catch (SqlException e)
                {
                    LogClass.WirteLogForMovement("Fail To Close Car Park List DataSet : " + e.ToString());
                }
            }
        }
        private void Datagrid(DataTable dt)
        {
            try
            {
                if (table != null)
                {
                    table.Merge(dt);
                    dataGridView1.DataSource = table;
                }
                
            }
            catch (Exception e)
            {
                LogClass.WirteLine("Merge data fail : "+e.ToString());
            }
           
        }
        private void Progressdefault()
        {
            pBar1.Visible = true;
            pBar1.Minimum = 0;
            pBar1.Maximum = carparklist.Count;
            pBar1.Value = 1;
            pBar1.Step = 1;
        }
        private void ProgressSetp()
        {
            if (pBar1.Value < carparklist.Count)
            {
                pBar1.Value++;
            }
        }
        public bool Ping(string ip)
        {
            try
            {
                if (!(ip == null))
                {

                    int timeout = 5000;
                    string data = "Test Data!";
                    Ping p = new Ping();
                    PingOptions options = new PingOptions();
                    options.DontFragment = true; byte[] buffer = Encoding.ASCII.GetBytes(data);
                    PingReply reply = p.Send(ip, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success) return true; return false;
                }
                return false;
            }
            catch (PingException)
            {
                LogClass.WirteLogForMovement("No Ping Reply From" + ip);
                return false;
            }

        }
        private void Button2Status()
        {
            button2.Enabled = true;
            button1.Text = "Start";
        }
        private void Labelupdate(string str)
        {
            label5.Text = "Car Park:" + str + ",Total:" + carparklist.Count;
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            //table.Columns.Add("Carpark", typeof(string));
            toolStripStatusLabel2.Text = "Designed By Justin Zhang";
            toolStripStatusLabel1.Text = "";
            label5.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InitCarparkList();
            if ((textBox1.Text == null) || (textBox1.Text == ""))
            {
                MessageBox.Show("No content found for IU/Cashcard");
                return;
            }
            if (button1.Text == "Start")
            {
                button2.Enabled = false;
                string IU = this.textBox1.Text.Trim();
                string picker1 = this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string picker2 = this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                table.Clear();
                objThread = new Thread(() => Search(IU, picker1, picker2));
                objThread.Start();
                button1.Text = "Stop";
            }
            else
            {
                if (objThread != null)
                {
                    if (objThread.IsAlive)
                    {
                        objThread.Abort();
                    }
                }
                button1.Text = "Start";
                button2.Enabled = true;
            }
        }
        private void Search(string IU, string start_time, string end_time)
        {

            Progressbar pbdefault = new Progressbar(Progressdefault);
            Progressbar pbstep = new Progressbar(ProgressSetp);
            Labeldisplay ld = new Labeldisplay(Labelupdate);
            button2enable b2e = new button2enable(Button2Status);
            this.Invoke(pbdefault);
            Datagridadd dd = new Datagridadd(Datagrid);
            string cmd = @"    SELECT iu_tk_no,Trans_type.Description as Trans_type,entry_station,entry_time,station_setup.station_name as exit_station,exit_time,parked_time,paid_amt,card_mc_no 
                               FROM [dbo].[movement_trans],dbo.station_setup,Trans_type 
                               WHERE Trans_type.Trans_type=movement_trans.trans_type 
                               AND station_setup.station_id=movement_trans.exit_station
							   AND movement_trans.update_dt BETWEEN @start_time and @end_time
                               AND (iu_tk_no=@IU
                               OR  card_mc_no=@IU);";
            SqlParameter[] para = new SqlParameter[]{

                new SqlParameter("@IU",IU),
                new SqlParameter("@start_time",start_time),
                new SqlParameter("@end_time",end_time)
            };

            LogClass.WirteLogForMovement("Start to search iu or cash card : " + IU);

            foreach (KeyValuePair<string, string> kv in carparklist)
            {
                this.Invoke(pbstep);
                this.Invoke(ld, kv.Key);
                LogClass.WirteLogForMovement("------------------------");
                //if (!Ping(kv.Value))
                //{
                //    LogClass.WirteLogForMovement(kv.Key + " can't reply from ping command after 5 seconds waiting.");
                //    continue;
                //}
                //LogClass.WirteLogForMovement(kv.Key + " ping ok.");
                string connectString = "Data Source=" + kv.Value + ";uid=sa;pwd=yzhh2007;database=" + kv.Key;
                DataSet ds = null;
                try
                {
                    ds = SqlHelper.ExecuteDataset(connectString, CommandType.Text, cmd, para);
                }
                catch (Exception sqle)
                {
                    LogClass.WirteLogForMovement("Car park " + kv.Key + " error on read data : " + sqle.ToString());
                    continue;
                }

                try
                {
                    if (ds == null)
                    {
                        continue;
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        LogClass.WirteLogForMovement("Car park " + kv.Key + " found data. ");
                        ds.Tables[0].Columns.Add("Carpark", typeof(string));
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dr["Carpark"] = kv.Key;
                        }

                        // table.Merge(ds.Tables[0]);
                        this.Invoke(dd, ds.Tables[0]);
                        LogClass.WirteLogForMovement("Car park " + kv.Key + " merge data ok.");
                    }
                    else
                    {
                        LogClass.WirteLogForMovement("Car park " + kv.Key + " no data found. ");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    LogClass.WirteLogForMovement("Car park " + kv.Key + " error on merge data : " + e.ToString());
                    continue;
                }


            }
            this.Invoke(b2e);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            ExportExcel();
            button2.Enabled = true;
        }
        private void ExportExcel()
        {
            System.Diagnostics.Process[] arrProcesses;
            arrProcesses = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process myProcess in arrProcesses)
            {
                myProcess.Kill();
            }//Kill 
            saveFileDialog1.Filter = "Execl files (*.xlsx)|*.xlsx";

            saveFileDialog1.FilterIndex = 0;

            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.CreatePrompt = true;

            saveFileDialog1.Title = "Export Excel File To";
            saveFileDialog1.CheckFileExists = false;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //    saveFileDialog1.ShowDialog();
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                Excel.Worksheet worksheet = workbook.ActiveSheet as Excel.Worksheet;

                Microsoft.Office.Interop.Excel.Range format = worksheet.get_Range("A1", "J200");//Set Format For Data  
                format.NumberFormatLocal = "@";


                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText.ToString();
                }
                //填充数据  
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)         //循环行  
                {

                    for (int j = 0; j < dataGridView1.ColumnCount; j++)      //循环列  
                    {
                        //if (dataGridView1[j, i].ValueType == typeof(string)) //判断DataGirdView中数据的类型  
                        //{
                        //    excel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();
                        //}
                        //else if (dataGridView1[j, i].ValueType == typeof(DateTime))
                        //{

                        //    excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                        //} 
                        excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value;


                    }
                }

                string strName = saveFileDialog1.FileName;
                excel.DisplayAlerts = false;
                //workbook.SaveAs(strName, Excel.XlFileFormat.xlExcel5, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                //    Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                workbook.SaveAs(strName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);

                //workbook.Save();
                workbook.Close(true, Type.Missing, Type.Missing);
                //  workbook.Close();            
                workbook = null;
                worksheet = null;
                excel.Quit();
                excel = null;

                GC.Collect();
            }
        }
    }
}
