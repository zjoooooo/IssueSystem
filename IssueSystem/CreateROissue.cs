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
    public partial class CreateROissue : Form
    {
        Main main;
        DataSet CarparkDs = null;
        public CreateROissue(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void CreateROissue_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = @"CARPARK LOCATION:"+"\n\n"+"NATURE OF COMPLAINT:"+"\n\n"+"FEEDBACK:"+"\n\n";
            GetList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarparkDs.Dispose();
            this.Close();
        }
        private void GetList()
        {
            #region  //Get List
            string cmd = @"select name from carpark.dbo.Whole;
                           select Staff from carpark.dbo.StaffType;
                           select Staff from carpark.dbo.staffType;";

            try
            {
                CarparkDs = SqlHelper.ExecuteDataset(main.constr, CommandType.Text, cmd);

            }
            catch (SqlException)
            { MessageBox.Show("Can't Get Carpark ListTable"); }
            CarparkListCombo.DataSource = CarparkDs.Tables[0];
            CarparkListCombo.DisplayMember = "name";
            CCListCombo.DataSource = CarparkDs.Tables[1];
            CCListCombo.DisplayMember = "Staff";
            RoListCombo.DataSource = CarparkDs.Tables[2];
            RoListCombo.DisplayMember = "Staff";
            #endregion         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region //save data
            string cmd = @"
                        insert into carpark.dbo.IllegalParkingTable
                       (CarPark,CptaStaff,SpccStaff,RO,ReportToCPTA,TimeGiven,TimeOnSite,ROAcualTimeOnSite,TimeCompletion,Details,LastModifyBy,LastModifyDate,Status)values
                       (@CarPark,@CptaStaff,@SpccStaff,@RO,@ReportToCPTA,@TimeGiven,@TimeOnSite,@ROAcualTimeOnSite,@TimeCompletion,@Details,@LastModifyBy,convert(varchar(19),getdate(),120),@Status);";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CarPark",CarparkListCombo.Text.Trim()),
                new SqlParameter("@CptaStaff",textBox1.Text.Trim()),
                new SqlParameter("@SpccStaff",CCListCombo.Text.Trim()),
                new SqlParameter("@RO",RoListCombo.Text.Trim()),
                new SqlParameter("@ReportToCPTA",textBox2.Text.Trim()),
                new SqlParameter("@TimeGiven",TimeGivenPicker.Value),
                new SqlParameter("@TimeOnSite",TimeSitePicker.Value),
                new SqlParameter("@ROAcualTimeOnSite",RoRealTimepicker.Value),
                new SqlParameter("@TimeCompletion",TimeCompletion.Value),
                new SqlParameter("@Details",richTextBox1.Text.Trim()),
                new SqlParameter("@LastModifyBy",main.loginuser),
             //   new SqlParameter("@LastModifyDate","getdate()"),
                new SqlParameter("@Status","Open")
            };
            try
            {
                SqlHelper.ExecuteNonQuery(main.constr, CommandType.Text,cmd,para);
                MessageBox.Show("Save Ok");
                main.FirstFresh();
                CarparkDs.Dispose();
                this.Close();
            }
            catch (SqlException)
            { MessageBox.Show("Can't Save Data"); }
            #endregion
        }

    }
}
