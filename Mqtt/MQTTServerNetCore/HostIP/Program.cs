using System;
using System.Net;
using System.Net.Sockets;

namespace HostIP
{
    class Program
    {
        static void Main(string[] args)
        {
            //获得主机名
            string HostName = Dns.GetHostName();
            Console.WriteLine("主机名是：" + HostName);

            //遍历地址列表，如果电脑有多网卡只能这样遍历显示
            IPAddress[] iplist = Dns.GetHostAddresses(HostName);
            for (int i = 0; i < iplist.Length; i++)
            {
                if (iplist[i].AddressFamily == AddressFamily.InterNetwork)
                          Console.WriteLine(iplist[i].ToString());
                Console.WriteLine("IP地址：" + iplist[i]);
            }
            Console.ReadLine();
            Console.WriteLine("Hello World!");

         // string ipmsg=  System.Net.Dns.GetHostByName(System.Environment.MachineName).AddressList[0].ToString();

            Console.ReadKey();
        }
    }
}
