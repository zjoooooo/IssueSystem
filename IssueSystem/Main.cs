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
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IssueSystem
{
    public partial class Main : Form
    {
        public string loginuser;
        public int level;
        public string constr;
        public Dictionary<string, string> carparklist = new Dictionary<string, string>();
        DataSet rfds = null;
        Thread threab26 = null;
        Thread threab28 = null;
        Thread threab30 = null;
        Thread threabb = null;
        Thread threacl = null;
        Thread threahg = null;
        Thread thread4 = null;
        public delegate void Shuaxin1Delegate(DataSet ds);
        public delegate void Shuaxin2Delegate(DataSet ds);
        public delegate void Shuaxin3Delegate(DataSet ds);
        public Main(string loginuser, int level, string constr)
        {
            InitializeComponent();
            this.loginuser = loginuser;
            this.level = level;
            this.constr = constr;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            #region  //initialize Frame
            toolStripStatusLabel1.Text = "Login by : " + loginuser;
            toolStripStatusLabel3.Text = "Designed By Justin Zhang";
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.notifyIcon1.Visible = false;
            FirstFresh();
          //  Check();
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView2.Columns[10].HeaderText = "ROActualTimeOnSite";
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = true;
            if (dataGridView3.RowCount>0)
            {
                dataGridView3.Rows[0].Selected=true;
            }
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
            if (dataGridView2.RowCount > 0)
            {
                dataGridView2.Rows[0].Selected = true;
            }
            tabControl1.ImageList = imageList1;
            tabPage1.ImageIndex = 0;
            tabPage2.ImageIndex = 1;
            tabPage3.ImageIndex = 2;
            timer1.Interval = 1000;
            timer1.Start();
            timer3.Interval = 20000;
            timer3.Start();
            #endregion

            #region  //initialize user authorized
            if (level == 2)
            {
                toolStripMenuItem1.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                helpToolStripMenuItem.Enabled = false;
                reportToolStripMenuItem.Enabled = false;
                barrierSystemToolStripMenuItem.Enabled = false;
                AddFr.Enabled = false;
                DeleteFr.Enabled = false;
                secureStaffVehicleUpdateToolStripMenuItem.Enabled = false;
                carParkToolStripMenuItem.Enabled = false;
                seasonInterfacePCResetToolStripMenuItem.Enabled = false;
            }
            else if (level == 1)
            {
                toolStripMenuItem1.Enabled = false;
            }
            #endregion

            #region //Get Carpark List and use it for Sunjapan Fuction
            string CommandText = "select name,ip from dbo.Whole;";
            DataSet ds = null;
            try
            {

                ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, CommandText);
                foreach (DataRow ls in ds.Tables[0].Rows)
                {
                    carparklist.Add(ls[0].ToString(), ls[1].ToString());

                }

            }
            catch (SqlException)
            { MessageBox.Show("CAN'T CONNECT TO CARPARK LIST SERVER"); }
            finally
            {
                try
                { ds.Dispose(); }
                catch (SqlException)
                { }
            }

            #endregion
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  //Clock
        }
        private void _threadProc()
        {
            MethodInvoker mi = new MethodInvoker(Check);
            BeginInvoke(mi);
        }
        public void Shua(DataSet ds)
        {
            try
            {
                if (dataGridView1.InvokeRequired)
                {
                    Shuaxin1Delegate sxd = new Shuaxin1Delegate(Shua);
                    this.Invoke(sxd, ds);
                }
                else
                {
                    int index1 = 0;
                    try
                    {
                        if (dataGridView1.RowCount <= 0)
                        {

                        }
                        else
                        {
                            index1 = dataGridView1.CurrentRow.Index;
                        }
                    }
                    catch (Exception e)
                    {
                        LogClass.WirteLine("Get currentrow for dataGridView1 error : " + e.ToString());
                    }                   
                    //防止没有任何行数时报错.
                    if (index1 >= 0)
                    {
                        int x1 = ds.Tables[0].Rows.Count - dataGridView1.Rows.Count;
                        if (x1 > 0 || x1 < 0)
                        {
                            try
                            {
                                dataGridView1.DataSource = ds.Tables[0];
                                if ((index1 + x1 < 0)||(index1+1> dataGridView1.Rows.Count))
                                {
                                    dataGridView1.Rows[0].Selected = true;
                                }
                                else
                                {
                                    dataGridView1.Rows[index1 + x1].Selected = true;
                                }
                                
                                dataGridView1.CurrentCell = dataGridView1.Rows[index1].Cells[0];
                            }
                            catch (Exception e)
                            {
                                LogClass.WirteLine($"Set previous row to current row for dataGridView1 error:index={index1},x1={x1},ds.Tables[0].Rows.Count={ds.Tables[0].Rows.Count},dataGridView1.Rows.Count={dataGridView1.Rows.Count},{e.ToString()}");
                            }

                            foreach (DataGridViewRow dr in dataGridView1.Rows)
                            {
                                //if (dr.Selected)
                                //{
                                //    index = dr.Index;
                                //}
                                //    MessageBox.Show(dr.Cells["Status"].Value.ToString());
                                if (dr.Cells["Status"].Value.ToString() == "Open") // set color
                                {
                                    dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Red;
                                }
                                else if (dr.Cells["Status"].Value.ToString() == "Closed")
                                {
                                    dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Green;
                                }
                                else if (dr.Cells["Status"].Value.ToString() == "Follow Up")
                                {
                                    dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Blue;
                                }
                            }
                        }

                    }
                }
                if (dataGridView2.InvokeRequired)
                {
                    Shuaxin2Delegate sxd = new Shuaxin2Delegate(Shua);
                    this.Invoke(sxd, ds);
                }
                else
                {
                    //int index2 = 0;
                    //try
                    //{
                    //    if (dataGridView2.RowCount <= 0)
                    //    {

                    //    }
                    //    else
                    //    {
                    //        index2 = dataGridView2.CurrentRow.Index;
                    //    }

                    //}
                    //catch (Exception e)
                    //{
                    //    LogClass.WirteLine("Get currentrow for dataGridView2 error : " + e.ToString());
                    //}

                    ////防止没有任何行数时报错.
                    //if (index2 >= 0)
                    //{
                    //    int x2 = ds.Tables[1].Rows.Count - dataGridView2.Rows.Count;
                    //    if (x2 > 0 || x2 < 0)
                    //    {
                            try
                            {
                                dataGridView2.DataSource = ds.Tables[1];
                                //dataGridView2.Rows[index2 + x2].Selected = true;
                                //dataGridView2.CurrentCell = dataGridView2.Rows[index2].Cells[0];
                            }
                            catch (Exception e)
                            {
                                LogClass.WirteLine("Set previous row to current row for dataGridView2 error : " + e.ToString());
                            }

                            foreach (DataGridViewRow dr in dataGridView2.Rows)
                            {
                                //if (dr.Selected)
                                //{
                                //    index = dr.Index;
                                //}
                                //    MessageBox.Show(dr.Cells["Status"].Value.ToString());
                                if (dr.Cells["Status"].Value.ToString() == "Open") // set color
                                {
                                    dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Red;
                                }
                                else if (dr.Cells["Status"].Value.ToString() == "Closed")
                                {
                                    dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Green;
                                }
                                else if (dr.Cells["Status"].Value.ToString() == "Follow Up")
                                {
                                    dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Blue;
                                }
                            }
                        //}

                    //}
                }


                if (dataGridView3.InvokeRequired)
                {
                    Shuaxin3Delegate sxd = new Shuaxin3Delegate(Shua);
                    this.Invoke(sxd, ds);
                }
                else
                {
                    //int index3 = 0;
                    //try
                    //{
                    //    if (dataGridView3.RowCount <= 0)
                    //    {

                    //    }
                    //    else
                    //    {
                    //        index3 = Convert.ToInt16(dataGridView3.CurrentRow.Index);
                    //    }

                    //}
                    //catch (Exception e)
                    //{
                    //    LogClass.WirteLine("Get currentrow for dataGridView3 error : " + e.ToString());
                    //}                   
                    ////防止没有任何行数时报错.
                    //if (index3 >= 0)
                    //{
                    //    int x3 = ds.Tables[2].Rows.Count - dataGridView3.Rows.Count;
                    //    if (x3 > 0 || x3 < 0)
                    //    {
                            try
                            {
                                dataGridView3.DataSource = ds.Tables[2];
                             //   dataGridView3.Rows[index3 + x3].Selected = true;
                             //   dataGridView3.CurrentCell = dataGridView3.Rows[index3].Cells[0];
                            }
                            catch (Exception e)
                            {
                                LogClass.WirteLine("Set previous row to current row for dataGridView3 error : " + e.ToString());
                            }

                    //    }

                    //}
                }
            }catch(Exception e)
            {
                LogClass.WirteLine("Refresh and stabilize girdview1,2,3 error : " + e.ToString());
            }
        }
        public void Check()
        {
            DataSet dss;
   //         string cmd = @"select ID,CarPark,Station,Issue,Status,Priority,Solution,Reportby,AttendBy,AttendBy2,AttendBy3,DoneBy,ReportTime,ActivatedTime,AttendedTime,DoneTime,RespondTime,DownTime from [carpark].[dbo].[IssueTable] where ReportTime>DATEADD(DAY, -7, GETDATE()) OR Status='Open' ORDER BY ReportTime DESC;
   //                        select ID,CarPark,Status,CptaStaff,SpccStaff,RO,Details,ReportToCPTA,TimeGiven,TimeOnSite,ROAcualTimeOnSite,TimeCompletion from [carpark].[dbo].[IllegalParkingTable] where TimeGiven>DATEADD(DAY, -7, GETDATE())  OR Status='Open' order by TimeGiven DESC;
   //                        select id,carpark,station,bo,followby,starttime,endtime,issue,solution,item,qty,otstarttime,otendtime,submitby,posttime,ot from [carpark].[dbo].SRtable where starttime>DATEADD(DAY, -7, GETDATE()) ORDER BY starttime DESC;";
            string cmd = @"select ID,CreateTime,CarPark,Station,Issue,Status,Priority,Reportby,CreatedBy,AttendBy from [carpark].[dbo].[IssueTable] where ReportTime>DATEADD(DAY, -2, GETDATE()) OR Status!='Closed' ORDER BY ReportTime DESC;
                           select ID,CarPark,Status,CptaStaff,SpccStaff,RO,Details,ReportToCPTA,TimeGiven,TimeOnSite,ROAcualTimeOnSite,TimeCompletion from [carpark].[dbo].[IllegalParkingTable] where TimeGiven>DATEADD(DAY, -2, GETDATE())  OR Status!='Closed' order by TimeGiven DESC;
                           select id as ID,linkid as CaseID,posttime as SubmitTime,carpark as CarPark,station as Station,bo as Bo,followby as FollowUp,starttime as StartTime,endtime as EndTime,issue as Issue,solution as Solution,item as Item,qty as Qty,otstarttime as OverTimeStart,otendtime as OverTimeEnd,submitby as SubmitBy,ot as OverTimeMins from [carpark].[dbo].SRtable where starttime>DATEADD(DAY, -2, GETDATE()) ORDER BY starttime DESC;";

            try
            {

                dss = SqlHelper.ExecuteDataset(constr, CommandType.Text, cmd);    //execute
                Shua(dss);
            }
            catch (SqlException e)
            {
                LogClass.WirteLine("Error when getting dataset for 3 dvg : " + e.ToString());
            }



            string Attendcmd = @"SELECT AttendBy,ID,Carpark,Station,Issue,AttendedTime FROM [dbo].[IssueTable] where AttendStatus='1' and ActivatedTime BETWEEN dateadd(SECOND,-20,getdate()) and GETDATE();
                                 SELECT submitby,linkid,carpark,station,issue,followby FROM [dbo].[SRtable] where  posttime BETWEEN dateadd(SECOND,-20,getdate()) and GETDATE();";
            DataSet ds = null;
            try
            {
                ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, Attendcmd);    //execute

            }
            catch (SqlException e)
            {
                LogClass.WirteLine("AttendCheck error : " + e.ToString());
            }

            try
            {
                //if (ds.Tables[0].Rows.Count >= 1)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {
                //        string submitby = ds.Tables[0].Rows[i][0].ToString();
                //        string linkid = ds.Tables[0].Rows[i][1].ToString();
                //        string carpark = ds.Tables[0].Rows[i][2].ToString();
                //        string station = ds.Tables[0].Rows[i][3].ToString();
                //        string issue = ds.Tables[0].Rows[i][4].ToString();
                //        string AttendedTime = ds.Tables[0].Rows[i][5].ToString().Substring(0, 19);
                //        Alert alert = new Alert();
                //        string cp = submitby + " attend a case on " + AttendedTime + "\r\n";
                //        cp = cp + "Car Park : " + carpark + "\r\n";
                //        cp = cp + "Station  : " + station + "\r\n";
                //        cp = cp + "Issue  : " + issue + "\r\n";
                //        cp = cp + "Issue id : " + linkid + "\r\n";
                //        alert.textBox1.Text = cp;
                //        LogClass.WirteLine(cp);
                //        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - alert.Width, Screen.PrimaryScreen.WorkingArea.Height - alert.Height);
                //        alert.PointToScreen(p);
                //        alert.Location = p;
                //        Beautiful.AnimateWindow(alert.Handle, 1000, Beautiful.AW_BLEND);
                //        alert.Show();
                //        FirstFresh();
                //    }

                //}

                   //Test commit
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string submitby = ds.Tables[0].Rows[i][0].ToString();
                            string linkid = ds.Tables[0].Rows[i][1].ToString();
                            string carpark = ds.Tables[0].Rows[i][2].ToString();
                            string station = ds.Tables[0].Rows[i][3].ToString();
                            string issue = ds.Tables[0].Rows[i][4].ToString();
                            string AttendedTime = ds.Tables[0].Rows[i][5].ToString().Substring(0, 19);
                            Alert alert = new Alert();
                            string cp = submitby + " attend a case on " + AttendedTime + "\r\n";
                            cp = cp + "Car Park : " + carpark + "\r\n";
                            cp = cp + "Station  : " + station + "\r\n";
                            cp = cp + "Issue  : " + issue + "\r\n";
                            cp = cp + "Issue id : " + linkid + "\r\n";
                            alert.textBox1.Text = cp;
                            LogClass.WirteLine(cp);
                            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - alert.Width, Screen.PrimaryScreen.WorkingArea.Height - alert.Height);
                            alert.PointToScreen(p);
                            alert.Location = p;
                            Beautiful.AnimateWindow(alert.Handle, 1000, Beautiful.AW_BLEND);
                            alert.Show();
                           // FirstFresh();
                        }
                    }                       
            }
            catch(Exception e)
            {
                LogClass.WirteLine("popup windows for new attend case error : " + e.ToString());
            }

            try
            {

                if (ds.Tables[1].Rows.Count >= 1)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        string submitby = ds.Tables[1].Rows[i][0].ToString();
                        string linkid = ds.Tables[1].Rows[i][1].ToString();
                        string carpark = ds.Tables[1].Rows[i][2].ToString();
                        string station = ds.Tables[1].Rows[i][3].ToString();
                        string issue = ds.Tables[1].Rows[i][4].ToString();
                        string follower = ds.Tables[1].Rows[i][5].ToString();
                        Alert alert = new Alert();
                        string cp = submitby + " submit a new service report from " + "\r\n";
                        cp = cp + "Car Park : " + carpark + "\r\n";
                        cp = cp + "Station  : " + station + "\r\n";
                        cp = cp + "Issue  : " + issue + "\r\n";
                        cp = cp + "Issue id : " + linkid + "\r\n";
                        cp = cp + "Follow up by : " + follower + "\r\n";
                        alert.textBox1.Text = cp;
                        LogClass.WirteLine(cp);
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - alert.Width, Screen.PrimaryScreen.WorkingArea.Height - alert.Height);
                        alert.PointToScreen(p);
                        alert.Location = p;
                        Beautiful.AnimateWindow(alert.Handle, 1000, Beautiful.AW_BLEND);
                        alert.Show();
                        FirstFresh();
                    }
                }
            }
            catch (Exception e)
            {
                LogClass.WirteLine("popup windows for new service report error : " + e.ToString());
            }   
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
          //  MessageBox.Show("Timer3 Start");
            thread4 = new Thread(new ThreadStart(_threadProc));
            thread4.IsBackground = true;
            thread4.Start();
        }
        public void FirstFresh()
        {
            #region  //normal refresh CarparkIssue without new issue detected
            string CommandText = @"select ID,CreateTime,CarPark,Station,Issue,Status,Priority,Reportby,CreatedBy,AttendBy from [carpark].[dbo].[IssueTable] where ReportTime>DATEADD(DAY, -2, GETDATE()) OR Status!='Closed' ORDER BY ReportTime DESC;
                            select ID,CarPark,Status,CptaStaff,SpccStaff,RO,Details,ReportToCPTA,TimeGiven,TimeOnSite,ROAcualTimeOnSite,TimeCompletion from [carpark].[dbo].[IllegalParkingTable] where TimeGiven>DATEADD(DAY, -2, GETDATE())  OR Status!='Closed' order by TimeGiven DESC;
                            select id as ID,linkid as CaseID,posttime as SubmitTime,carpark as CarPark,station as Station,bo as Bo,followby as FollowUp,starttime as StartTime,endtime as EndTime,issue as Issue,solution as Solution,item as Item,qty as Qty,otstarttime as OverTimeStart,otendtime as OverTimeEnd,submitby as SubmitBy,ot as OverTimeMins from [carpark].[dbo].SRtable where starttime>DATEADD(DAY, -2, GETDATE()) ORDER BY starttime DESC;";
            try
            {
                rfds = SqlHelper.ExecuteDataset(constr, CommandType.Text, CommandText);
                dataGridView1.DataSource = rfds.Tables[0];
                dataGridView2.DataSource = rfds.Tables[1];
                dataGridView3.DataSource = rfds.Tables[2];
            }catch(SqlException sqle){
                LogClass.WirteLine("First refresh reading error:"+sqle.ToString());
            }
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (dr.Cells["Status"].Value.ToString() == "Open") // set color
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (dr.Cells["Status"].Value.ToString() == "Closed")
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (dr.Cells["Status"].Value.ToString() == "Follow Up")
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }

            if (dataGridView2.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView2.Rows)
                {
                    if (dr.Cells["Status"].Value.ToString() == "Open") // set color
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (dr.Cells["Status"].Value.ToString() == "Closed")
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (dr.Cells["Status"].Value.ToString() == "Follow Up")
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }
            #endregion
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)   // Carpark issue
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView2.Rows)
                    {
                        if (dr.Cells["Status"].Value.ToString() == "Open") // set color
                        {
                            dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (dr.Cells["Status"].Value.ToString() == "Closed")
                        {
                            dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Green;
                        }
                        else if (dr.Cells["Status"].Value.ToString() == "Follow Up")
                        {
                            dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Blue;
                        }


                    }
                }

            }
        }
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    //    MessageBox.Show(dr.Cells["Status"].Value.ToString());
                    if (dr.Cells["Status"].Value.ToString() == "Open") // set color
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (dr.Cells["Status"].Value.ToString() == "Closed")
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (dr.Cells["Status"].Value.ToString() == "Follow Up")
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Blue;
                    }

                    //if (dr.Cells["Priority"].Value.ToString() == "High")
                    //{
                    //    dr.Cells["Priority"].Style.ForeColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    dr.Cells["Priority"].Style.ForeColor = System.Drawing.Color.Green;
                    //}
                }
            }
        }
        private void dataGridView2_Sorted(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView2.Rows)
                {
                    //    MessageBox.Show(dr.Cells["Status"].Value.ToString());
                    if (dr.Cells["Status"].Value.ToString() == "Open") // set color
                    {

                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Red;

                    }
                    else if (dr.Cells["Status"].Value.ToString() == "Closed")
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (dr.Cells["Status"].Value.ToString() == "Follow Up")
                    {
                        dr.Cells["Status"].Style.ForeColor = System.Drawing.Color.Blue;
                    }

                    //if (dr.Cells["Priority"].Value.ToString() == "High")
                    //{
                    //    dr.Cells["Priority"].Style.ForeColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    dr.Cells["Priority"].Style.ForeColor = System.Drawing.Color.Green;
                    //}
                }
            }
        }
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }

        }
        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Selected = false;
            }
        }
        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Selected = false;
            }
        }
        private void AddFr_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(tabControl1.SelectedTab.ToString());
            if (tabControl1.SelectedIndex == 0)   // Carpark issue
            {
                Create fr4 = new Create(this);
                fr4.Show();
            }
            else if (tabControl1.SelectedIndex == 1)   // Illegal Parking
            {
                CreateROissue CR = new CreateROissue(this);
                CR.Show();
            }
        }
        private void DeleteFr_Click_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.CurrentRow.Index != -1)
                    {
                        // MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
                        DialogResult dialogResult = MessageBox.Show("Are you sure to delete this issue", "Warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int row = dataGridView1.CurrentRow.Index;
                            string ID = dataGridView1.Rows[row].Cells["ID"].Value.ToString();

                            //  string connectionstr = "Data Source=172.16.1.31;uid=sa;pwd=weishenme;database=carpark";
                            string CommandText = @"Delete from [carpark].[dbo].[IssueTable] where ID=@ID;";
                            try
                            {
                                SqlHelper.ExecuteNonQuery(constr, CommandType.Text, CommandText, new SqlParameter("@ID", ID));
                            }
                            catch (SqlException)
                            { MessageBox.Show("Delete Car Park Issue Fail"); }

                        }
                    }
                    else
                    { MessageBox.Show("Please Select A CarPark Issue To Delete"); }
                }
                else
                { MessageBox.Show("No Data To Delete"); }

            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    if (dataGridView2.CurrentRow.Index != -1)
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure to delete this issue", "Warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int row = dataGridView2.CurrentRow.Index;
                            string ID = dataGridView2.Rows[row].Cells["ID"].Value.ToString();

                            //  string connectionstr = "Data Source=172.16.1.31;uid=sa;pwd=weishenme;database=carpark";
                            string CommandText = @"Delete from [carpark].[dbo].[IllegalParkingTable] where ID=@ID;";
                            try
                            {
                                SqlHelper.ExecuteNonQuery(constr, CommandType.Text, CommandText, new SqlParameter("@ID", ID));
                            }
                            catch (SqlException)
                            { MessageBox.Show("Delete Illegal Parking Case Fail"); }

                        }
                    }
                    else
                    { MessageBox.Show("Please Select A Illegal Parking Case To Delete"); }
                }
                else
                { MessageBox.Show("No Data To Delete"); }

            }
            FirstFresh();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region   // double check datagrid row event popup update frm for carpark issue
            //Boolean flag = false;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (dataGridView1.Rows[i].Selected)
            //    { flag = true; }
            //}
            //if (flag)
            //{
            //int row = dataGridView1.CurrentRow.Index;
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    String ID = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    Modify fr3 = new Modify(this, ID);
                    fr3.Show();
                }
                catch (Exception es)
                {
                    LogClass.WirteLine("Cell Double Click: "+es.ToString());
                }

            }
            //}
            #endregion
        }
        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            #region   // double check datagrid row event popup update frm for illegal parking
            //Boolean flag = false;
            //for (int i = 0; i < dataGridView2.Rows.Count; i++)
            //{
            //    if (dataGridView2.Rows[i].Selected)
            //    { flag = true; }
            //}
            //if (flag)
            //{
            //    int row = dataGridView2.CurrentRow.Index;
            if (dataGridView2.Rows.Count > 0)
            {
                String ID = dataGridView2.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                ModifyROissue mr = new ModifyROissue(this, ID);
                mr.ShowDialog();
            }
            //}
            #endregion
        }

        #region // Open frm
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Issue_Report rp = new Issue_Report();
            rp.Show();
        }
        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }
        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            System.Environment.Exit(0);
        }
        private void userManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl cu = new UserControl(this);
            cu.ShowDialog();
        }
        private void updateDeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDeleteUser cdu = new ChangeDeleteUser(this);
            cdu.ShowDialog();
        }
        private void createCarparkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateModifyCarpark cmc = new CreateModifyCarpark(this);
            cmc.ShowDialog();
        }
        private void createIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateModifyIssueList cmi = new CreateModifyIssueList(this);
            cmi.Show();
        }
        private void aboutIssueSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            Beautiful.AnimateWindow(ab.Handle, 2000, Beautiful.AW_BLEND);
            ab.ShowDialog();
        }
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("EXCEL.EXE");
        }
        private void microsoftWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WINWORD.EXE");
        }
        private void calculaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }
        private void commandLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe");
        }
        private void notePadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }
        private void internetBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe");
        }
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string CommandText = @"Backup Database carpark to Disk='D:\" + DateTime.Now.ToString("yyy-MM-dd") + ".bak'";
            try
            {
                SqlHelper.ExecuteNonQuery(constr, CommandType.Text, CommandText);
                MessageBox.Show(@"Backup Database Ok to \\Server\D\" + DateTime.Now.ToString("yyy-MM-dd") + ".bak");
            }
            catch (SqlException)
            {
                MessageBox.Show("Fail to Backup Database");
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateModifyAttenderList cmal = new CreateModifyAttenderList(this);
            cmal.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Beautiful.AnimateWindow(this.Handle, 2000, Beautiful.AW_SLIDE | Beautiful.AW_HIDE | Beautiful.AW_BLEND);
            Application.Exit();
            System.Environment.Exit(0);

        }

        private void searchIssueSolvedByWhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Report3 rp3 = new Report3(this);
            //  rp3.ShowDialog();
        }


        private void movementSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movement mv = new Movement(this);
            mv.Show();
        }

        private void barrierRemoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarrierRemote br = new BarrierRemote();
            br.ShowDialog();
        }



        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword(this);
            cp.ShowDialog();
        }

        private void usToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarparkUserDelete cud = new CarparkUserDelete(this);
            cud.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarparkUserUpdate cuu = new CarparkUserUpdate(this);
            cuu.Show();
        }

        private void class1UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1Update c1u = new Class1Update(this);
            c1u.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecureStaffDelete ssd = new SecureStaffDelete(this);
            ssd.Show();
        }

        private void update2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SecureStaffUpdate ssu = new SecureStaffUpdate(this);
            ssu.Show();
        }


        private void passwordCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordCollection pc = new PasswordCollection();
            pc.Show();
        }

        #endregion
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            // notifyIcon1.Visible = true;
            this.ShowInTaskbar = true;
            //  this.Visible = true;
            //  this.Activate();
            this.WindowState = FormWindowState.Normal;
            this.Show();

        }
        private void interfacePCReset(String ip)
        {
            try
            {
                MessageBox.Show("Try To Reset PC!!Please Do not Reset Again Until Next Message Pop Up!");
                //create a new telnet connection to hostname "gobelijn" on port "23"
                TelnetConnection tc; tc = new TelnetConnection(ip, 23);

                //login with user "root",password "rootpassword", using a timeout of 100ms, and show server output
                string s = tc.Login("sunpark", "Tdxh638*\r\n", 500);

                Console.Write(s);

                // server output should end with "$" or ">", otherwise the connection failed
                string prompt = s.TrimEnd();
                prompt = s.Substring(prompt.Length - 1, 1);
                if (prompt != "$" && prompt != ">")
                    //    throw new Exception("Connection failed");

                    prompt = "";
                System.Threading.Thread.Sleep(500);
                tc.WriteLine("\r\n");
                System.Threading.Thread.Sleep(500);
                tc.WriteLine("cd c:\\carpark\r\n");
                System.Threading.Thread.Sleep(500);
                tc.WriteLine("start VBReboot.exe\r\n");
                System.Threading.Thread.Sleep(500);
                MessageBox.Show("Reset Ok Please Check Monitoring Program After 5 Mins.");
                //   MessageBox.Show("Reset Ok Please Check Monitoring PC After 5 Mins.");
            }
            catch
            {
                MessageBox.Show("Fail to Reset PC Please Try Again!");
            }
        }
        private void b26ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threab26 = new Thread(() => interfacePCReset("192.168.1.6"));
            threab26.Start();
        }
        private void b28ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threab28 = new Thread(() => interfacePCReset("10.4.127.6"));
            threab28.Start();
        }
        private void b30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threab30 = new Thread(() => interfacePCReset("10.4.127.7"));
            threab30.Start();
        }
        private void cLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threacl = new Thread(() => interfacePCReset("192.168.1.8"));
            threacl.Start();
        }
        private void bBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threabb = new Thread(() => interfacePCReset("192.168.1.7"));
            threabb.Start();
        }
        private void hGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threahg = new Thread(() => interfacePCReset("192.168.1.7"));
            threahg.Start();
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Main_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void carparkIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IllegalParking_Report Illegal = new IllegalParking_Report();
            Illegal.Show();
        }

        private void serviceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceReports sr = new ServiceReports();
            sr.Show();
        }

        private void barrierOpenReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarrierOpenReport bor = new BarrierOpenReport();
            bor.Show();
        }

        private void newBarrierRemoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewBarrierRemote NewbarrierReomte = new NewBarrierRemote();
            NewbarrierReomte.Show();
        }
    }
}
