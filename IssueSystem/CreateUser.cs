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
    public partial class UserControl : Form
    {
        Main main;
        public UserControl(Main main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = TxtUser.Text.Trim();
            string password = TxtPwd.Text.Trim();
            string Cpassword = TxtCpwd.Text.Trim();
            string level = ComboLevel.Text;
            DateTime exp = DateTime.Parse(ExpDate.Text);

            if ((username != "") && (password == Cpassword) && (level != "") && (exp.CompareTo(DateTime.Now) > 0))  // check rule
            {
                string connectionstr = main.constr;
                string CommandText = @"insert into [carpark].[dbo].[UserLisy](UserName,Password,Level,ExpireDate)values(@UserName,
                                      @Password,@Level,@ExpireDate);";
                string search = @"select * from [carpark].[dbo].[UserLisy] where UserName=@username";
                SqlParameter[] para = new SqlParameter[]
                    {
                    new SqlParameter("@UserName",username),
                    new SqlParameter("@Password",password),
                    new SqlParameter("@Level",level),
                    new SqlParameter("@ExpireDate",ExpDate.Value.ToString("yyyy-MM-dd hh:mm:ss"))
                    };
                DataSet ds = null;
                DataTable dt = null;
                try
                {
                    ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, search, new SqlParameter("@username", username));
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show(username + " already exist,Please use another name");
                    }
                    else
                    {
                        SqlHelper.ExecuteNonQuery(connectionstr, CommandType.Text, CommandText, para);
                        MessageBox.Show("User :" + username + " created successfully!!");
                        
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("SQl error,fail to create user");
                }
                finally
                {
                    try
                    {
                        ds.Dispose();
                        dt.Dispose();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Can't Close ds and dt");
                    }
                }

            }
            else
            {
                if(username=="")
                    MessageBox.Show("UserName is null");
                if (password != Cpassword)
                    MessageBox.Show("2 times password is not same");
                if (level=="")
                    MessageBox.Show("Level is null");
                if (exp.CompareTo(DateTime.Now) <= 0)
                    MessageBox.Show("Date must be earlier than today");
            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserControl_Load(object sender, EventArgs e)
        {

        }


    }
}
