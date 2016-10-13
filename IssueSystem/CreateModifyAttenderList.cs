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
    public partial class CreateModifyAttenderList : Form
    {
        Main main;
        DataSet ds = null;
        DataTable dt = null;
        public string constr;
        public CreateModifyAttenderList(Main main)
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
            string CommandText = "select * from carpark.dbo.StaffType";
             ds = SqlHelper.ExecuteDataset(main.constr, CommandType.Text, CommandText);
             dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
          
        }


        private void button1_Click(object sender, EventArgs e)
        {
            InputAttenderList ic = new InputAttenderList(this);
            ic.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete this data", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int count = dataGridView1.CurrentRow.Index;
                if (count == -1)
                {
                    MessageBox.Show("You Must Select Item Before Delete");
                }
                else
                {
                    string staff = dataGridView1.Rows[count].Cells[0].Value.ToString();
                 //   string ip = dataGridView1.Rows[count].Cells[1].Value.ToString();

                    string CommandText = @"delete from carpark.dbo.StaffType where Staff=@staff;";
                    SqlParameter[] para = new SqlParameter[]
                    {
                        new SqlParameter("@staff",staff),               
                    };
                    try
                    {
                        SqlHelper.ExecuteNonQuery(main.constr, CommandType.Text, CommandText, para);
                        GetList();
                        MessageBox.Show(staff + " Delete OK");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(staff + " Delete Fail");
                    }


                }
            }
        }

        private void CreateModifyCarpark_FormClosed(object sender, FormClosedEventArgs e)
        {
            dt.Dispose();
            ds.Dispose();
        }
    }
}
