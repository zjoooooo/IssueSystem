using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace IssueSystem
{
    class ToolsUtility
    {
      //  Check Ping
        public static bool Ping(string ip)
        {
            try
            {
                if (!(String.IsNullOrEmpty(ip)))
                {
                    //int timeout = 2000;
                    //string data = "ttttttesttttttttt";
                    //Ping p = new Ping();
                    //PingOptions options = new PingOptions();
                    //options.DontFragment = true;
                    //byte[] buffer = Encoding.ASCII.GetBytes(data);
                    //PingReply reply = p.Send(ip, timeout, buffer, options);
                    //LogClass.wirteLine("IP : " + ip + ",Status:" + reply.Status);
                    //if (reply.Status == IPStatus.Success)
                    //{
                    //    LogClass.wirteLine("IP : " + ip + ",Status:" + reply.Status);
                    //    return true;
                    //}             
                    var ping = new Ping();
                    byte[] buffer = new byte[60];

                    var pingReply = ping.Send(ip, 2000, buffer, new PingOptions(600, false));
                    if (pingReply.Status == IPStatus.Success)
                    {
                        LogClass.WirteLine("IP : " + ip + ",Status:" + pingReply.Status);
                        return true;
                    }
                    LogClass.WirteLine("IP : " + ip + ",Status:" + pingReply.Status);
                    return false;
                }
                LogClass.WirteLine("IP address is null");
                return false;
            }
            catch (PingException Pe)
            {
                LogClass.WirteLine("Ping error from ip:" + ip + "," + Pe.ToString());
                return false;
            }

        }

        //Check Repeat Data


        public static bool CheckValue(string data, string rdata)
        {
            if ((data != null) && (rdata != null) && (rdata != "") && (rdata != ""))
            {
                if (data == rdata)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
