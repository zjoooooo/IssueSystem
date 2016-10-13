using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;

namespace IssueSystem
{
    public partial class InputAttenderList : Form
    {
        CreateModifyAttenderList cmc;
        public InputAttenderList(CreateModifyAttenderList cmc)
        {
            InitializeComponent();
            this.cmc = cmc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string dep = comboBox1.Text.Trim();
            string company = comboBox2.Text.Trim();
            string connectionstr = cmc.constr;
            string SearchCmd = "select * from carpark.dbo.StaffType";
            DataSet ds =null;
            DataTable dt = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, SearchCmd);
                dt = ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("System Can't Get Staff List");
            }

            Boolean flag = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Staff"].ToString() == name)
                {
                    flag = true;break;
                }
            }

            dt.Dispose();
            ds.Dispose();

            if (!flag)
            {

                    SqlParameter[] para = new SqlParameter[]
                    {
                        new SqlParameter("@name",name),  
                        new SqlParameter("@dep",dep),    
                        new SqlParameter("@company",company)
                    };

                    string CommandText = "insert into [carpark].[dbo].[StaffType](Staff,Dep,Company)values(@name,@dep,@company);";
                    try
                    {
                        SqlHelper.ExecuteNonQuery(connectionstr, CommandType.Text, CommandText, para);
                        MessageBox.Show("Add Staff : "+name+" Ok");
                        cmc.GetList();
                        this.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Can't Add New Staff : "+name);
                    }
             
            }
            else
            { MessageBox.Show(name+" Already exist"); }
          

         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputIssueList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'list.Dep_list' table. You can move, or remove it, as needed.
            this.dep_listTableAdapter.Fill(this.list.Dep_list);
            // TODO: This line of code loads data into the 'list.Company_list' table. You can move, or remove it, as needed.
            this.company_listTableAdapter.Fill(this.list.Company_list);

        }


    }
}
