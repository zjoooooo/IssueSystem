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
using System.Diagnostics;
using System.IO;
using System.Xml;
using Sunisoft.IrisSkin;
using System.Runtime.InteropServices;
using System.Threading;

namespace IssueSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果     
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            string Txtusername = textBox1.Text.Trim();
            string Txtpassword = textBox2.Text.Trim();
            #region   //Check user password expireday
            if ((Txtusername != null) && (Txtpassword != null))
            {
                DataSet ds = null;
                DataTable dt = null;
                string connectionstr = "Data Source=172.16.1.89;uid=secure;pwd=weishenme;database=carpark";
                string CommandText = "select * from [carpark].[dbo].[UserLisy] where UserName=@user";
                try
                {
                    ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, CommandText, new SqlParameter("@user", Txtusername));
                    dt = ds.Tables[0];
                    if (dt.Rows.Count >= 1) //Check User if exisit
                    {
                        DataRow row = dt.Rows[0];
                        string dbpassword = row["Password"].ToString();
                        int level = Convert.ToInt16(row["Level"]);
                        DateTime ExpireDay = (DateTime)row["ExpireDate"];
                        if ((dbpassword == Txtpassword) && (ExpireDay.CompareTo(DateTime.Now) > 0))
                        {
                            ds.Dispose();
                            dt.Dispose();
                            MessageBox.Show("Welcome To Issue System");
                            Main fr2 = new Main(Txtusername, level, connectionstr);
                            this.Hide();
                            fr2.Show();

                        }
                        else { MessageBox.Show("Password Wrong or Expired"); }
                    }
                    else
                    {
                        MessageBox.Show("User is incorrect");

                    }

                }
                catch (SqlException)
                {
                    MessageBox.Show("Can't Connect to Issue Server");

                }
                if (ds != null)
                    try
                    {
                        ds.Dispose();
                    }
                    catch (SqlException) { };
                if (dt != null)
                    try
                    {
                        dt.Dispose();
                    }
                    catch (SqlException) { };
            }
            else
            { return; }
            #endregion
            //Testing sync
        }
        private void Form1_Load(object sender, EventArgs e)
        {          
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            Beautiful.AnimateWindow(this.Handle, 2000, Beautiful.AW_SLIDE | Beautiful.AW_HIDE | Beautiful.AW_BLEND);  //渐渐消失的界面
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

     



    }
}
