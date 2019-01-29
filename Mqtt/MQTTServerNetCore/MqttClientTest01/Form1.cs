using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace MqttClientTest01
{

    public partial class Form1 : Form
    {
        private MqttClient mqttClient = null;
        private System.Timers.Timer timer = null;
        private int CountLink = 0;
        private MqttClientOptions options = null;
        public Form1()
        {
            InitializeComponent();
            ////创建一个定时器，检查5s内有多少客户端接入并将相关信息记录到日志中
            //timer = new System.Timers.Timer();
            //timer.AutoReset = true;
            //timer.Interval = 1000;
            //timer.Elapsed += new ElapsedEventHandler(LinkMqttNetService);
        }

        private void LinkMqttNetService(object sender, ElapsedEventArgs e)
        {
            if (mqttClient == null)
            {
                //   RunAsync();
                CountLink++;
            }
            if (CountLink >= 5)
            {
                MessageBox.Show("连接多次失败，请确认各参数是否正确！");
                CountLink = 0;
                timer.Enabled = false;
            }
        }
        private void but_linkserver_Click(object sender, EventArgs k)
        {
            LinkClientService();
            //CountLink = 0;
            //timer.Enabled = true;
            //timer.Start();
        }
        /// <summary>
        /// 链接客户端
        /// </summary>
        public async  void LinkClientService()
        {
            var m = "Eohi_" + Guid.NewGuid().ToString();
            options = new MqttClientOptions
            {
                ClientId = m,
                CleanSession = true,
                ChannelOptions = new MqttClientTcpOptions
                {
                    Server = txtb_serverip.Text.Trim(),
                    Port = Convert.ToInt32(txtb_serverport.Text.Trim()),
                },
                Credentials = new MqttClientCredentials()
                {
                    Username = tb_username.Text,
                    Password = tb_userpwd.Text
                }

            };
            var factory = new MqttFactory();
            mqttClient =  factory.CreateMqttClient() as MqttClient;
            try
            {
                await mqttClient.ConnectAsync(options);
                this.Invoke(new Action(() =>
                {
                    lab_linkstatus.Text = "连接成功！";
                    lab_linktimer.Text = DateTime.Now.ToString();
                }));
                mqttClient.Disconnected += async (s, e) =>
                {
                    if (e.ClientWasConnected==false)
                    {
                        try
                        {
                            await mqttClient.ConnectAsync(options);
                            this.Invoke(new Action(() =>
                            {
                                lab_linkstatus.Text = "连接成功！";
                                lab_linktimer.Text = DateTime.Now.ToString();
                            }));
                        }
                        catch (Exception ex)
                        {
                            lab_linkstatus.Text = "连接失败！"+ex.Message;
                            lab_linktimer.Text = DateTime.Now.ToString();
                        }

                    }
                };
            }
            catch (Exception ex)
            {
                lab_linkstatus.Text = "连接失败！请检查ip/端口" ;
                lab_linktimer.Text = DateTime.Now.ToString();
            }
 
        }

        private void tb_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_clientsend_Click(object sender, EventArgs e)
        {
            if (mqttClient != null)
            {
                var message = new MqttApplicationMessageBuilder();
                message.WithTopic(txtb_msgtopic.Text.Trim());
                message.WithPayload(rtb_pubmsg.Text.Trim());
                message.WithExactlyOnceQoS();
                message.WithRetainFlag();
                mqttClient.PublishAsync(message.Build());
            }
        }
        private async void but_submsg_Click(object sender, EventArgs k)
        {
            if (mqttClient != null)
            {
                await mqttClient.SubscribeAsync(new TopicFilter(txtb_subtopic.Text.Trim(), MqttQualityOfServiceLevel.AtMostOnce));
                mqttClient.ApplicationMessageReceived += (s, e) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        rtb_submsgclient.AppendText("ClientID=" + e.ClientId + "\n");
                        rtb_submsgclient.AppendText($"+ Topic = {e.ApplicationMessage.Topic}" + "\n");
                        rtb_submsgclient.AppendText($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload) + "\n"}");
                        rtb_submsgclient.AppendText($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}" + "\n");
                        rtb_submsgclient.AppendText($"+ Retain = {e.ApplicationMessage.Retain}" + "\n");

                    }));

                };

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtb_submsgclient.Text = "";
        }
    }
}
