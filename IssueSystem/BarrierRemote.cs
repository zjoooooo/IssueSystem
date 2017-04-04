using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Net.NetworkInformation;
using System.Configuration;
using System.Globalization;
using System.Xml;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace IssueSystem
{
    public partial class BarrierRemote : Form
    {
        public Ping ping = new Ping();
        public string[] arrayip;
        public string[] arraymib;
        public BarrierRemote()
        {

            InitializeComponent();
            //    this.skinEngine2.SkinFile = Application.StartupPath + "/Skins/Calmness.ssk";
            //    skinEngine2.SkinAllForm = true;

        }


        //public static string cpselected()
        //{

        //    return listBox1.SelectedItem.ToString();


        //}
        private void refresh()
        {
            listBox1.Items.Clear();
            string path = Application.StartupPath + "\\system.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.SelectSingleNode("CARPARK");
            XmlNodeList childkey = root.ChildNodes;
            foreach (XmlNode xl in childkey)
            {
                listBox1.Items.Add(xl.Name);

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            int processCount = 0;
            Process[] pa = Process.GetProcesses();//GetProcess Array   
            foreach (Process PTest in pa)
            {
                if (PTest.ProcessName == Process.GetCurrentProcess().ProcessName)
                {
                    processCount += 1;
                }
            }
            if (processCount > 1)  //If running close current process
            {

                DialogResult dr;
                dr = MessageBox.Show(Process.GetCurrentProcess().ProcessName + " Porgram is running！", "quit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); //Exit;   

            }


            refresh();   //get carpark list from xml
            setdefault(); //set all checkbox visable to false;
            toolStripStatusLabel1.Text = null;
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Start();

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
        private int SNMP_SET(String IPaddress, int Port, String OID, sbyte dataType, String SetValue, String Community)
        {
            adventnet.snmp.snmp2.SnmpAPI objAPI = new adventnet.snmp.snmp2.SnmpAPI();
            adventnet.snmp.snmp2.SnmpSession objSession = new adventnet.snmp.snmp2.SnmpSession(objAPI);
            adventnet.snmp.snmp2.SnmpPDU objPDU = new adventnet.snmp.snmp2.SnmpPDU();
            adventnet.snmp.snmp2.SnmpPDU objResultPDU = new adventnet.snmp.snmp2.SnmpPDU();
            adventnet.snmp.snmp2.SnmpOID objOID = new adventnet.snmp.snmp2.SnmpOID(OID);
            System.Net.IPAddress ipIPAddress = System.Net.IPAddress.Parse(IPaddress);
            adventnet.snmp.snmp2.UDPProtocolOptions objUDPOpt = new adventnet.snmp.snmp2.UDPProtocolOptions(ipIPAddress, Port);
            objSession.Version = adventnet.snmp.snmp2.SnmpAPI.SNMP_VERSION_1;
            objSession.Open();
            objPDU.DNSLookup = false;
            objPDU.ProtocolOptions = objUDPOpt;
            objPDU.Command = adventnet.snmp.snmp2.SnmpAPI.SET_REQ_MSG;
            objPDU.Community = Community;
            adventnet.snmp.snmp2.SnmpVar mvar = adventnet.snmp.snmp2.SnmpVar.CreateVariable(SetValue, dataType);
            objPDU.AddVariableBinding(new adventnet.snmp.snmp2.SnmpVarBind(objOID, mvar));
            objResultPDU = objSession.SyncSend(objPDU);
            int[] x = objSession.CheckResponses();
            //   MessageBox.Show(x.ToString());
            //  int[] x = { 1, 2, 3, 4 };
            //foreach (int i in x)
            //{
            //    MessageBox.Show(i.ToString());
            //}
            objSession.Close();
            objAPI.Close();
            return 1;

        }
        //public adventnet.snmp.snmp2.SnmpPDU snmpGet(String IPaddress, int Port, String OID, String Community)
        //{

        //adventnet.snmp.snmp2.SnmpAPI objAPI = new adventnet.snmp.snmp2.SnmpAPI();
        //adventnet.snmp.snmp2.SnmpSession objSession = new adventnet.snmp.snmp2.SnmpSession(objAPI);
        //adventnet.snmp.snmp2.SnmpPDU objPDU = new adventnet.snmp.snmp2.SnmpPDU();
        //adventnet.snmp.snmp2.SnmpPDU objResultPDU = new adventnet.snmp.snmp2.SnmpPDU();
        //adventnet.snmp.snmp2.SnmpOID objOID = new adventnet.snmp.snmp2.SnmpOID(OID);  
        //System.Net.IPAddress ipIPAddress = System.Net.IPAddress.Parse(IPaddress);
        //adventnet.snmp.snmp2.UDPProtocolOptions objUDPOpt = new adventnet.snmp.snmp2.UDPProtocolOptions(ipIPAddress, Port);
        //objSession.Version = adventnet.snmp.snmp2.SnmpAPI.SNMP_VERSION_1;
        //objSession.Open();
        //objPDU.DNSLookup = false;
        //objPDU.ProtocolOptions = objUDPOpt;
        //objPDU.Command = adventnet.snmp.snmp2.SnmpAPI.GET_REQ_MSG;
        //objPDU.Community = Community;   
        //objPDU.AddNull(objOID);
        //objResultPDU = objSession.SyncSend(objPDU);
        //objSession.Close();
        //objAPI.Close();
        //return objResultPDU;
        //}
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            toolStripStatusLabel1.Text = "WELCOME TO BARRIER CONTROLLER SYSTEM！";
        }
        public bool Ping(string ip)
        {

            if (!(ip == null))
            {

                int timeout = 1000;
                string data = "Test Data!";
                Ping p = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true; byte[] buffer = Encoding.ASCII.GetBytes(data);
                PingReply reply = p.Send(ip, timeout, buffer, options);
                if (reply.Status == IPStatus.Success) return true; else return false;
            }
            else return false;

        }
        public void run(string str)
        {
            CheckBox[] Checkclear = { ENTRY1, EXIT1, ENTRY2, EXIT2, ENTRY3, EXIT3, ENTRY4, EXIT4, ENTRY5, EXIT5, ENTRY6, EXIT6, ENTRY7, EXIT7, ENTRY8, EXIT8, LBENTRY1, LBENTRY2, LBENTRY3, LBEXIT1, LBEXIT2, LBEXIT3, SENTRY, SEXIT, SENTRY2, SEXIT2, SENTRY3, SEXIT3, SENTRY4, SEXIT4, SENTRY5, SEXIT5, SENTRY6, SEXIT6, SENTRY7, SEXIT7 };

            foreach (CheckBox clear in Checkclear)
            {

                if (clear.Visible && clear.Checked) //check which barrier needs to trigger
                {
                    string keyname = listBox1.SelectedItem.ToString() + clear.Name.ToString();
                    //  int result1 = SNMP_SET(Getv[i], 161, arraymib[i], adventnet.snmp.snmp2.SnmpAPI.INTEGER, "1", "private"); getlabel(Checkclear[i].Name).ForeColor = Color.FromKnownColor(KnownColor.Green);
                    string ip = GetValue(listBox1.SelectedItem.ToString() + clear.Name.ToString() + "IP");
                    string rely = getMib(GetValue(listBox1.SelectedItem.ToString() + clear.Name.ToString() + "RELY"));
                    if (Ping(ip))

                        if (str == "open")
                        {

                            int result = SNMP_SET(ip, 161, rely, adventnet.snmp.snmp2.SnmpAPI.INTEGER, "1", "private");
                            LogClass.WirteLine("ip=" + ip + ",port=161,mib=" + rely + ",adventnet.snmp.snmp2.SnmpAPI.INTEGER=" + adventnet.snmp.snmp2.SnmpAPI.INTEGER + ",setvalue=1,community=private");
                            if (!(listBox2.Items.Contains(keyname)))
                                listBox2.Items.Add(keyname);

                            clear.Checked = false;

                        }
                        else
                        {
                            int result = SNMP_SET(ip, 161, rely, adventnet.snmp.snmp2.SnmpAPI.INTEGER, "0", "private");
                            LogClass.WirteLine("ip=" + ip + ",port=161,mib=" + rely + ",adventnet.snmp.snmp2.SnmpAPI.INTEGER=" + adventnet.snmp.snmp2.SnmpAPI.INTEGER + ",setvalue=1,community=private");
                            //    clear.ForeColor = System.Drawing.SystemColors.Control;
                            clear.Checked = false;
                            if (listBox2.Items.Contains(keyname))
                                listBox2.Items.Remove(keyname);

                        } //check is open or close
                          //   int result = SNMP_SET(Getv[i], 161, arraymib[i], adventnet.snmp.snmp2.SnmpAPI.INTEGER, "1", "private"); getlabel(Checkclear[i].Name).ForeColor = Color.FromKnownColor(KnownColor.Green);

                    else
                    { MessageBox.Show("Ping command can't get reply from IP : " + ip); }

                } // check if selected and visible

            } // read all check box 


        }   //main method
        private void button1_Click(object sender, EventArgs e)
        {
            run("open"); //run  opem barrier

        }
        private void button2_Click(object sender, EventArgs e)
        {
            run("close");
        }
        public void setdefault()
        {
            CheckBox[] Checkclear = { ENTRY1, EXIT1, ENTRY2, EXIT2, ENTRY3, EXIT3, ENTRY4, EXIT4, ENTRY5, EXIT5, ENTRY6, EXIT6, ENTRY7, EXIT7, ENTRY8, EXIT8, LBENTRY1, LBENTRY2, LBENTRY3, LBEXIT1, LBEXIT2, LBEXIT3, SENTRY, SEXIT, SENTRY2, SEXIT2, SENTRY3, SEXIT3, SENTRY4, SEXIT4, SENTRY5, SEXIT5, SENTRY6, SEXIT6, SENTRY7, SEXIT7 };
            foreach (CheckBox clear in Checkclear)
            {

                clear.Checked = false;
                clear.Visible = false;

            }
        }
        public string getMib(string point) //mib for barrier controller
        {
            Dictionary<string, string> it = new Dictionary<string, string>();
            it.Add("1", ".1.3.6.1.4.1.19865.1.2.1.1.0");
            it.Add("2", ".1.3.6.1.4.1.19865.1.2.1.2.0");
            it.Add("3", ".1.3.6.1.4.1.19865.1.2.1.3.0");
            it.Add("4", ".1.3.6.1.4.1.19865.1.2.1.4.0");
            it.Add("5", ".1.3.6.1.4.1.19865.1.2.1.5.0");
            it.Add("6", ".1.3.6.1.4.1.19865.1.2.1.6.0");
            it.Add("7", ".1.3.6.1.4.1.19865.1.2.1.7.0");
            it.Add("8", ".1.3.6.1.4.1.19865.1.2.1.8.0");
            it.Add("9", ".1.3.6.1.4.1.19865.1.2.2.1.0");
            it.Add("10", ".1.3.6.1.4.1.19865.1.2.2.2.0");
            it.Add("11", ".1.3.6.1.4.1.19865.1.2.2.3.0");
            it.Add("12", ".1.3.6.1.4.1.19865.1.2.2.4.0");
            it.Add("13", ".1.3.6.1.4.1.19865.1.2.2.5.0");
            it.Add("14", ".1.3.6.1.4.1.19865.1.2.2.6.0");
            it.Add("15", ".1.3.6.1.4.1.19865.1.2.2.7.0");
            it.Add("16", ".1.3.6.1.4.1.19865.1.2.2.8.0");
            if (it.ContainsKey(point))
                return it[point];
            else
                return it["1"];


        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {

            }
            else
            {
                if (listBox1.SelectedIndex == -1)
                {
                    setdefault(); listBox1.SelectedIndex = 0;
                }
                setdefault();
                //  MessageBox.Show(listBox1.SelectedIndex.ToString());
                string y = (string)listBox1.SelectedItem;
                //    MessageBox.Show(y);
                string path = Application.StartupPath + "\\system.xml";

                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.SelectSingleNode("CARPARK");
                XmlNodeList childkey = root.ChildNodes;

                XmlNode carpark = root.SelectSingleNode(y);
                XmlNodeList station = carpark.ChildNodes;
                CheckBox[] Checkclear = { ENTRY1, EXIT1, ENTRY2, EXIT2, ENTRY3, EXIT3, ENTRY4, EXIT4, ENTRY5, EXIT5, ENTRY6, EXIT6, ENTRY7, EXIT7, ENTRY8, EXIT8, LBENTRY1, LBENTRY2, LBENTRY3, LBEXIT1, LBEXIT2, LBEXIT3, SENTRY, SEXIT, SENTRY2, SEXIT2, SENTRY3, SEXIT3, SENTRY4, SEXIT4, SENTRY5, SEXIT5, SENTRY6, SEXIT6, SENTRY7, SEXIT7 };
                foreach (XmlNode x in station)
                {
                    foreach (CheckBox ch in Checkclear)
                    {
                        if (ch.Text == x.Name)
                        {
                            ch.Visible = true;

                        }
                    }
                }
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            BarrierRemote3 frm3 = new BarrierRemote3(this);
            frm3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete this data", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (listBox1.Items.Count == 0)
                {

                }
                else
                {
                    string y = listBox1.SelectedItem.ToString();
                    string path = Application.StartupPath + "\\system.xml";

                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode root = doc.SelectSingleNode("CARPARK");
                    // XmlNodeList childkey = root.ChildNodes;
                    XmlNode carpark = root.SelectSingleNode(y);

                    root.RemoveChild(carpark);
                    this.listBox1.Items.Remove(listBox1.SelectedItem);
                    // listBox1.SelectedIndex = 0;
                    doc.Save(path);
                    setdefault();
                }
            }

        }

        private string GetValue(string key)//Get Value From Configfile.
        {

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {


                MessageBox.Show("Set IP And Relay Before Run");
                this.Close();
                Application.Exit();
                return "127.0.0.1";
            }
            else
                return config.AppSettings.Settings[key].Value;

        }

        public int SelectedIndex { get; set; }



        private void OpenFrm2(string x)
        {

            BarrierRemote2 br2 = new BarrierRemote2(listBox1.SelectedItem.ToString() + x);
            br2.ShowDialog();

        }

        private void Set_ENTRY1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("ENTRY1");
            }
        }

        private void Set_ENTRY2(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("ENTRY2");
            }


        }
        private void Set_ENTRY3(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("ENTRY3");
            }


        }
        private void Set_ENTRY4(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("ENTRY4");
            }


        }
        private void Set_ENTRY5(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("ENTRY5");
            }


        }
        private void Set_ENTRY6(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("ENTRY6");
            }


        }
        private void Set_ENTRY7(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("ENTRY7");
            }


        }
        private void Set_ENTRY8(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("ENTRY8");
            }


        }

        //private void Set_EXIT1(object sender, KeyEventArgs e)
        //{

        //    if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
        //    {
        //        OpenFrm2("EXIT1");
        //    }


        //}
        private void Set_EXIT2(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("EXIT2");
            }


        }
        private void Set_EXIT3(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("EXIT3");
            }


        }
        private void Set_EXIT4(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("EXIT4");
            }


        }
        private void Set_EXIT5(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("EXIT5");
            }


        }
        private void Set_EXIT6(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("EXIT6");
            }


        }
        private void Set_EXIT7(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("EXIT7");
            }


        }
        private void Set_EXIT8(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("EXIT8");
            }


        }
        private void Set_SENTRY(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SENTRY");
            }


        }
        private void SEXIT_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SEXIT");
            }


        }
        private void LBEXIT1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("LBEXIT1");
            }


        }
        private void LBENTRY1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("LBENTRY1");
            }


        }
        private void LBENTRY2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("LBENTRY2");
            }


        }
        private void LBENTRY3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("LBENTRY3");
            }


        }
        private void LBEXIT2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("LBEXIT2");
            }


        }
        private void LBEXIT3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("LBEXIT3");
            }


        }

        private void EXIT1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("EXIT1");
            }
        }

        private void SENTRY2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SENTRY2");
            }
        }

        private void SEXIT2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SEXIT2");
            }
        }

        private void SENTRY3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SENTRY3");
            }
        }

        private void SEXIT3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SEXIT3");
            }
        }

        private void SENTRY4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SENTRY4");
            }
        }

        private void SEXIT4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SEXIT4");
            }
        }

        private void SENTRY5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SENTRY5");
            }
        }

        private void SEXIT5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SEXIT5");
            }
        }

        private void SENTRY6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SENTRY6");
            }
        }

        private void SEXIT6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SEXIT6");
            }
        }

        private void SENTRY7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SENTRY7");
            }
        }

        private void SEXIT7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Alt)
            {
                OpenFrm2("SEXIT7");
            }
        }
    }//Form1 Class


}// main