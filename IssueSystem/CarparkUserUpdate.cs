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
    public partial class CarparkUserUpdate : Form
    {
        private Dictionary<string, string> carpark = new Dictionary<string, string>();
        Thread thr = null;
        delegate void LabelDelegate(string content, int i);
        delegate void PrograDelegate();
        delegate void BtnDelegate();
        public CarparkUserUpdate(Main main)
        {
            InitializeComponent();
            this.carpark = main.carparklist;
        }
        private void Form6_Load(object sender, EventArgs e)
        {

            label8.Text = label9.Text = null;
            pwdTxt.Text = nameTxt.Text = rnameTxt.Text = rpwdTxt.Text = null;
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
                label8.Text = content;
            }
            else if (i == 2)
            {
                label9.Text = content;
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            pBar1.Minimum = 1;
            pBar1.Maximum = carpark.Count;
            pBar1.Value = 1;
            pBar1.Step = 1;

            if (button1.Text == "Start")
            {
                PmsUserClass user = new PmsUserClass();

                if (ToolsUtility.CheckValue(nameTxt.Text.Trim(), rnameTxt.Text.Trim()) && ToolsUtility.CheckValue(pwdTxt.Text.Trim(), rpwdTxt.Text.Trim()))
                {
                    user.Name=nameTxt.Text.Trim();
                    user.Password = pwdTxt.Text.Trim();
                    user.Level = levelCombox.Text.Trim();
                    user.ExpiredDate = dateTimePicker1.Value.ToString("yyyy-MM-dd ") + "00:00:00";
                }
                else
                {
                    MessageBox.Show("Please check your username,password");
                    return;
                }
          //      MessageBox.Show(user.Name);
                thr = new Thread(() => ThreadAdd(user));
                thr.Start();
                button1.Text = "Stop";

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


        private void ThreadAdd(PmsUserClass user)
        {
            BtnDelegate btn = new BtnDelegate(BtnTxt);
            LabelDelegate label = new LabelDelegate(LabelTxt);
            PrograDelegate Progra = new PrograDelegate(PrograStepup);

            int i = 1;
            foreach (KeyValuePair<string, string> kv in carpark)
            {
                this.Invoke(label, kv.Key, 1);
                this.Invoke(label, i.ToString() + "/" + carpark.Count.ToString(), 2);
              //  LogClass.wirteLine("Carpark"+kv.Key+",IP:"+kv.Value);
                if (ToolsUtility.Ping(kv.Value.ToString()))
                {
                    DBUtility.AddUser(user, kv.Key, kv.Value);
                }                    
                this.Invoke(Progra);
                i++;
            }
            this.Invoke(btn);
        }

        private void CarparkUserUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thr != null)
            {
                if (thr.IsAlive)
                {
                    thr.Abort();
                }
            }
        }


    }
}

