using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTTNetFrm
{
    public partial class Form1 : Form
    {
        private ServiceController ServiceController = null;
        private MqttClientOptions options = null;
        private MqttClient mqttClient = null;



        public Form1()
        {
            InitializeComponent();

   
            new Thread(new ThreadStart(GetServiceStatus)).Start();

          Task.Run(LinkClientService).Wait();
        }
        /// <summary>
        /// 获取当前ip地址
        /// </summary>
        /// <returns></returns>
        private  string GetLocalIP()
        {
            string ip = null;
          var iplist = Dns.GetHostAddresses(Dns.GetHostName()).DefaultIfEmpty().ToList();
            iplist.ForEach(u =>
            {
                if (u.AddressFamily == AddressFamily.InterNetwork)
                    ip= u.ToString();
            });
            return ip;
        }
        private async Task LinkClientService()
        {
            var m = "Eohi_Frm_" + Guid.NewGuid().ToString();
            options = new MqttClientOptions
            {
                ClientId = m,
                CleanSession = true,
                ChannelOptions = new MqttClientTcpOptions
                {
                    Server = GetLocalIP(),
                    Port = 1884,
                },
                Credentials = new MqttClientCredentials()
                {
                    Username = "user",
                    Password = "123456"
                }

            };
            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient() as MqttClient;
            try
            {
                await mqttClient.ConnectAsync(options);
                but_submsg_Click();
                this.Invoke(new Action(() => { lab_serverstatus.Text = "连接正常，服务运行中............"; }));
            }
            catch (Exception ex)
            {

            }

        }
        private async void but_submsg_Click()
        {
            if (mqttClient != null)
            {
                await mqttClient.SubscribeAsync(new TopicFilter("ClientsCount", MqttQualityOfServiceLevel.AtMostOnce));
                await mqttClient.SubscribeAsync(new TopicFilter("clientlink", MqttQualityOfServiceLevel.AtMostOnce));
                await mqttClient.SubscribeAsync(new TopicFilter("msglog", MqttQualityOfServiceLevel.AtMostOnce));
                mqttClient.ApplicationMessageReceived += (s, e) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        var msg = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                        if (msg.Length<=5)
                        {
                            lab_clientcount.Text = msg;
                        }
                        if (msg.Length>10)
                        {
                            if (msg.StartsWith("连接")    )
                                rtb_clientlog.AppendText(msg);
                            rtb_msglog.AppendText(msg);
                        }
   

                    }));
                };

            }
        }
        private void GetServiceStatus()
        {
            ServiceController[] serviceControllers = ServiceController.GetServices();
            if (serviceControllers.Length > 0)
            {
                serviceControllers.ToList().ForEach(u =>
                {
                    if (u.DisplayName == "MqttNetServiceAddUserAndPassword")
                    {
                        if (ServiceController == null)
                        {
                            ServiceController = u;
                        }
                        if (u.Status == ServiceControllerStatus.Running)
                        {
                            lab_serverstatus.Text = "服务运行中............";
                        }
                        else
                        {
                            lab_serverstatus.Text = "服务已停止............";
                        }
                    }
                });
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                rtb_clientlog.Text = "";
            }
            else
            {
                rtb_msglog.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
