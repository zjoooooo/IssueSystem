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
    public partial class InputCarpark : Form
    {
        CreateModifyCarpark cmc;
        public InputCarpark(CreateModifyCarpark cmc)
        {
            InitializeComponent();
            this.cmc = cmc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress iprule;
            string name = textBox1.Text.Trim();
            string ip = textBox2.Text.Trim();
            string connectionstr = cmc.constr;
            string SearchCmd = "select name from carpark.dbo.Whole";
            DataSet ds = null;
            DataTable dt = null;

            if ((IPAddress.TryParse(ip, out iprule)) && (name != null))
            {
                try
                {
                    ds = SqlHelper.ExecuteDataset(connectionstr, CommandType.Text, SearchCmd);
                    dt = ds.Tables[0];

                }
                catch (Exception)
                {
                    MessageBox.Show("System Can't Get Carpark List");
                }



                Boolean flag = false;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["name"].ToString() == name)
                    {
                        flag = true; break;
                    }
                }

                dt.Dispose();
                ds.Dispose();
                if (!flag)
                {

                    SqlParameter[] para = new SqlParameter[]
                    {
                    new SqlParameter("@name",name),
                    new SqlParameter("@ip",ip),
                    new SqlParameter("@batch",comboBox1.Text)
                    };

                    string CommandText = "insert into [carpark].[dbo].[Whole](name,ip,batch)values(@name,@ip,@batch);";
                    try
                    {
                        SqlHelper.ExecuteNonQuery(connectionstr, CommandType.Text, CommandText, para);
                        MessageBox.Show("Add " + name + " Ok");
                        cmc.GetList();
                        this.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Can't Add New Carpark");
                    }
                }
                else
                { MessageBox.Show(name + " Already exist"); }
            }
            else
            { MessageBox.Show("IP address format is incorrect"); return; }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputCarpark_Load(object sender, EventArgs e)
        {
            string constr = cmc.constr;
            string cmd = "select batch from BatchTable";

            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, cmd);
                comboBox1.DataSource=ds.Tables[0];
                comboBox1.DisplayMember = "batch";
            }
            catch(SqlException sqle)
            {
                MessageBox.Show("SqlException:"+sqle.ToString());
            }
        }
    }
}
