using MQTTnet.Server;
using MQTTNetServer;
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

namespace WindowsService1test
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(TimedEvent);
            //timer.Interval = 5000;//每5秒执行一次  
            //timer.Enabled = true;
        }
        public int count = 0;
        //定时执行事件  
        private void TimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            //业务逻辑代码  
           // EmailClass mail = new EmailClass();

          //  mail.Email(count++);
        }
        protected override void OnStart(string[] args)
        {

            CreateMQTTServer();




            this.WriteLog("\n当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "\n");
            this.WriteLog("客户端数据同步服务：【服务启动】");
        }

        protected override void OnStop()
        {
            this.WriteLog("\n当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + "\n");
            this.WriteLog("客户端数据同步服务：【服务停止】");
        }
        private void CreateMQTTServer()
        {
            MqttNetConsoleLogger.ForwardToConsole();
            if (ServerConfig.mqttServer == null)
            {
                var options = new MqttServerOptions();
                var optionsBuilder = new MqttServerOptionsBuilder();
                //不能设置ip或者vs报错找不到源IPAddress.cs？？？？？？？？？？？？？？
                // optionsBuilder.WithDefaultEndpointBoundIPAddress(IPAddress.Parse(ServerConfig.ServerIp));
                optionsBuilder.WithDefaultEndpointPort(ServerConfig.ServerPort);
                optionsBuilder.WithConnectionBacklog(100);
                ServerConfig.mqttServer = new MqttFactory().CreateMqttServer() as MqttServer;
                //将发送的消息加到展示区                       
                ServerConfig.mqttServer.ApplicationMessageReceived += (s, e) =>
                {
                    string msg = @"发送消息的客户端id:" + e.ClientId + "\n"
                   + "发送时间：" + DateTime.Now + "\n"
                   + "发送消息的主题：" + e.ApplicationMessage.Topic + "\n"
                  + "发送的消息内容：" + Encoding.UTF8.GetString(e.ApplicationMessage.Payload ?? new byte[0]) + "\n"
                  + "-----------------------------\n"
                  ;
                    //this.Invoke(new Action(() =>
                    //{
                    //    rtb_sendmsg.AppendText(msg);
                    //    lab_currentsendclient.Text = e.ClientId;
                    //}));
                };
                ServerConfig.mqttServer.StartAsync(options);
            }
        }
        #region 记录日志  
        /// <summary>  
        /// 记录日志  
        /// </summary>  
        /// <param name="msg"></param>  
        private void WriteLog(string msg)
        {

            //string path = @"C:\log.txt";  

            //该日志文件会存在windows服务程序目录下  
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\log.txt";
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
        #endregion
    }
}

