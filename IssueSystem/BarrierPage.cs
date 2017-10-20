using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IssueSystem
{
    public partial class BarrierPage : Form
    {
        string carpark_name = null;
        string ip;
        Thread thr;
        public BarrierPage(string carpark)
        {
            carpark_name = carpark;
            InitializeComponent();
            label1.Text = carpark;
        }

        private void BarrierPage_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            string cmd = @"select CarPark,IP,Station,Relay,Status from BarrierInform where CarPark=@name order by Station";

            string constr = @"Data Source=172.16.1.89;uid=secure;pwd=weishenme;database=BarrierRemote";

            DataSet ds = null;
            try
            {

                ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, cmd, new SqlParameter("@name", carpark_name));    //execute

            }
            catch (SqlException e)
            {
                LogClass.WirteLine($"Read CarParkInform or BarrierInform wrong, {e.ToString()}");
                MessageBox.Show("Can't read Station Information");
                return;
            }
            if (ds != null)
            {
                cp_combox.DataSource = ds.Tables[0];
                cp_combox.DisplayMember = "Station";
                cp_combox.ValueMember = "Relay";
                cp_combox.SelectedIndex = 0;
                ip = ds.Tables[0].Rows[0]["IP"].ToString();
                string rely_status = ds.Tables[0].Rows[0]["Relay"].ToString();



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Proceed("on","1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Proceed("off","0");
        }

        private void Proceed(string str,string status)
        {
            if (thr != null)
            {
                thr.Abort();
            }
            string relay = cp_combox.SelectedValue.ToString();
            thr = new Thread(() => NewAPI(relay, str));
            // MessageBox.Show($"Station:{cp_combox.Text},Relay:{cp_combox.SelectedValue.ToString()}");
            thr.Start();
            new Thread(()=>Status(status, relay)).Start();
        }

        private void Status(string status,string relay)
        {
            string cmd = @"update BarrierInform set Status=@code where CarPark=@name and Relay=@relay";
            string constr = @"Data Source=172.16.1.89;uid=secure;pwd=weishenme;database=BarrierRemote";

            SqlParameter[] pare = new SqlParameter[]{

                new SqlParameter("@code",status),
                new SqlParameter("@name",carpark_name),
                new SqlParameter("@relay",relay)
            };

            try
            {

               SqlHelper.ExecuteDataset(constr, CommandType.Text, cmd, pare);   

            }
            catch (SqlException e)
            {
                LogClass.WirteLine($"Read CarParkInform or BarrierInform wrong, {e.ToString()}");
                MessageBox.Show("Can't read Station Information");
                return;
            }
        }

        private void NewAPI(string relay,string code)
        {
            Socket server = null;
            EndPoint point = null;
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                point = new IPEndPoint(IPAddress.Parse(ip), 2701);
                string msg = $"pin set k{relay} {code};";
                //string msg = "H8-00033-k2-on";
                server.SendTo(Encoding.UTF8.GetBytes(msg), point);
            }
            catch (Exception e)
            {
                LogClass.WirteLine($"Socket error , {e.ToString()}");
            }

        }

        private void cp_combox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
