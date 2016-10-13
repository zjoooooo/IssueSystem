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
using System.Runtime.InteropServices;
using System.Threading;

namespace IssueSystem
{
    public partial class Modify : Form
    {
        // StreamWriter sw = null;
        DataSet ds = null;
        DataTable name = null;
        DataTable IssueName = null;
        DataTable Priority = null;
        DataTable StaffName1 = null;
        DataTable StaffName2 = null;
        DataTable StaffName3 = null;
        DataTable StaffName4 = null;
        DataTable Current = null;
        Main fr2;
        string id;
        Modify previous = null;
        private string tag = "modifyissue";
        public Modify(Main fr2, string id)
        {
            InitializeComponent();
            this.fr2 = fr2;
            this.id = id;
        }
        #region 窗体边框阴影效果变量申明

        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        //为边框阴影声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        #endregion

        #region  //点击taskbar最小化窗口
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        #endregion

        #region //自画无边框
        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                    (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201: //鼠标左键按下的消息
                    m.Msg = 0x00A1; //更改消息为非客户区按下鼠标
                    m.LParam = IntPtr.Zero; //默认值
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
        private void Form3_Load(object sender, EventArgs e)
        {
            //sw = new StreamWriter(Application.StartupPath + "\\log\\" + DateTime.Now.ToString("MMdd") + ".log", true);

            string status = comboBox1.Text.Trim();
            int l = fr2.level;

            if (l == 2)
            {
                Save.Enabled = false;
                comboBox1.Enabled = false;
                CarparkList.Enabled = false;
                IssueList.Enabled = false;
                PriorityList.Enabled = false;
                StaffList.Enabled = false;
                ReportTimePicker.Enabled = false;
                //  MessageBox.Show("这里是权限2");
            }
            else
            {
                //  MessageBox.Show("这里是权限0或1");
                this.Station.Enabled = false;
                this.IssueList.Enabled = false;
                this.StaffList.Enabled = false;
                this.CarparkList.Enabled = false;
                this.ReportTimePicker.Enabled = false;
                if (status == "Closed")
                {
                    //     MessageBox.Show("这里是0或1 下的关闭状态");
                    this.PriorityList.Enabled = false;
                    this.StaffList2.Enabled = false;
                    this.StaffListAttend.Enabled = false;
                    this.AttendedTimePicker.Enabled = false;
                    this.DoneTimePicker.Enabled = false;
                    this.ActivatedTimePicker.Enabled = false;
                    this.richTextBox1.Enabled = false;
                    this.IssueList.Enabled = false;
                    this.Station.Enabled = false;
                    this.Cb_Bacth.Enabled = false;
                    this.Cb_BO.Enabled = false;
                    this.cb_follower.Enabled = false;
                }
            }


            label18.Text = "Case ID:"+id;

            string connectionstr = fr2.constr;
            string Command = @"select name from [carpark].[dbo].[Whole];                         
                                 select IssueName from [carpark].[dbo].[IssueType];
                                select priority from [carpark].[dbo].[PriorityType];
                               select staff from [carpark].[dbo].[StaffType];
                              select staff from [carpark].[dbo].[StaffType];
                             select staff from [carpark].[dbo].[StaffType];
                            select * from carpark.dbo.IssueTable where ID=@ID;
                            select staff from [carpark].[dbo].[StaffType];
                            select staff from [carpark].[dbo].[StaffType];
                            select staff from [carpark].[dbo].[StaffType];
                            ";
            try
            {
                ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, Command, new SqlParameter("@ID", id));    //execute
                name = ds.Tables[0];               //Carpark name list
                IssueName = ds.Tables[1];             //issue list
                Priority = ds.Tables[2];              //Priority list
                StaffName1 = ds.Tables[3];           //Staff Name
                StaffName2 = ds.Tables[4];           //Staff Name2
                StaffName3 = ds.Tables[5];
                StaffName4 = ds.Tables[9];
                Current = ds.Tables[6];
                CarparkList.DataSource = name;
                CarparkList.DisplayMember = "name";

                IssueList.DataSource = IssueName;
                IssueList.DisplayMember = "IssueName";

                PriorityList.DataSource = Priority;
                PriorityList.DisplayMember = "Priority";

                StaffList.DataSource = StaffName1;
                StaffList2.DataSource = StaffName2;
                StaffList.DisplayMember = "staff";
                StaffList2.DisplayMember = "staff";

                cb_follower.DataSource = StaffName4;
                cb_follower.DisplayMember = "staff";

                StaffListAttend.DataSource = StaffName3;
                StaffListAttend.DisplayMember = "staff";

                StaffListAttend2.DataSource = ds.Tables[7];
                StaffListAttend2.DisplayMember = "staff";
                StaffListAttend3.DataSource = ds.Tables[8];
                StaffListAttend3.DisplayMember = "staff";

                string ID = Current.Rows[0][0].ToString();
                string carpark = Current.Rows[0][1].ToString().Trim();
                string issue = Current.Rows[0][2].ToString();
                string Solution = Current.Rows[0][3].ToString();
                string reportby = Current.Rows[0][4].ToString();
                string AttendBy = Current.Rows[0][5].ToString().ToUpper();
                string DoneBy = Current.Rows[0][6].ToString();
                string ReportTime = ((DateTime)Current.Rows[0][7]).ToString("yyyy-MM-dd HH:mm:ss");
                string ActivatedTime = ((DateTime)Current.Rows[0][8]).ToString("yyyy-MM-dd HH:mm:ss");
                string AttendedTime = ((DateTime)Current.Rows[0][9]).ToString("yyyy-MM-dd HH:mm:ss");
                string DoneTime = ((DateTime)Current.Rows[0][10]).ToString("yyyy-MM-dd HH:mm:ss");
                string followup = Current.Rows[0][26].ToString().ToUpper();
                //    string RespondTime = DoneTime = Current.Rows[0][11].ToString();
                //    string DownTimeDoneTime = Current.Rows[0][12].ToString();
                string Status = Current.Rows[0][16].ToString();
                string Priority1 = Current.Rows[0][17].ToString();
                string Station1 = Current.Rows[0][18].ToString();
                string AttendBy2 = Current.Rows[0][19].ToString().ToUpper();
                string AttendBy3 = Current.Rows[0][20].ToString().ToUpper();
                string Batch = Current.Rows[0][21].ToString();
                string BO = Current.Rows[0][22].ToString();
                LogClass.WirteLine("ID=" + ID + ",carpark=" + carpark + ",issue=" + issue + ",Solution=" + Solution + ",reportby=" + reportby
                    + ",AttendBy=" + AttendBy + ",DoneBy=" + DoneBy + ",ReportTime=" + ReportTime + ",ActivatedTime=" + ActivatedTime + ",AttendedTime=" + AttendedTime
                    + ",DoneTime=" + DoneTime + ",followup=" + followup + ",Status=" + Status + ",Priority1=" + Priority1 + ",Station1=" + Station1 + ",AttendBy2=" + AttendBy2
                    + ",AttendBy3=" + AttendBy3 + ",Batch=" + Batch + ",BO=" + BO);

                for (int i = 0; i < StaffListAttend.Items.Count; i++)
                {
                    DataRowView dr = (DataRowView)StaffListAttend.Items[i];
                    if (dr["staff"].ToString().ToUpper() == AttendBy)
                    { StaffListAttend.SelectedIndex = i; break; }

                }

                for (int i = 0; i < cb_follower.Items.Count; i++)
                {
                    DataRowView dr = (DataRowView)cb_follower.Items[i];
                    if (dr["staff"].ToString().ToUpper() == followup)
                    {                     
                        cb_follower.SelectedIndex = i; 
                        break; 
                    }
                }



                for (int i = 0; i < StaffListAttend2.Items.Count; i++)
                {
                    DataRowView dr = (DataRowView)StaffListAttend2.Items[i];
                    if (dr["staff"].ToString().ToUpper() == AttendBy2)
                    { StaffListAttend2.SelectedIndex = i; break; }

                }
                for (int i = 0; i < StaffListAttend3.Items.Count; i++)
                {
                    DataRowView dr = (DataRowView)StaffListAttend3.Items[i];
                    if (dr["staff"].ToString().ToUpper() == AttendBy3)
                    { StaffListAttend3.SelectedIndex = i; break; }

                }



                for (int i = 0; i < CarparkList.Items.Count; i++)
                {
                    DataRowView dr = (DataRowView)CarparkList.Items[i];
                    if (dr["name"].ToString().Trim() == carpark)
                    { CarparkList.SelectedIndex = i; break; }


                }

                for (int i = 0; i < StaffList.Items.Count; i++)
                {
                    DataRowView dr = (DataRowView)StaffList.Items[i];
                    if (dr["staff"].ToString() == reportby)
                    { StaffList.SelectedIndex = i; break; }

                }

                for (int i = 0; i < IssueList.Items.Count; i++)
                {
                    DataRowView dr = (DataRowView)IssueList.Items[i];
                    if (dr["IssueName"].ToString() == issue)
                    { IssueList.SelectedIndex = i; break; }

                }

                for (int i = 0; i < Station.Items.Count; i++)
                {
                    if (Station.Items[i].ToString() == Station1)
                    {
                        Station.SelectedIndex = i; break;

                    }
                }

  

                for (int i = 0; i < Cb_Bacth.Items.Count; i++)
                {
                    if (Cb_Bacth.Items[i].ToString() == Batch)
                    {
                        Cb_Bacth.SelectedIndex = i; break;

                    }
                }

                for (int i = 0; i < Cb_BO.Items.Count; i++)
                {
                    if (Cb_BO.Items[i].ToString() == BO)
                    {
                        Cb_BO.SelectedIndex = i; break;

                    }
                }

                comboBox1.Text = Status;
                PriorityList.Text = Priority1;
                StaffList2.Text = DoneBy;
                StaffListAttend.Text = AttendBy;
                ReportTimePicker.Text = ReportTime;
                //    ReportTimePicker.Enabled = false;
                AttendedTimePicker.Text = AttendedTime;
                DoneTimePicker.Text = DoneTime;
                ActivatedTimePicker.Text = ActivatedTime;
                richTextBox1.Text = Solution;
                //sw.Flush();
                //   sw.Close();

            }
            catch (SqlException)
            {
                MessageBox.Show("Can't get data from db");
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            //sw = new StreamWriter(Application.StartupPath + "\\log\\" + DateTime.Now.ToString("MMdd") + ".log", true);
            string connectionstr = fr2.constr;
            int index = fr2.dataGridView1.CurrentRow.Index;
            string CommandText = @"Update [carpark].[dbo].[IssueTable] set carpark=@carpark,issue=@issue,Solution=@Solution,reportby=@reportby,
                                       AttendBy=@AttendBy,DoneBy=@DoneBy,ReportTime=@ReportTime,ActivatedTime=@ActivatedTime,
                                       AttendedTime=@AttendedTime,DoneTime=@DoneTime,RespondTime=@RespondTime,DownTime=@DownTime,
                                       LastModifyTime=convert(varchar(19),getdate(),120),LastModifyBy=@LastModifyBy,Status=@Status,Priority=@Priority,
                                       AttendBy2=@AttendBy2,AttendBy3=@AttendBy3,Station=@Station,Batch=@Batch,BO=@BO,AttendStatus=@AttendStatus,Follower=@Follower where ID=@ID;";
            TimeSpan t1 = new TimeSpan(DateTime.Parse(ActivatedTimePicker.Text).Ticks);
            TimeSpan t2 = new TimeSpan(DateTime.Parse(AttendedTimePicker.Text).Ticks);
            float RespondTime = (float)t2.Subtract(t1).TotalHours;
            TimeSpan t3 = new TimeSpan(DateTime.Parse(ReportTimePicker.Text).Ticks);
            TimeSpan t4 = new TimeSpan(DateTime.Parse(DoneTimePicker.Text).Ticks);
            float downtime = (float)t4.Subtract(t3).TotalHours;
            string attendestatus;
            if (StaffListAttend.Text.Trim() == "Null")
            {
                attendestatus = "0";
            }
            else
            {
                attendestatus = "1";
            }
            SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@carpark",CarparkList.Text.Trim()),
                    new SqlParameter("@issue",IssueList.Text.Trim()),
                    new SqlParameter("@Solution",richTextBox1.Text.Trim()),
                    new SqlParameter("@reportby",StaffList.Text.Trim()),
                    new SqlParameter("@AttendBy",StaffListAttend.Text.Trim()),
                    new SqlParameter("@DoneBy",StaffList2.Text.Trim()),
                    new SqlParameter("@ReportTime",ReportTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss")),      
                    new SqlParameter("@ActivatedTime",ActivatedTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@AttendedTime",AttendedTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@DoneTime",DoneTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@RespondTime",RespondTime.ToString("f2")),
                    new SqlParameter("@DownTime",downtime.ToString("f2")),
                 //   new SqlParameter("@LastModifyTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@LastModifyBy",fr2.loginuser),
                 //   new SqlParameter("@CreatedBy",fr2.loginuser),                 
                    new SqlParameter("@Status",comboBox1.Text),
                    new SqlParameter("@Priority",PriorityList.Text.Trim()),
                    new SqlParameter("@ID",id),
                    new SqlParameter("@Station",Station.Text),
                    new SqlParameter("@AttendBy2",StaffListAttend2.Text.Trim()),
                    new SqlParameter("@AttendBy3",StaffListAttend3.Text.Trim()),
                    new SqlParameter("@Batch",Cb_Bacth.Text.Trim()),
                    new SqlParameter("@AttendStatus",attendestatus),
                    new SqlParameter("@BO",Cb_BO.Text.Trim()),
                    new SqlParameter("@Follower",cb_follower.Text.Trim())
                };
            try
            {
                SqlHelper.ExecuteNonQuery(connectionstr, CommandType.Text, CommandText, parameter);
            }
            catch (SqlException)
            {
                //sw.WriteLine(DateTime.Now.ToString() + "   " + "Sql Command error can't add new content to Server");
            }
            //  sw.Flush();
            //  sw.Close();
            ds.Dispose();
            name.Dispose();
            IssueName.Dispose();
            StaffName1.Dispose();
            StaffName2.Dispose();
            StaffName3.Dispose();
            Current.Dispose();
            //  fr2.RefreshGrid();
            fr2.FirstFresh();
            this.Close();


        }

        private void Close1_Click(object sender, EventArgs e)
        {

            this.Close();

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Open")
            {
                PriorityList.Enabled = true;
                StaffList2.Enabled = true;
                StaffListAttend.Enabled = true;
                ReportTimePicker.Enabled = true;
                AttendedTimePicker.Enabled = true;
                DoneTimePicker.Enabled = true;
                ActivatedTimePicker.Enabled = true;
                richTextBox1.Enabled = true;
                Station.Enabled = true;
                this.Cb_Bacth.Enabled = true;
                this.Cb_BO.Enabled = true;
                this.cb_follower.Enabled = true;
            }
            else if (comboBox1.SelectedItem.ToString() == "Closed")
            {
                this.CarparkList.Enabled = false;
                this.PriorityList.Enabled = false;
                this.StaffList.Enabled = false;
                this.StaffList2.Enabled = false;
                this.StaffListAttend.Enabled = false;
                this.ReportTimePicker.Enabled = false;
                this.AttendedTimePicker.Enabled = false;
                this.DoneTimePicker.Enabled = false;
                this.ActivatedTimePicker.Enabled = false;
                this.richTextBox1.Enabled = false;
                this.IssueList.Enabled = false;
                this.Station.Enabled = false;
                this.StaffListAttend2.Enabled = false;
                this.StaffListAttend3.Enabled = false;
                this.Cb_Bacth.Enabled = false;
                this.Cb_BO.Enabled = false;
                this.cb_follower.Enabled = false;
            }
            else if (comboBox1.SelectedItem.ToString() == "Follow Up")
            {
                PriorityList.Enabled = true;
                StaffList2.Enabled = true;
                StaffListAttend.Enabled = true;
                ReportTimePicker.Enabled = true;
                AttendedTimePicker.Enabled = true;
                DoneTimePicker.Enabled = true;
                ActivatedTimePicker.Enabled = true;
                richTextBox1.Enabled = true;
                Station.Enabled = true;
                this.Cb_Bacth.Enabled = true;
                this.Cb_BO.Enabled = true;
                button2.Enabled = true;
                this.cb_follower.Enabled = true;
            }
        }


        private void Modify_FormClosed(object sender, FormClosedEventArgs e)
        {
            ds.Dispose();
            name.Dispose();
            IssueName.Dispose();
            StaffName1.Dispose();
            StaffName2.Dispose();
            StaffName3.Dispose();
            Current.Dispose();
            previous = null;
            //  sw.Flush();
            //sw.Close();
            //   Beautiful.AnimateWindow(this.Handle, 2000, Beautiful.AW_SLIDE | Beautiful.AW_HIDE | Beautiful.AW_BLEND);
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Modify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread thrsr = new Thread(() => ServiceReport());
            //thrsr.Start();
            ServiceReport();
        }

        private void ServiceReport(){
            string Command = @"select followby,item,qty,submitby,starttime,endtime,otstarttime,otendtime,posttime,solution from carpark.dbo.SRtable where linkid=@linkid";

            DataSet ds = null;
            try
            {
                ds = SqlHelper.ExecuteDataset(fr2.constr, CommandType.Text, Command, new SqlParameter("@linkid", id));    //execute
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("Can't get data from SRdb" + sqle.ToString());
                return;
            }
            try
            {
                   DataTable SR = ds.Tables[0];
                   if(SR.Rows.Count<=0)
                   {
                       MessageBox.Show("Nobody has submit service report for your case yet!!!");
                   }
                   else
                   {
                       ServiceReport sr = new ServiceReport();
                       sr.Followby = SR.Rows[0][0].ToString();
                       sr.Item = SR.Rows[0][1].ToString();
                       sr.Itemqty = SR.Rows[0][2].ToString();
                       sr.Submitby = SR.Rows[0][3].ToString();
                       sr.Starttime = SR.Rows[0][4].ToString().Substring(0,19);
                       sr.Endtime = SR.Rows[0][5].ToString().Substring(0, 19);
                       sr.Otstarttime = SR.Rows[0][6].ToString().Substring(0, 19);
                       sr.Otendtime = SR.Rows[0][7].ToString().Substring(0, 19);
                       sr.Reportsubmittime = SR.Rows[0][8].ToString().Substring(0, 19);
                       sr.Solution = SR.Rows[0][9].ToString();
                     //  MessageBox.Show(sr.Starttime);
                       ServiceReportForm srf = new ServiceReportForm(sr);
                       srf.Show();
                   }

            }
            catch (SqlException e)
            {
                LogClass.WirteLine("Read service report error:" + e.ToString());
            }
        }

        #region previous case module.
        private void button2_Click(object sender, EventArgs e)
        {
                string result= CheckPreviousCaseID(id);
                if ((result == "") || (result == null))
                {
                    string input_previous_id=Microsoft.VisualBasic.Interaction.InputBox("This issue doesn't link to any previous case, do you want to input previous case id for this case?", "Warning!!", "", -1, -1);
                    if ((input_previous_id != null) && (input_previous_id != "")&&(input_previous_id!=id))
                    {
                        if (CheckInputPreviousID(input_previous_id))
                        {
                            InsertPreviousCaseID(id, input_previous_id);
                        }
                        else
                        {
                            MessageBox.Show("your input case id:" + input_previous_id + " is not a valid id.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("your input case id:" + input_previous_id + " is not a valid id.");
                    }
                  
                }
                else                
                {
                    if (previous == null)
                    {
                        previous = new Modify(fr2, result);
                        previous.Show();
                    }
                    else
                    {
                        previous.Focus();
                    }
                   
                }
                      
        }
        private bool CheckInputPreviousID(string input_previous_id)
        {
            string connectionstr = fr2.constr;
            string Command = @"select * from carpark.dbo.IssueTable where previous_case=@previous_case;
                               select * from carpark.dbo.IssueTable where ID=@previous_case;";
            try
            {
                ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, Command, new SqlParameter("@previous_case", input_previous_id));
            }
            catch (SqlException sqle)
            {
                LogClass.WirteLine(tag + ":" + sqle.ToString());
            }
            return ((ds.Tables[0].Rows.Count <= 0) && (ds.Tables[1].Rows.Count > 0));
        }
        private string CheckPreviousCaseID(string id)
        {
            string connectionstr = fr2.constr;
            string Command = @"select previous_case from carpark.dbo.IssueTable where ID=@ID;";
            try
            {
                ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, Command, new SqlParameter("@ID", id));
                return ds.Tables[0].Rows[0]["previous_case"].ToString();
            }
            catch (SqlException sqle)
            {
                LogClass.WirteLine(tag+":"+sqle.ToString());
                return "";
            }

        }
        private void InsertPreviousCaseID(string currentid,string previousid)
        {
            string connectionstr = fr2.constr;
            string Command = @"UPDATE carpark.dbo.IssueTable SET previous_case=@previous_case where ID=@ID;";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@previous_case",previousid),
                new SqlParameter("@ID",currentid)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(connectionstr, CommandType.Text, Command,para);
                MessageBox.Show("Case id:"+previousid+" attached successfully.");
            }
            catch (SqlException sqle)
            {
                LogClass.WirteLine(tag + ":" + sqle.ToString());
                MessageBox.Show("Case id:" + previousid + " attached fail.");
            }

        }

        #endregion 
    }
}
