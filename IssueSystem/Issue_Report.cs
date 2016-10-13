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
    public partial class Issue_Report : Form
    {
        public Issue_Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carparkDataSet.IssueTable' table. You can move, or remove it, as needed.
           // this.IssueTableTableAdapter.Fill(this.carparkDataSet.IssueTable);

            Load_Data();
        }

        private void Load_Data()
        {
            string connectionstr = "Data Source=172.16.1.89;uid=secure;pwd=weishenme;database=carpark";
            string Command = @"select name from [carpark].[dbo].[Whole];                         
                               select IssueName from [carpark].[dbo].[IssueType];
                               select Staff from [carpark].[dbo].[StaffType];
                               select Staff from [carpark].[dbo].[StaffType];
                               select batch from BatchTable;
                            ";
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, Command);    //execute
            CarPark_Combo.DataSource = ds.Tables[0];                   //Carpark name list
            CarPark_Combo.DisplayMember = "name";
            CarPark_Combo.Text = "";

            IssueType_Combo.DataSource = ds.Tables[1];             //issue list
            IssueType_Combo.DisplayMember = "IssueName";
            IssueType_Combo.Text = "";

            SolvedBy_Combo.DataSource = ds.Tables[2];           //Solved By
            SolvedBy_Combo.DisplayMember = "Staff";
            SolvedBy_Combo.Text = "";

            Attender_Combo.DataSource = ds.Tables[3];           //Attender
            Attender_Combo.DisplayMember = "Staff";
            Attender_Combo.Text = "";

            Batch_Combo.DataSource = ds.Tables[4];
            Batch_Combo.DisplayMember = "batch";
            Batch_Combo.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportThread();
        }

        private void ReportThread()
        {
            string carpark_cmd = "Carpark=@carpark";
            string issue_cmd = "Issue=@issue";
            string solver = "DoneBy=@doneby";
            string timing = "ReportTime between @start and @end";
            string attendBy = @"(AttendBy=@name or  
                                AttendBy2=@name or  
                                AttendBy3=@name)";
            string batch = "Batch=@batch";

            if (String.IsNullOrEmpty(CarPark_Combo.Text.Trim()))
            {
                carpark_cmd = "1=1";
            }
            if (String.IsNullOrEmpty(IssueType_Combo.Text.Trim()))
            {
                issue_cmd = "1=1";
            }
            if (String.IsNullOrEmpty(SolvedBy_Combo.Text.Trim()))
            {
                solver = "1=1";
            }

            if (String.IsNullOrEmpty(Attender_Combo.Text.Trim()))
            {
                attendBy = "1=1";
            }

            if (String.IsNullOrEmpty(Batch_Combo.Text.Trim()))
            {
                batch = "1=1";
            }


            string connectionstr = "Data Source=172.16.1.89;uid=secure;pwd=weishenme;database=carpark";
            string cmd = @"SELECT * FROM dbo.IssueTable where " + carpark_cmd + @" and 
                                                              " + issue_cmd + @" and 
                                                              " + solver + @" and  
                                                              " + attendBy + @" and 
                                                              " + batch + @" and 
                                                              " + timing + @" order by ReportTime";
            //    string cmd = @"SELECT * FROM dbo.IssueTable where ReportTime between '2015-06-01 00:00:00' and '2015-07-01 23:59:59'";
            string start = dateTimePicker1.Value.ToString("yyyy-MM-dd ") + "00:00:00";
            string end = dateTimePicker2.Value.ToString("yyyy-MM-dd ") + "23:59:59";

            SqlParameter[] para = new SqlParameter[] {                                        
                     new SqlParameter("@carpark",CarPark_Combo.Text.Trim()),
                     new SqlParameter("@issue",IssueType_Combo.Text.Trim()),
                     new SqlParameter("@doneby",SolvedBy_Combo.Text.Trim()),
                     new SqlParameter("@start",start),
                     new SqlParameter("@end",end),
                     new SqlParameter("@name",Attender_Combo.Text.Trim()),
                     new SqlParameter("@batch",Batch_Combo.Text.Trim())
            };

            DataSet ds = null;
            ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, cmd, para);

            if (ds.Tables[0].Rows.Count > 0)
            {

                this.reportViewer1.Reset();
                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.ReportPath = "Issue_Report.rdlc";
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("No data.");
            }

        
            
        }
    }
}
