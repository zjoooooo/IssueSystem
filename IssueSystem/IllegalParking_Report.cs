using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace IssueSystem
{
    public partial class IllegalParking_Report : Form
    {
        public IllegalParking_Report()
        {
            InitializeComponent();
        }
     

        private void IllegalParking_Report_Load(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(dateTimePicker3.Value.ToString("yyyy-MM-dd ") + "00:00:00");
            DateTime end = Convert.ToDateTime(dateTimePicker4.Value.ToString("yyyy-MM-dd ") + "23:59:59");
            this.IllegalParkingTableTableAdapter.Fill(this.carparkDataSet.IllegalParkingTable, start, end);
            this.reportViewer1.RefreshReport();
        }
    }
}
