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
    public partial class ServiceReports : Form
    {
        public ServiceReports()
        {
            InitializeComponent();
        }

        private void ServiceReports_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'carparkDataSet1.SRtable' table. You can move, or remove it, as needed.
            //this.SRtableTableAdapter.Fill(this.carparkDataSet1.SRtable);

            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             ReportThread();
        }

        private void ReportThread()
        {
            string start = dateTimePicker1.Value.ToString("yyyy-MM-dd ") + "00:00:00";
            string end = dateTimePicker2.Value.ToString("yyyy-MM-dd ") + "23:59:59";
            string connectionstr = "Data Source=172.16.1.89;uid=secure;pwd=weishenme;database=carpark";
            string cmd = "select * from SRtable where posttime between @start and @end";
            SqlParameter[] para = new SqlParameter[] {                                        
                     new SqlParameter("@start",start),
                     new SqlParameter("@end",end)
            };
            DataSet ds = null;
            try
            {
                ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, cmd, para);
            }catch(SqlException sqle){
                LogClass.WirteLine("Generate SRtable error :"+sqle.ToString());
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.reportViewer1.Reset();
                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.ReportPath = "ServiceReports.rdlc";
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }else{
                MessageBox.Show("No data.");
            }

        }
    }
}
