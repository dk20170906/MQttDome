using MQTTnet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTTNetServer
{
    public partial class FrmServerSendMsg : Form
    {
        public FrmServerSendMsg()
        {
            InitializeComponent();
        }

        private void but_sendmsg_Click(object sender, EventArgs e)
        {
            if (txtb_msgtopic.Text.Length > 0)
            {
                ServerSendMsg.ServerId = "服务器id";
                ServerSendMsg.Topic = txtb_msgtopic.Text;
                ServerSendMsg.Msg = rtb_msgsend.Text;
                Task.Run(SendServerMsg);
            }
            else
            {
                lab_errormsg.Text = "发送的消息必须要设置主题！";
                lab_errormsg.ForeColor = Color.Red;
                txtb_msgtopic.Focus();
            }
        }
        /// <summary>
        /// 服务端发送消息
        /// </summary>
        private async Task SendServerMsg()
        {
            var message = new MqttApplicationMessageBuilder();
            message.WithTopic(ServerSendMsg.Topic);
            message.WithPayload(ServerSendMsg.Msg);
            message.WithExactlyOnceQoS();
            message.WithRetainFlag();
            await ServerConfig.mqttServer.PublishAsync(message.Build());
        }
        private void but_cancelmsg_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
