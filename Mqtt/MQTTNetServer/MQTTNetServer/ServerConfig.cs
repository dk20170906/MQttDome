using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MQTTNetServer
{
  public   class ServerConfig
    {
        public static MqttServer mqttServer = null;
        private static string serverIp;
        private static int serverPort;
        public static string ServerIp {
            get {
                return serverIp;
            }
            set {
                if (serverIp==null)
                {
                    serverIp = SetServerIpHost();
                }
            }
        }
       public static int ServerPort {
            get {
                return serverPort;
            }
            set
            {
                if (serverPort<=0)
                {
                    serverPort = 1883;
                }
            }
        }
        /// <summary>
        /// 设置默认ip地址为本地地址
        /// </summary>
        public static string SetServerIpHost()
        {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                  return  ipa.ToString();
            }
            return null;
        }
    }
   
}
