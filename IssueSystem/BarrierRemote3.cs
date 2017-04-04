using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace IssueSystem
{
    public partial class BarrierRemote3 : Form
    {
        BarrierRemote br;
        public BarrierRemote3(BarrierRemote br)
        {
            InitializeComponent();
            this.br = br;
            this.TopLevel = true;
        }
      


        private void Form3_Load(object sender, EventArgs e)
        {
          
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
     

        private void button1_Click(object sender, EventArgs e)
        {
                    CheckBox[] chb = { ENTRY1, EXIT1, ENTRY2, EXIT2, ENTRY3, EXIT3, ENTRY4, EXIT4, ENTRY5, EXIT5, ENTRY6, EXIT6, ENTRY7, EXIT7, ENTRY8, EXIT8, LBENTRY1, LBENTRY2, LBENTRY3, LBEXIT1, LBEXIT2, LBEXIT3, SENTRY, SEXIT,SENTRY2,SEXIT2,SENTRY3,SEXIT3, SENTRY4, SEXIT4, SENTRY5, SEXIT5, SENTRY6, SEXIT6, SENTRY7, SEXIT7 };
                    if ((textBox1.Text == "")||(char.IsNumber(textBox1.Text, 0)))
                    {
                        if(textBox1.Text == "")
                        MessageBox.Show("CarPark Name Can't Be Null");
                        else if (char.IsNumber(textBox1.Text, 0))
                        MessageBox.Show("CarPark Name First Char Can't Be Number");
                       
                    }
                    else
                    {
                    
                        string path = Application.StartupPath + "\\system.xml";
                        XmlDocument doc = new XmlDocument();
                        doc.Load(path);
                        XmlNode root = doc.SelectSingleNode("CARPARK");
                        XmlNodeList childkey = root.ChildNodes;
                        string x = null;
                        foreach (XmlNode xl in childkey)
                        {
                            if (xl.Name.ToString() == textBox1.Text.Trim())
                            { MessageBox.Show("CarPark Already Exist In The List"); x = xl.Name; break; }

                        }
                        if (x != textBox1.Text)
                        {

                            XmlElement xelKey = doc.CreateElement(textBox1.Text);
                            //   XmlAttribute xelType = doc.CreateAttribute("Type");
                            //   xelType.InnerText = "adfdsf";
                            //   xelKey.SetAttributeNode(xelType);

                            foreach (CheckBox ch in chb)
                            {
                                if (ch.Checked)
                                {
                                    XmlElement xelAuthor = doc.CreateElement(ch.Name);
                                    xelAuthor.InnerText = ch.Name;
                                    xelKey.AppendChild(xelAuthor);
                                }
                            }
                            root.AppendChild(xelKey);
                            doc.Save(path);
                            br.listBox1.Items.Add(textBox1.Text);
                            MessageBox.Show("Save Ok");
                            this.Close();
                        }
                         
                        
                    }
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
    }
}
