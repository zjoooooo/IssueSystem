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
using System.Net.NetworkInformation;
using System.Threading;


namespace IssueSystem
{
    public partial class SecureStaffUpdate : Form
    {
        private Dictionary<string, string> carpark = new Dictionary<string, string>();
        delegate void LabelDelegate(string content, int i);
        delegate void PrograDelegate();
        delegate void BtnDelegate();
        Thread thr = null;

        public SecureStaffUpdate(Main main)
        {
            InitializeComponent();
            this.carpark = main.carparklist;
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void BtnTxt()
        {
            button1.Text = "Start";
        }

        private void PrograStepup()
        {
            if (pBar1.Value < carpark.Count)
            {
                pBar1.Value++;
            }
        }

        private void LabelTxt(string content, int i)
        {
            if (i == 1)
            {
                label9.Text = content;
            }
            else if (i == 2)
            {
                label10.Text = content;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            pBar1.Minimum = 1;
            pBar1.Maximum = carpark.Count;
            pBar1.Step = 1;
            if (button1.Text == "Start")
            {
                string user = name.Text.Trim();
                if (ToolsUtility.CheckValue(IUtxt.Text.Trim(), rIUtxt.Text.Trim()) && ToolsUtility.CheckValue(plate.Text.Trim(), rplate.Text.Trim()) &&
                    ToolsUtility.CheckValue(name.Text.Trim(), rname.Text.Trim()))
                {
                    PmsVehicleClass pvc = new PmsVehicleClass();
                    pvc.IU = IUtxt.Text.Trim();
                    pvc.Plate = plate.Text.Trim();
                    pvc.Name = name.Text.Trim();
                    pvc.ExpiredDate = dateTimePicker1.Value.ToString("yyyy-MM-dd ")+"00:00:00";
                    thr = new Thread(() => ThreadAdd(pvc));
                    thr.Start();
                    button1.Text = "Stop";
                }
                else
                {
                    MessageBox.Show("IU or vehicle or name Format Incorrect");
                }
            }
            else if (button1.Text == "Stop")
            {
                if (thr != null)
                {
                    if (thr.IsAlive)
                    {
                        thr.Abort();
                    }
                }
                button1.Text = "Start";
            }
        }


        private void ThreadAdd(PmsVehicleClass pvc)
        {
            BtnDelegate btn = new BtnDelegate(BtnTxt);
            LabelDelegate label = new LabelDelegate(LabelTxt);
            PrograDelegate Progra = new PrograDelegate(PrograStepup);

            int i = 1;
            foreach (KeyValuePair<string, string> kv in carpark)
            {
                if (ToolsUtility.Ping(kv.Value))
                {
                    this.Invoke(label, kv.Key, 1);
                    this.Invoke(label, i.ToString() + "/" + carpark.Count.ToString(), 2);
                    DBUtility.AddStaffIU(pvc, kv.Key, kv.Value);
                }
                this.Invoke(Progra);
                i++;

            }
            this.Invoke(btn);
        }
    }
}

