using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MqttServerNet
{
    public partial class Form1 : Form
    {
        public MqttServer mqttServer = null;
        public Form1()
        {
            InitializeComponent();
            while (true)
            {
                if (mqttServer == null)
                {
                    mqttServer?.StopAsync();
                    rtb_showmsg.AppendText("MQTT服务已停止！");
                    break;
                }
                else
                {
                    rtb_showmsg.AppendText("MQTT服务已启动！");
                    var mqttclients = mqttServer.GetConnectedClientsAsync().Result;
                    if (mqttclients.Count > 0)
                    {
                        foreach (var item in mqttclients)
                        {
                            rtb_showmsg.AppendText($"客户端标识：{item.ClientId}，协议版本：{item.ProtocolVersion}");
                        }
                    }
                }

            }
        }

        private void but_serverstart_Click(object sender, EventArgs e)
        {
            if (mqttServer == null)
            {
                try
                {
                    var options = new MqttServerOptions();
                   // options.ConnectionValidator.
                    mqttServer = new MqttServerFactory().CreateMqttServer() as MqttServer;
                    mqttServer.StartAsync(options);
                    rtb_showmsg.AppendText("MQTT服务已启动！");
                }
                catch (Exception ex)
                {
                    rtb_showmsg.AppendText(ex.Message);
                    throw;
                }
            }
            else
            {
                var mqttclients = mqttServer.GetConnectedClientsAsync().Result;
                if (mqttclients.Count > 0)
                {
                    foreach (var item in mqttclients)
                    {
                        rtb_showmsg.AppendText($"客户端标识：{item.ClientId}，协议版本：{item.ProtocolVersion}");
                    }
                }
            }
        }

        private void but_mqttstop_Click(object sender, EventArgs e)
        {
            if (mqttServer!=null)
            {
                mqttServer?.StopAsync();
                rtb_showmsg.AppendText("MQTT服务已停止！");
            }
        }
    }
}
