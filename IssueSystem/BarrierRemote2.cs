using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Timers;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;



namespace IssueSystem
{
    public partial class BarrierRemote2 : Form
    {

        public string name1;
        //private string ipaddress;
        //private string point;
        public BarrierRemote2(string s)
        {


            InitializeComponent();
            this.name1 = s;
            this.Text = name1;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //   this.BringToFront();

            this.textBox1.Text = GetValue(getname(label1.Text));
              //   MessageBox.Show("value: " + GetValue(getname(label1.Text)) + " name=" + getname(label1.Text));
            this.comboBox1.Text = GetValue(getname(label2.Text));
               //    MessageBox.Show("value: " + GetValue(getname(label2.Text)) + " name=" + getname(label2.Text));
            toolStripStatusLabel1.Text = "Tips :Set IP address and Rely Point";
            //    toolStripStatusLabel2.Text =  DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
          //  comboBox1.SelectedIndex = 0;

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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string getname(string x)
        {

            return this.name1 + x;


        }


        public static void SetValue(string key, string value, string key2, string value2)
        {
            //增加的内容写在appSettings段下

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            if (config.AppSettings.Settings[key2] == null)
            {
                config.AppSettings.Settings.Add(key2, value2);
            }
            else
            {
                config.AppSettings.Settings[key2].Value = value2;
            }
            //  config.Save(ConfigurationSaveMode.Modified);
            //   config.SaveAs("app.config");
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
        }

        public static string GetValue(string key)
        {

            //   ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            //    map.ExeConfigFilename = @"C:\Users\justin\Desktop\C#\C#-1\SNMP16RelayBoardDemo\bin\Debug\app.config";
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
                return null;
            else
                return config.AppSettings.Settings[key].Value.ToString();

        }

        private Boolean checkip(string ip)
        {
            IPAddress ip1;
            if (IPAddress.TryParse(ip.Trim(), out ip1))
                return true;
            else return false;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            if (IPAddress.TryParse(textBox1.Text, out ip))
            {
                SetValue(getname(label1.Text.ToString()), textBox1.Text.ToString(), getname(label2.Text.ToString()), comboBox1.Text.ToString());
                MessageBox.Show("Save Ok", "Data Box", MessageBoxButtons.OK);
                this.Close();
            }
            else
            { MessageBox.Show("IP address format is incorrect"); }






        }



        public string datetime { get; set; }



    }
}
