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
    public partial class InputIssueList : Form
    {
        CreateModifyIssueList cmc;
        public InputIssueList(CreateModifyIssueList cmc)
        {
            InitializeComponent();
            this.cmc = cmc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string connectionstr = cmc.constr;
            string SearchCmd = "select IssueName from carpark.dbo.IssueType";
            DataSet ds =null;
            DataTable dt = null;

            try
            {
                ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, SearchCmd);
                dt = ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("System Can't Get Issue List");
            }

            Boolean flag = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IssueName"].ToString() == name)
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
                    };

                    string CommandText = "insert into [carpark].[dbo].[IssueType](IssueName)values(@name);";
                    try
                    {
                        SqlHelper.ExecuteNonQuery(connectionstr, CommandType.Text, CommandText, para);
                        MessageBox.Show("Add Issue:"+name+" Ok");
                        cmc.GetList();
                        this.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Can't Add New Issue");
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

        }


    }
}
