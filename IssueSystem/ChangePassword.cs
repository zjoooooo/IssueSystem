using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace IssueSystem
{
    public partial class ChangePassword : Form
    {
        Main main;
        public ChangePassword(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                
                string user = main.loginuser;
                if ((TxtOldpwd.Text.Trim() != "") && (TxtNewpwd.Text.Trim() != "") && (TxtcfNewpwd.Text.Trim() != ""))
                {
                    DataSet ds = null;
                    string opwd = null;
                    string connectionstr = main.constr;
                    string search = @"select Password from [carpark].[dbo].[UserLisy] where UserName=@username";
                    try
                    {
                        ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, search, new SqlParameter("@username", main.loginuser));
                        opwd = ds.Tables[0].Rows[0][0].ToString();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Can't connect to user table");
                    }
                    finally
                    {
                        try
                        {
                            ds.Dispose();
                        }
                        catch(SqlException)
                        {
                            MessageBox.Show("Can't close dataset");
                        }
                    }
                  
                    if (opwd == TxtOldpwd.Text.Trim())
                    {                       
                        string change = @"update [carpark].[dbo].[UserLisy] set Password=@pwd where UserName=@username";
                        SqlParameter[] para = new SqlParameter[]
                        {
                            new SqlParameter("@username", user),
                            new SqlParameter("@pwd", TxtNewpwd.Text.Trim())
                        };
                        try
                        {
                            SqlHelper.ExecuteNonQuery(connectionstr, CommandType.Text,change,para);
                            MessageBox.Show("Change Password Ok");
                            this.Close();
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Fail to Change Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Old Password incorrect");
                    }
                }
                else
                { 
                   
                if (TxtOldpwd.Text.Trim() == "")
                    MessageBox.Show("Old Password can't be null");
                if (TxtNewpwd.Text.Trim() == "")
                    MessageBox.Show("New Password can't be null");
                if (TxtcfNewpwd.Text.Trim() == "")
                    MessageBox.Show("Please Confirm New Password");
                }
              
          
        }

        private void ComboCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
        
    }
 }

