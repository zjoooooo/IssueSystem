using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IssueSystem
{
    public partial class ModifyROissue : Form
    {
        private Main main;
        private string ID;
        DataSet ds = null;
        public ModifyROissue(Main main,string ID)
        {
            InitializeComponent();
            this.main = main;
            this.ID = ID;
        }

        private void CreateROissue_Load(object sender, EventArgs e)
        {
           
            string cmd = @"select CarPark,Status,CptaStaff,SpccStaff,RO,Details,ReportToCPTA,TimeGiven,TimeOnSite,ROAcualTimeOnSite,TimeCompletion from [carpark].[dbo].[IllegalParkingTable] where @ID=ID order by TimeGiven DESC
                           select Staff from carpark.dbo.StaffType
                           select Staff from carpark.dbo.StaffType
                           select name from carpark.dbo.Whole";
            try
            {
                ds=SqlHelper.ExecuteDataset(main.constr, CommandType.Text,cmd,new SqlParameter("@ID",ID));
            }
            catch(SqlException)
            {
                MessageBox.Show("Can't read information from ID :"+ID);
            }
            string carpark = ds.Tables[0].Rows[0][0].ToString();
            string Status =StatusCombo.Text= ds.Tables[0].Rows[0][1].ToString();
            string CptaStaff =textBox1.Text= ds.Tables[0].Rows[0][2].ToString();
            string SpccStaff = ds.Tables[0].Rows[0][3].ToString();
            string RO = ds.Tables[0].Rows[0][4].ToString();
            string Details =richTextBox1.Text= ds.Tables[0].Rows[0][5].ToString();
            string ReportToCPTA =textBox2.Text=ds.Tables[0].Rows[0][6].ToString();
            string TimeGiven =TimeGivenPicker.Text= ((DateTime)ds.Tables[0].Rows[0][7]).ToString("yyyy-MM-dd HH:mm:ss");
            string TimeOnSite =TimeSitePicker.Text=((DateTime)ds.Tables[0].Rows[0][8]).ToString("yyyy-MM-dd HH:mm:ss");
            string ROAcualTimeOnSite = RoRealTimepicker.Text = ((DateTime)ds.Tables[0].Rows[0][9]).ToString("yyyy-MM-dd HH:mm:ss");
            string TimeCompletion = dateTimePicker1.Text=((DateTime)ds.Tables[0].Rows[0][10]).ToString("yyyy-MM-dd HH:mm:ss");

            CCListCombo.DataSource = ds.Tables[1];
            CCListCombo.DisplayMember = "Staff";
            RoListCombo.DataSource = ds.Tables[2];
            RoListCombo.DisplayMember = "Staff";
            CarparkListCombo.DataSource = ds.Tables[3];
            CarparkListCombo.DisplayMember = "name";


            for (int i = 0; i < CCListCombo.Items.Count; i++)
            {
                DataRowView dr = (DataRowView)CCListCombo.Items[i];
                if (dr["Staff"].ToString() == SpccStaff)
                { CCListCombo.SelectedIndex = i; break; }

            }

            for (int i = 0; i < RoListCombo.Items.Count; i++)
            {
                DataRowView dr = (DataRowView)RoListCombo.Items[i];
                if (dr["staff"].ToString() == RO)
                { RoListCombo.SelectedIndex = i; break; }

            }

            for (int i = 0; i < CarparkListCombo.Items.Count; i++)
            {
                DataRowView dr = (DataRowView)CarparkListCombo.Items[i];
                if (dr["name"].ToString() == carpark)
                { CarparkListCombo.SelectedIndex = i; break; }

            }
            if (main.level == 2)
            {
                CarparkListCombo.Enabled = false;
                CCListCombo.Enabled = false;
                RoListCombo.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                richTextBox1.Enabled = false;
                TimeGivenPicker.Enabled = false;
                RoRealTimepicker.Enabled = false;
                TimeSitePicker.Enabled = false;
                dateTimePicker1.Enabled = false;
                button1.Enabled = false;
                //    MessageBox.Show("这里是权限2");
            }
            else
            {
                CarparkListCombo.Enabled = false;
                CCListCombo.Enabled = false;
                textBox1.Enabled = false;
                TimeGivenPicker.Enabled = false;
                
                if (Status == "Closed")
                {                    
             //     MessageBox.Show("这里是0或1 下的关闭状态");
                    CarparkListCombo.Enabled = false;
                    CCListCombo.Enabled = false;
                    RoListCombo.Enabled = false;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    richTextBox1.Enabled = false;
                    TimeGivenPicker.Enabled = false;
                    RoRealTimepicker.Enabled = false;
                    TimeSitePicker.Enabled = false;
                    dateTimePicker1.Enabled = false;
                }
            }
                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //select CarPark,Status,CptaStaff,SpccStaff,RO,Details,ReportToCPTA,TimeGiven,TimeOnSite,ROAcualTimeOnSite,TimeCompletion from [carpark].[dbo].[IllegalParkingTable] where @ID=ID order by TimeGiven DESC
            string CommandText = @"Update [carpark].[dbo].[IllegalParkingTable] set CarPark=@CarPark,Status=@Status,
                                       CptaStaff=@CptaStaff,SpccStaff=@SpccStaff,RO=@RO,Details=@Details,
                                       ReportToCPTA=@ReportToCPTA,TimeGiven=@TimeGiven,TimeOnSite=@TimeOnSite,
                                       ROAcualTimeOnSite=@ROAcualTimeOnSite,TimeCompletion=@TimeCompletion,
                                       LastModifyDate=convert(varchar(19),getdate(),120),LastModifyBy=@LastModifyBy where ID=@ID";
            //TimeSpan t1 = new TimeSpan(DateTime.Parse(ActivatedTimePicker.Text).Ticks);
            //TimeSpan t2 = new TimeSpan(DateTime.Parse(AttendedTimePicker.Text).Ticks);
            //float RespondTime = (float)t2.Subtract(t1).TotalHours;
            //TimeSpan t3 = new TimeSpan(DateTime.Parse(ReportTimePicker.Text).Ticks);
            //TimeSpan t4 = new TimeSpan(DateTime.Parse(DoneTimePicker.Text).Ticks);
            //float downtime = (float)t4.Subtract(t3).TotalHours;
            SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@CarPark",CarparkListCombo.Text.Trim()),
                    new SqlParameter("@Status",StatusCombo.Text.Trim()),
                    new SqlParameter("@CptaStaff",textBox1.Text.Trim()),
                    new SqlParameter("@SpccStaff",CCListCombo.Text.Trim()),
                    new SqlParameter("@RO",RoListCombo.Text.Trim()),
                    new SqlParameter("@Details",richTextBox1.Text.Trim()),
                    new SqlParameter("@ReportToCPTA",textBox2.Text.Trim()),      
                    new SqlParameter("@TimeGiven",TimeGivenPicker.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@TimeOnSite",TimeSitePicker.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@ROAcualTimeOnSite",RoRealTimepicker.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@TimeCompletion",dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")),                 
                   // new SqlParameter("@LastModifyDate","getdate()"),
                    new SqlParameter("@LastModifyBy",main.loginuser),
                    new SqlParameter("@ID",ID)
                };
            try
            {
                SqlHelper.ExecuteNonQuery(main.constr, CommandType.Text, CommandText, parameter);
                MessageBox.Show("Update Ok");
                main.FirstFresh();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Can't update case");
            }
            
        }

        private void StatusCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StatusCombo.Text == "Open")
            {
                RoListCombo.Enabled = true;
                textBox2.Enabled = true;
                richTextBox1.Enabled = true;            
                RoRealTimepicker.Enabled = true;
                TimeSitePicker.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
            else if (StatusCombo.Text == "Closed")
            {
                CarparkListCombo.Enabled = false;
                CCListCombo.Enabled = false;
                RoListCombo.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                richTextBox1.Enabled = false;
                TimeGivenPicker.Enabled = false;
                RoRealTimepicker.Enabled = false;
                TimeSitePicker.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
        }
    }
}
