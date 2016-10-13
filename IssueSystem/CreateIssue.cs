using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace IssueSystem
{
    public partial class Create : Form
    {
        // StreamWriter sw = null;
        DataSet ds = null;
        DataTable name = null;
        DataTable IssueName = null;
        DataTable Priority = null;
        DataTable StaffName1 = null;
        DataTable StaffName2 = null;
        DataTable StaffName3 = null;
        Main fr2 = null;
        public Create(Main fr2)
        {
            InitializeComponent();
            if (!(Directory.Exists(Application.StartupPath + "\\log\\")))
                Directory.CreateDirectory(Application.StartupPath + "\\log\\");
            this.fr2 = fr2;
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
        private void Form4_Load(object sender, EventArgs e)
        {
            

            // sw = new StreamWriter(Application.StartupPath + "\\log\\" + DateTime.Now.ToString("MMdd") + ".log", true);
            string connectionstr = fr2.constr; //Connection str
            string Command = @"select name from [carpark].[dbo].[Whole];                         
                                 select IssueName from [carpark].[dbo].[IssueType];
                                select priority from [carpark].[dbo].[PriorityType];
                               select staff from [carpark].[dbo].[StaffType];
                              select staff from [carpark].[dbo].[StaffType];
                             select staff from [carpark].[dbo].[StaffType];
                            select staff from [carpark].[dbo].[StaffType];
                            select staff from [carpark].[dbo].[StaffType];
                            ;";                      //Get DropDown list from Database.


            try
            {
                ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, Command);    //execute





                name = ds.Tables[0];                   //Carpark name list
                IssueName = ds.Tables[1];             //issue list
                Priority = ds.Tables[2];              //Priority list
                StaffName1 = ds.Tables[3];           //Staff Name
                StaffName2 = ds.Tables[4];
                StaffName3 = ds.Tables[5];           //Staff Name3

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
                StaffListAttend.DataSource = StaffName3;
                StaffListAttend.DisplayMember = "staff";

                StaffListAttend2.DataSource = ds.Tables[6];
                StaffListAttend2.DisplayMember = "staff";
                StaffListAttend3.DataSource = ds.Tables[7];
                StaffListAttend3.DisplayMember = "staff";

                Station.SelectedIndex = 0; Cb_Batch.SelectedIndex = 0; Cb_BO.SelectedIndex = 0;

            }
            catch (SqlException)
            {

                MessageBox.Show("Can't get information from db");
                //  sw.WriteLine(DateTime.Now.ToString() + "   " + "Sql Command error can't get ListTable from Server");

            }
            //  sw.Flush();
            //  sw.Close();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            string connectionstr = fr2.constr;
            string CommandText = @"    Insert into [dbo].[IssueTable](carpark,issue,Solution,reportby,AttendBy,DoneBy,ReportTime,ActivatedTime,
                                       AttendedTime,DoneTime,RespondTime,DownTime,LastModifyTime,LastModifyBy,CreatedBy,Status,Priority,Station,AttendBy2,AttendBy3,Batch,BO,AttendStatus,CreateTime)
                                       values(@carpark,@issue,@Solution,@reportby,@AttendBy,@DoneBy,@ReportTime,@ActivatedTime,@AttendedTime,
                                       @DoneTime,@RespondTime,@DownTime,convert(varchar(19),getdate(),120),@LastModifyBy,@CreatedBy,@Status,@Priority,@Station,@AttendBy2,@AttendBy3,@Batch,@BO,@AttendStatus,convert(varchar(19),getdate(),120));";
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
                    new SqlParameter("@LastModifyBy",fr2.loginuser),
                    new SqlParameter("@CreatedBy",fr2.loginuser),                 
                    new SqlParameter("@Status","Open"),
                    new SqlParameter("@Priority",PriorityList.Text.Trim()),
                    new SqlParameter("@Station",Station.Text),
                    new SqlParameter("@AttendBy2",StaffListAttend2.Text.Trim()),
                    new SqlParameter("@AttendBy3",StaffListAttend3.Text.Trim()),
                    new SqlParameter("@Batch",Cb_Batch.Text.Trim()),
                    new SqlParameter("@AttendStatus",attendestatus),
                    new SqlParameter("@BO",Cb_BO.Text.Trim())
                };
            try
            {
                SqlHelper.ExecuteNonQuery(connectionstr, CommandType.Text, CommandText, parameter);
                MessageBox.Show("New Issue Create Ok");
            }
            catch (SqlException)
            {
                //   sw.WriteLine(DateTime.Now.ToString() + "   " + "Sql Command error can't add new content to Server");
                MessageBox.Show("Can't save data to db");
            }
            //sw.Flush();
            //sw.Close(); 
            try
            {
                if (ds != null)       //DataSet Close
                    ds.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close DataSet");
            }
            try
            {
                if (name != null)     //Carpark Name DataTable Close
                    name.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close name");
            }
            try
            {
                if (IssueName != null)   //Issue List DataTable Close
                    IssueName.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close IssueName");
            }
            try
            {
                if (Priority != null)          //Priority Table close
                    Priority.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close Priority");
            }
            try
            {
                if (StaffName1 != null)         //Staff Name1
                    StaffName1.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close StaffName1");
            }
            try
            {
                if (StaffName2 != null)     //Staff Name2
                    StaffName2.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close StaffName2");
            }

            int index;
            if (fr2.dataGridView1.Rows.Count > 0)
            {
                index = fr2.dataGridView1.CurrentRow.Index;
                if (index != -1)
                {
                    fr2.dataGridView1.Rows[index].Selected = true;
                }

            }
            fr2.FirstFresh();
            this.Close();


        }


        private void Close_Click(object sender, EventArgs e)
        {
            //   sw = new StreamWriter(Application.StartupPath + "\\log\\" + DateTime.Now.ToString("MMdd") + ".log", true);
            try
            {
                if (ds != null)       //DataSet Close
                    ds.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close DataSet");
            }
            try
            {
                if (name != null)     //Carpark Name DataTable Close
                    name.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close name");
            }
            try
            {
                if (IssueName != null)   //Issue List DataTable Close
                    IssueName.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close IssueName");
            }
            try
            {
                if (Priority != null)          //Priority Table close
                    Priority.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close Priority");
            }
            try
            {
                if (StaffName1 != null)         //Staff Name1
                    StaffName1.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close StaffName1");
            }
            try
            {
                if (StaffName2 != null)     //Staff Name2
                    StaffName2.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show(DateTime.Now.ToString() + "   " + "Can't close StaffName2");
            }
            //sw.Flush();
            //sw.Close();
            fr2.FirstFresh();
            this.Close();

        }

        private void Create_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cb_Batch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }    
    }
}
