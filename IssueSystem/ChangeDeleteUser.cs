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
    public partial class ChangeDeleteUser : Form
    {
        Main main;
        DataSet ds = null;
        public ChangeDeleteUser(Main main)
        {
            InitializeComponent();
            this.main = main;
        }


        private void ChangeDeleteUser_Load(object sender, EventArgs e)
        {
            GetList();
                 
        }

        private void GetList()  // get user list
        {
            string connectionstr = main.constr;
            string search = @"select UserName from [carpark].[dbo].[UserLisy]";
           
            try
            {
                ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, search);                
                ComboUserList.DataSource = ds.Tables[0];
                ComboUserList.DisplayMember = "UserName";
            }
            catch (SqlException)
            {
                MessageBox.Show("Can't get userlist");
            }
        
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure To Delete?", "Delete Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string connectionstr = main.constr;
                string Delete = @"Delete from [carpark].[dbo].[UserLisy] where UserName=@username";

                try
                {
                    SqlHelper.ExecuteNonQuery(connectionstr, CommandType.Text, Delete, new SqlParameter("@username", ComboUserList.Text));
                    MessageBox.Show("Delete Ok");
                    GetList();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Fail to Delete User");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.Dispose();
            this.Close();
         
        }

        private void ChangeDeleteUser_FormClosed(object sender, FormClosedEventArgs e)
        {
       //     Beautiful.AnimateWindow(this.Handle, 2000, Beautiful.AW_SLIDE | Beautiful.AW_HIDE | Beautiful.AW_BLEND);
        }

    
    }
}
