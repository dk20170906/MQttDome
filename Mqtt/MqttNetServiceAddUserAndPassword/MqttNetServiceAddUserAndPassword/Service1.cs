using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MqttNetServiceAddUserAndPassword
{
    public partial class Service1 : ServiceBase
    {
        private readonly static object locker = new object();
        private MqttServer mqttServer = null;
        private System.Timers.Timer timer = null;

        private GodSharp.Sockets.SocketServer socketService = null;

 

        //此集合用于判断写入日志在一段时间内不重，以客户端id为依据，最多2000个清零；
        private List<string> subClientIDs = new List<string>();
        public Service1()
        {
            InitializeComponent();
            //创建一个定时器，检查5s内有多少客户端接入并将相关信息记录到日志中
            timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Interval = 5000;
            timer.Elapsed += new ElapsedEventHandler(GetSubClientSAndSetShow);


        }

        protected override void OnStart(string[] args)
        {
            //开启服务
            //CreateMQTTServer();

            Task.Run(CreateMQTTServer);


            if (timer.Enabled == false)
            {
                timer.Enabled = true;
                timer.Start();
            }
            //创建socket服务端
            //CreateServerSocket();
        //    SocketServer.StartSocketService();
        }

        protected override void OnStop()
        {
            if (timer.Enabled == true)
            {
                timer.Enabled = false;
                timer.Stop();
            }
        }
        /// <summary>
        /// 开启服务
        /// </summary>
        private async Task CreateMQTTServer()
        {
            if (mqttServer == null)
            {
                var optionsBuilder = new MqttServerOptionsBuilder();
                optionsBuilder.WithConnectionValidator(c =>
                {
                    if (c.ClientId.Length < 5 || !c.ClientId.StartsWith("Eohi_"))
                    {
                        c.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                        return;
                    }

                    if (c.Username != "user" || c.Password != "123456")
                    {
                        c.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                        return;
                    }
                    c.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;
                });
                //指定 ip地址，默认为本地，但此方法不能使用ipaddress报错，有哪位大神帮解答，感激。
                //options.WithDefaultEndpointBoundIPAddress(IPAddress.Parse(""))
                //指定端口
                optionsBuilder.WithDefaultEndpointPort(1884);
                //连接记录数，默认 一般为2000
                //optionsBuilder.WithConnectionBacklog(2000);
                mqttServer = new MqttFactory().CreateMqttServer() as MqttServer;
                string msg = null;
             
                //将发送的消息加到日志                      
                mqttServer.ApplicationMessageReceived += (s, e) =>
                {
                    msg = @"发送消息的客户端id:" + e.ClientId + "\r\n"
                  + "发送时间：" + DateTime.Now + "\r\n"
                  + "发送消息的主题：" + e.ApplicationMessage.Topic + "\r\n"
                 + "发送的消息内容：" + Encoding.UTF8.GetString(e.ApplicationMessage.Payload ?? new byte[0]) + "\r\n"
                 + "--------------------------------------------------\r\n"
                 ;
                    WriteMsgLog(msg);
                };
                await mqttServer.StartAsync(optionsBuilder.Build());

            }
        }
        #region 记录日志  
        /// <summary>  
        /// 消息记录日志  
        /// </summary>  
        /// <param name="msg"></param>  
        private void WriteMsgLog(string msg)
        {

            //string path = @"C:\log.txt";  

            //该日志文件会存在windows服务程序目录下  
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Msglog.txt";
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                FileStream fs;
                fs = File.Create(path);
                fs.Close();
            }
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "   " + msg);
                }
            }
        }
        private void PubMessage(string topic, string msg)
        {
            if (mqttServer != null)
            {
                lock (locker)
                {
                    var message = new MqttApplicationMessageBuilder();
                    message.WithTopic(topic);
                    message.WithPayload(msg);
                    mqttServer.PublishAsync(message.Build());
                }
            }
        }
        /// <summary>
        ///客户端链接日志           客户端接入
        /// </summary>
        /// <param name="msg"></param>
        private void WriteClientLinkLog(string msg)
        {
            //string path = @"C:\log.txt";  

            //该日志文件会存在windows服务程序目录下  
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\ClientLinklog.txt";
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                FileStream fs;
                fs = File.Create(path);
                fs.Close();
            }

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(msg);
                }
            }
        }
        /// <summary>
        /// 通过定时器将客户端链接信息写入日志      
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetSubClientSAndSetShow(object sender, ElapsedEventArgs e)
        {
            // List<SetServiceM> dic = new List<SetServiceM>();   
            if (mqttServer != null)
            {
                List<ConnectedMqttClient> subclients = mqttServer.GetConnectedClientsAsync().Result.ToList();
                if (subclients.Count > 0)
                {
                    string subclientcount = @"客户端接入的总数为：" + (subclients.Count - 1).ToString() + "\r\n"
                        + "------------------------------------------------------- \r\n";
                    WriteClientLinkLog(subclientcount);
                    PubMessage("ClientsCount", (subclients.Count - 1).ToString());
                    List<string> clientids = new List<string>();
                    //连接客户端的个数
                    //   dic.Add(SetServiceM.SetService( "ClientCount", subclients.Count.ToString()));
                    //   var dicclientlink = new Dictionary<string, string>();

                    foreach (var item in subclients)
                    {
                        if (!subClientIDs.Contains(item.ClientId))
                        {
                            subClientIDs.Add(item.ClientId);
                            string msg = @"连接客户端ID:" + item.ClientId + "\r\n"
                            + "连接时间：" + DateTime.Now + "\r\n"
                            + "协议版本：" + item.ProtocolVersion + "\r\n"
                            + "最后收到的非保持活包：" + item.LastNonKeepAlivePacketReceived + "\r\n"
                            + "最后收到的包：" + item.LastPacketReceived + "\r\n"
                            + "挂起的应用程序消息：" + item.PendingApplicationMessages + "\r\n"
                            + "------------------------------------------------" + "\r\n";
                            WriteClientLinkLog(msg);
                            PubMessage("clientlink", msg);
                            //    mqttServer.PublishAsync("clientlink", msg);
                            //    dicclientlink.Add(item.ClientId, msg);
                        }
                        clientids.Add(item.ClientId);
                    }
                    if (subClientIDs.Count >= 2000)
                    {
                        subClientIDs.Clear();
                    }
                    var exceptlist = subClientIDs.Except(clientids).ToList();
                    //  var dicclientoutline = new Dictionary<string, string>();
                    if (exceptlist.Count > 0)
                    {

                        exceptlist.ForEach(u =>
                        {
                            string msgoutline = @"客户端下线ID:" + u + "\r\n"
                       + "客户端下线时间：" + DateTime.Now.ToString() + "\r\n"
                       + "------------------------------------------------------------ \r\n"
                       ;
                            WriteClientLinkLog(msgoutline);
                            subClientIDs.Remove(u);
                            PubMessage("clientlink", msgoutline);
                        //     mqttServer.PublishAsync("clientlink", msgoutline);
                        // dicclientoutline.Add("OutLineID_" + u, msgoutline);
                    });
                    }
                    ////连接客户端的id
                    //dic.Add(SetServiceM.SetService("clientlink", JsonConvert.SerializeObject(dicclientlink)));
                    ////客户端下线的时间
                    //dic.Add(SetServiceM.SetService("clientoutline", JsonConvert.SerializeObject(dicclientoutline)));
                    //SocketServer.connection.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dic)));
                }
                else
                {
                    string subclientcount = @"暂无客户端接入！" + "\r\n"
                     + "-------------------------------------------------------- \r\n";
                    WriteClientLinkLog(subclientcount);
                }
            }
        }
        /// <summary>
        /// 客户端下线时间
        /// </summary>
        /// <param name="msg"></param>
        public void WriteClientOutLineLog(string msg)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\ClientOutLineLog.txt";
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(msg);
                }
            }
        }
        //windows服务里的服务端
        private void CreateServerSocket()
        {
            if (socketService == null)
            {
                // IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9001);
                socketService = new GodSharp.Sockets.SocketServer("127.0.0.1", 9001, ProtocolType.Tcp);  //Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketService.Start();
                socketService.Listen(10);
                Thread thread = new Thread(new ThreadStart(new Action(() =>
                {
                    while (true)
                    {
                    //  socketClient = socketService.Clients[0];
                    // string data = "sql|" ; //在这里封装数据，通常是自己定义一种数据结构，如struct data{sql;result}
                    // client.Send(Encoding.Default.GetBytes(msg));
                }
                })));
            }
            else
            {
                CreateServerSocket();
            }
        }

        #endregion
    }
}
