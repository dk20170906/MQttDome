using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MqttNetServiceAddUserAndPassword
{
    public partial class Service1 : ServiceBase
    {
        private MqttServer mqttServer = null;
        private System.Timers.Timer timer = null;
        //此集合用于判断写入日志在一段时间内不重，以客户端id为依据，最多1000个清零；
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
            CreateMQTTServer();
            if (timer.Enabled == false)
            {
                timer.Enabled = true;
                timer.Start();
            }
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
        private async void CreateMQTTServer()
        {
            if (mqttServer == null)
            {
                var options = new MqttServerOptions();
                var optionsBuilder = new MqttServerOptionsBuilder();
                optionsBuilder.WithConnectionValidator(c =>
                {
                    if (c.ClientId.Length < 10)
                    {
                        c.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                        return;
                    }

                    //if (c.Username != "user" || c.Password != "password")
                    //{
                    //    c.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                    //    return;
                    //}
                    c.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;
                });
                //指定 ip地址，默认为本地，但此方法不能使用ipaddress报错，有哪位大神帮解答，感激。
                //options.WithDefaultEndpointBoundIPAddress(IPAddress.Parse(""))
                //指定端口
                optionsBuilder.WithDefaultEndpointPort(1883);
                //连接记录数，默认 一般为2000
                //optionsBuilder.WithConnectionBacklog(2000);
                mqttServer = new MqttFactory().CreateMqttServer() as MqttServer;
                //将发送的消息加到日志                      
                mqttServer.ApplicationMessageReceived += (s, e) =>
                {
                    string msg = @"发送消息的客户端id:" + e.ClientId + "\n"
                   + "发送时间：" + DateTime.Now + "\n"
                   + "发送消息的主题：" + e.ApplicationMessage.Topic + "\n"
                  + "发送的消息内容：" + Encoding.UTF8.GetString(e.ApplicationMessage.Payload ?? new byte[0]) + "\n"
                  + "--------------------------------------------------\n"
                  ;
                    WriteMsgLog(msg);
                };
                await mqttServer.StartAsync(options);
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
        /// <summary>
        ///客户端链接日志
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
                    sw.WriteLine(DateTime.Now.ToString() + "   " + msg);
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
            if (mqttServer != null)
            {
                List<ConnectedMqttClient> subclients = mqttServer.GetConnectedClientsAsync().Result.ToList();
                if (subclients.Count > 0)
                {
                    foreach (var item in subclients)
                    {
                        if (!subClientIDs.Contains(item.ClientId))
                        {
                            subClientIDs.Add(item.ClientId);
                            string msg = @"接收客户端ID:" + item.ClientId + "\n"
                            + "接收时间：" + DateTime.Now + "\n"
                            + "协议版本：" + item.ProtocolVersion + "\n"
                            + "最后收到的非保持活包" + item.LastNonKeepAlivePacketReceived + "\n"
                            + "最后收到的包" + item.LastPacketReceived + "\n"
                            + "挂起的应用程序消息" + item.PendingApplicationMessages + "\n"
                            + "------------------------------------------------" + "\n";
                            WriteClientLinkLog(msg);
                        }
                    }
                    if (subClientIDs.Count >= 1000)
                    {
                        subClientIDs.Clear();
                    }
                }
            }
        }

        #endregion
    }
}
