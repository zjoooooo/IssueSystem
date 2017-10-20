using System;

public class Class1
{
	public Class1()
	{      

    }

    public void NewAPI(string relay, string code)
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

    public void OldAPI()
    {
        string ip = GetValue(listBox1.SelectedItem.ToString() + clear.Name.ToString() + "IP");
        string rely = getMib(GetValue(listBox1.SelectedItem.ToString() + clear.Name.ToString() + "RELY"));
        int result = SNMP_SET(ip, 161, rely, adventnet.snmp.snmp2.SnmpAPI.INTEGER, "0", "private");
        LogClass.WirteLine("ip=" + ip + ",port=161,mib=" + rely + ",adventnet.snmp.snmp2.SnmpAPI.INTEGER=" + adventnet.snmp.snmp2.SnmpAPI.INTEGER + ",setvalue=1,community=private");
    }

    public string getMib(string point) //mib for barrier controller
    {
        Dictionary<string, string> it = new Dictionary<string, string>();
        it.Add("1", ".1.3.6.1.4.1.19865.1.2.1.1.0");
        it.Add("2", ".1.3.6.1.4.1.19865.1.2.1.2.0");
        it.Add("3", ".1.3.6.1.4.1.19865.1.2.1.3.0");
        it.Add("4", ".1.3.6.1.4.1.19865.1.2.1.4.0");
        it.Add("5", ".1.3.6.1.4.1.19865.1.2.1.5.0");
        it.Add("6", ".1.3.6.1.4.1.19865.1.2.1.6.0");
        it.Add("7", ".1.3.6.1.4.1.19865.1.2.1.7.0");
        it.Add("8", ".1.3.6.1.4.1.19865.1.2.1.8.0");
        it.Add("9", ".1.3.6.1.4.1.19865.1.2.2.1.0");
        it.Add("10", ".1.3.6.1.4.1.19865.1.2.2.2.0");
        it.Add("11", ".1.3.6.1.4.1.19865.1.2.2.3.0");
        it.Add("12", ".1.3.6.1.4.1.19865.1.2.2.4.0");
        it.Add("13", ".1.3.6.1.4.1.19865.1.2.2.5.0");
        it.Add("14", ".1.3.6.1.4.1.19865.1.2.2.6.0");
        it.Add("15", ".1.3.6.1.4.1.19865.1.2.2.7.0");
        it.Add("16", ".1.3.6.1.4.1.19865.1.2.2.8.0");
        if (it.ContainsKey(point))
            return it[point];
        else
            return it["1"];


    }

}
