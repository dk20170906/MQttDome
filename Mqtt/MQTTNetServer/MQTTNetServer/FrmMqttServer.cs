using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace MQTTNetServer
{
    public partial class FrmMqttServer : Form
    {
        private System.Timers.Timer timer = null;
        private List<string> subClients = new List<string>();
        public FrmMqttServer()
        {
            InitializeComponent();
          
            but_startserver.Enabled = true;
            but_openfrmsendmsg.Enabled = false;
            but_stopserver.Enabled = false;

            timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Interval =500;
            timer.Elapsed += new ElapsedEventHandler (GetSubClientSAndSetShow);

            //默认相关发送接收客户端信息不显示
            splitContainer2.Panel1.Hide();
            splitContainer2.Panel2.Hide();
        }

        private void GetSubClientSAndSetShow(object sender, ElapsedEventArgs e)
        {
            if (ServerConfig.mqttServer!=null)
            {
             List<ConnectedMqttClient>subclients= ServerConfig.mqttServer.GetConnectedClientsAsync().Result.ToList();
                if (subclients.Count>0)
                {
                    this.Invoke(new Action(() => { lab_subclientcountunm.Text = subClients.Count.ToString(); }));
                    foreach (var item in subclients)
                    {
                        if (!subClients.Contains(item.ClientId))
                        {
                            subClients.Add(item.ClientId);
                            this.Invoke(new Action(() => {
                                string msg = @"接收客户端ID:"+item.ClientId+"\n"
                                +"接收时间："+DateTime.Now+"\n"
                                + "协议版本：" + item.ProtocolVersion+"\n"
                                +"------------------"+"\n";
                                rtb_subclientmsg.AppendText(msg);
                            }));
                        }
                    }
                }
                else
                {
                    this.Invoke(new Action(() => { lab_subclientcountunm.Text = "0"; }));
                }
            }
        }

        private  void but_startserver_Click(object sender, EventArgs e)
        {
            //判断端口
            if (txtb_serverport.Text.Length > 0 && Convert.ToInt32(txtb_serverport.Text.Trim()) > 0)
            {
                ServerConfig.ServerPort = Convert.ToInt32(txtb_serverport.Text.Trim());
                lab_showport.Text = "-";
                lab_showport.ForeColor = Color.Black;
            }
            else
            {
                lab_showport.Text = "请先设置正确的端口";
                lab_showport.ForeColor = Color.Red;
                txtb_serverport.Focus();
                but_startserver.Enabled = true;
                but_openfrmsendmsg.Enabled = false;
                but_stopserver.Enabled = false;
                return;
            }

               //开启服务
            CreateMQTTServer();
          
            if (ServerConfig.mqttServer == null)
            {
              
                but_startserver.Enabled = true;
                but_openfrmsendmsg.Enabled = false;
                but_stopserver.Enabled = false;
            }
            else
            {
             
                but_startserver.Enabled = false;
                but_openfrmsendmsg.Enabled = true;
                but_stopserver.Enabled = true;
            }
            //开启定时器
            timer.Start();
            lab_serverstarttimer.Text = DateTime.Now.ToString();


        }
        private  void CreateMQTTServer()
        {
            MqttNetConsoleLogger.ForwardToConsole();
            if (ServerConfig.mqttServer == null)
            {
                var options = new MqttServerOptions();
           ;


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
                    this.Invoke(new Action(() =>
                      {
                          rtb_sendmsg.AppendText(msg);
                          lab_currentsendclient.Text = e.ClientId;
                      }));
                };
                 ServerConfig.mqttServer.StartAsync(options);
            }
        }

        private void txtb_serverip_Leave(object sender, EventArgs e)
        {
         
        }

        private void but_stopserver_Click(object sender, EventArgs e)
        {
            ////??????????????

            ServerConfig.mqttServer.StopAsync();
            ServerConfig.mqttServer = null;
         
            but_startserver.Enabled = true;
            but_openfrmsendmsg.Enabled = false;
            but_stopserver.Enabled = false;
            //  task.Dispose();
            lab_serverstarttimer.Text = "";
            subClients.Clear();
            timer.Stop();

        }

        private void but_openfrmsendmsg_Click(object sender, EventArgs e)
        {
            FrmServerSendMsg frmServerSendMsg = new FrmServerSendMsg();
            frmServerSendMsg.ShowDialog();
        }

        private void but_sendclear_Click(object sender, EventArgs e)
        {
            rtb_sendmsg.Text = "";
        }

        private void but_subclear_Click(object sender, EventArgs e)
        {
            rtb_subclientmsg.Text = "";
            subClients.Clear();
        }

        private void but_sendtxtshow_Click(object sender, EventArgs e)
        {
            if (but_sendtxtshow.Text.Contains("显示"))
            {
                splitContainer2.Panel1.Show();
                but_sendtxtshow.Text = "关闭发送消息客户端信息";
            }
            else
            {
                splitContainer2.Panel1.Hide();
                but_sendtxtshow.Text = "显示发送消息客户端信息";
            }
        
        }

        private void but_subtxtshow_Click(object sender, EventArgs e)
        {
            if (but_subtxtshow.Text.Contains("显示"))
            {
                splitContainer2.Panel2.Show();
                but_subtxtshow.Text = "关闭连接客户端列表";
            }
            else
            {
                splitContainer2.Panel2.Hide();
                but_subtxtshow.Text = "显示连接客户端列表";
            }
          
        }

        private void txtb_serverport_Leave(object sender, EventArgs e)
        {
            if (txtb_serverport.Text.Length>0&& Convert.ToInt32(txtb_serverport.Text.Trim())>0)
            {
                ServerConfig.ServerPort = Convert.ToInt32(txtb_serverport.Text.Trim());
            }
            else
            {
                lab_showport.Text = "请先设置正确的端口";
                lab_showport.ForeColor = Color.Red;
                txtb_serverport.Focus();
                but_startserver.Enabled = true;
                but_openfrmsendmsg.Enabled = false;
                but_stopserver.Enabled = false;
                return;
            }
        }
    }
}
