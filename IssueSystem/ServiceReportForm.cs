using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IssueSystem
{
    public partial class ServiceReportForm : Form
    {
        private ServiceReport sr;

        //public ServiceReportForm()
        //{
        //    this.sr = sr1;
        //}
        public ServiceReportForm(ServiceReport sr)
        {
            InitializeComponent();
            this.sr = sr;
        }        
        private void Form2_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void InitForm()
        {

            Followupby.Text = "Follow up by : "+sr.Followby;
            Useditem.Text = "Used item : " + sr.Item;
            Itemqty.Text = "Item qty : " + sr.Itemqty;
            Solutionsubmitby.Text = "Solution submit by : " + sr.Submitby;
            Starttime.Text = "Start time : " + sr.Starttime;
            Endtime.Text = "End time : " + sr.Endtime;
            Reportsubmittime.Text = "Report submit time : " + sr.Reportsubmittime;
            solution.Text = sr.Solution;
            if (sr.Otstarttime == "01/01/1900 00:00:00")
            {

            }
            else
            {
                Otstarttime.Text = "Ot start time : " + sr.Otstarttime;
            }

            if (sr.Otendtime == "01/01/1900 00:00:00")
            {

            }
            else
            {
                OtEndtime.Text = "Ot end time : " + sr.Otendtime;
            }
            
           
          

        } 

        private void Close1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
