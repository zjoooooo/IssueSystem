﻿using System;
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

namespace IssueSystem
{
    public partial class SecureStaffDelete : Form
    {
        Dictionary<string, string> carpark = new Dictionary<string, string>();
        delegate void LabelDelegate(string content, int i);
        delegate void PrograDelegate();
        delegate void BtnDelegate();
        Thread thr = null;
        public SecureStaffDelete(Main main)
        {
            this.carpark = main.carparklist;
            InitializeComponent();

        }
        private void Form2_Load(object sender, EventArgs e)
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
                label3.Text = content;
            }
            else if (i == 2)
            {
                label4.Text = content;
            }

        }
        private bool CheckValue()
        {
            string x = rIUtxt.Text.Trim();
            string y = IUtxt.Text.Trim();
            if ((((x == y) && (x.Length == 10)))&&(ToolsUtility.CheckValue(plate.Text.Trim(),rplate.Text.Trim())))
                return true;
            else
                return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pBar1.Minimum = 1;
            pBar1.Maximum = carpark.Count;
            pBar1.Value = 1;
            pBar1.Step = 1;

            if (button1.Text == "Start")
            {               
                if (CheckValue())
                {                    
                    thr = new Thread(() => ThreadDelete(IUtxt.Text.Trim(),plate.Text.Trim()));
                    thr.Start();
                    button1.Text = "Stop";
                }
                else
                {
                    MessageBox.Show("IU or plate Format Incorrect");
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
        private void ThreadDelete(string IU,string plate)
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
                    DBUtility.DeleteStaffIU(IU,plate,kv.Key, kv.Value);
                }
                this.Invoke(Progra);
                i++;

            }
            this.Invoke(btn);
        }

        private void SecureStaffDelete_FormClosed(object sender, FormClosedEventArgs e)
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

