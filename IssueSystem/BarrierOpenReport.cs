using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IssueSystem
{
    public partial class BarrierOpenReport : Form
    {
        Dictionary<string,string> ReportPC = new Dictionary<string,string>();
        public BarrierOpenReport()
        {
            InitializeComponent();
        }

        private void BarrierOpenReport_Load(object sender, EventArgs e)
        {
            batch_combo.SelectedIndex = 0;
            // TODO: This line of code loads data into the 'SunparkCentralDataSet.remote_control_history' table. You can move, or remove it, as needed.
            //this.remote_control_historyTableAdapter.Fill(this.SunparkCentralDataSet.remote_control_history);
            // this.reportViewer1.RefreshReport();
        }
         
        private void Init()
        {
            ReportPC.Clear();
            ReportPC.Add("B26BBCL", "192.168.1.41");
            ReportPC.Add("B28B30", "10.4.127.242");
            ReportPC.Add("AMK", "192.168.1.38");
            ReportPC.Add("HGJE", "192.168.1.35");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
            string batch = batch_combo.Text.ToString();
            //Thread thr = new Thread(() => Run(ReportPC[batch].ToString(),Start_Date_picker.Value,End_date_picker.Value));
            //thr.Start();
            Run(ReportPC[batch].ToString(), Start_Date_picker.Value, End_date_picker.Value);
        }

        private void Run(string batchip,DateTime start, DateTime end)
        {
            string constr = "Data Source="+ batchip + ";uid=sa;pwd=yzhh2007;database=SunparkCentral";
            string cmd = $"select * from remote_control_history where action_name in ('Open Barrier','MOpen Barrier') and action_dt between @start and @end order by action_dt";
            DataSet ds = null;
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@start",start.ToString("yyyy-MM-dd 00:00:00")),
                new SqlParameter("@end",end.ToString("yyyy-MM-dd 23:59:59"))
            };            
            try
            {
                ds = SqlHelper.ExecuteDataset(constr,CommandType.Text,cmd, para);
            }catch(SqlException e)
            {
                LogClass.WirteLine($"Fail to read from central report pc {batchip}");
                MessageBox.Show($"Fail to read from central report pc {batchip},please make sure it's online.");
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.reportViewer1.Reset();
                ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.ReportPath = "BarrierOpenReport.rdlc";
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
