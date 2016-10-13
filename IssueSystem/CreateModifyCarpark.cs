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
    public partial class CreateModifyCarpark : Form
    {
        Main main;
        DataSet ds = null;     
        DataSet ds1 = null;
        public string constr = null;
        public CreateModifyCarpark(Main main)
        {
            this.main = main;
            this.constr = main.constr;
            InitializeComponent();
        }

        private void CreateModifyCarpark_Load(object sender, EventArgs e)
        {
            GetList();

        }

        public void GetList()
        {
             string CommandText = "select name,ip from carpark.dbo.Whole";
             string CommandText1 = "select name,ip from carpark.dbo.Whole where batch not in('IPD','commercial')";
             try
             {
                 ds = SqlHelper.ExecuteDataset(main.constr, CommandType.Text, CommandText);
                 ds1 = SqlHelper.ExecuteDataset(main.constr, CommandType.Text, CommandText1);
                 label2.Text = ds1.Tables[0].Rows.Count + " HDB Car Park,And " + ds.Tables[0].Rows.Count + " Total Car Park.";
             }
             catch (SqlException)
             {
                 MessageBox.Show("can't get carpark list");
             }
            dataGridView1.DataSource = ds.Tables[0];
          
        }


        private void button1_Click(object sender, EventArgs e)
        {
            InputCarpark ic = new InputCarpark(this);
            ic.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if((dataGridView1.CurrentRow.Index <0)||(dataGridView1.Rows.Count < 0)){
                return;
            }
            int row = dataGridView1.CurrentRow.Index;
            string CarPark = dataGridView1.Rows[row].Cells["name"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + CarPark+" from list?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int count = dataGridView1.CurrentRow.Index;
                if (count == -1)
                {
                    MessageBox.Show("You Must Select a Item Before Delete");
                }
                else
                {
                    string carpark = dataGridView1.Rows[count].Cells[0].Value.ToString();
                    string ip = dataGridView1.Rows[count].Cells[1].Value.ToString();

                    string CommandText = @"delete from carpark.dbo.Whole where name=@name and ip=@ip;";
                    SqlParameter[] para = new SqlParameter[]
                    {
                        new SqlParameter("@name",carpark),
                        new SqlParameter("@ip",ip)
                    };
                    try
                    {
                        SqlHelper.ExecuteNonQuery(main.constr, CommandType.Text, CommandText, para);
                        GetList();
                        MessageBox.Show(carpark + " Delete OK");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(carpark + " Delete Fail");
                    }


                }
            }
        }

        private void CreateModifyCarpark_FormClosed(object sender, FormClosedEventArgs e)
        {
            ds1.Dispose();
            ds.Dispose();
        }


    }
}
