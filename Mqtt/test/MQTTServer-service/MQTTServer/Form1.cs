using MQTTnet.Client;
using MQTTnet.Protocol;
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

namespace MQTTServer
{
    public partial class Form1 : Form
    {
        public  MqttServer mqttServer = null;

        private MqttClient mqttClient = null;
        public Form1()
        {
            InitializeComponent();
        }
        public Task Task = null;
        private void but_startserver_Click(object sender, EventArgs e)
        {
          
            Task = Task.Run(RunAsync);
            this.rtb_servermsg.AppendText($">> 启动成功..." + Environment.NewLine);
           // rtb_servermsg.AppendText("MQTT服务器已开启");
        }


        private void but_stopserver_Click(object sender, EventArgs e)
        {

          Task.Dispose();
        }
        public  async Task RunAsync()
        {
            try
            {
                MqttNetConsoleLogger.ForwardToConsole();

                var options = new MqttServerOptions
                {
                    ConnectionValidator = p =>
                    {
                        if (p.ClientId == "SpecialClient")
                        {
                            if (p.Username != "USER" || p.Password != "PASS")
                            {
                                p.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                            }
                        }
                    },

                  //  Storage = new RetainedMessageHandler(),

                    ApplicationMessageInterceptor = context =>
                    {
                        if (MqttTopicFilterComparer.IsMatch(context.ApplicationMessage.Topic, "/myTopic/WithTimestamp/#"))
                        {
                            // Replace the payload with the timestamp. But also extending a JSON 
                            // based payload with the timestamp is a suitable use case.
                            context.ApplicationMessage.Payload = Encoding.UTF8.GetBytes(DateTime.Now.ToString("O"));
                        }

                        if (context.ApplicationMessage.Topic == "not_allowed_topic")
                        {
                            context.AcceptPublish = false;
                            context.CloseConnection = true;
                        }
                    },
                    SubscriptionInterceptor = context =>
                    {
                        if (context.TopicFilter.Topic.StartsWith("admin/foo/bar") && context.ClientId != "theAdmin")
                        {
                            context.AcceptSubscription = false;
                        }

                        if (context.TopicFilter.Topic.StartsWith("the/secret/stuff") && context.ClientId != "Imperator")
                        {
                            context.AcceptSubscription = false;
                            context.CloseConnection = true;
                        }
                    }
                };

                // Extend the timestamp for all messages from clients.
                // Protect several topics from being subscribed from every client.

                //var certificate = new X509Certificate(@"C:\certs\test\test.cer", "");
                //options.TlsEndpointOptions.Certificate = certificate.Export(X509ContentType.Cert);
                //options.ConnectionBacklog = 5;
                //options.DefaultEndpointOptions.IsEnabled = true;
                //options.TlsEndpointOptions.IsEnabled = false;

                var mqttServer = new MqttFactory().CreateMqttServer();

                mqttServer.ApplicationMessageReceived += (s, e) =>
                {
                    string msg = e.ClientId + "  reported  " + e.ApplicationMessage.Topic + "> " + Encoding.UTF8.GetString(e.ApplicationMessage.Payload ?? new byte[0]);
                    this.Invoke(new Action(() =>
                    {
                        rtb_servermsg.AppendText(msg);
                    }));


          

                    //MqttNetConsoleLogger.PrintToConsole(
                    //    $"'{e.ClientId}' reported '{e.ApplicationMessage.Topic}' > '{Encoding.UTF8.GetString(e.ApplicationMessage.Payload ?? new byte[0])}'",
                    //    ConsoleColor.Magenta);
                };

                //options.ApplicationMessageInterceptor = c =>
                //{
                //    if (c.ApplicationMessage.Payload == null || c.ApplicationMessage.Payload.Length == 0)
                //    {
                //        return;
                //    }

                //    try
                //    {
                //        var content = JObject.Parse(Encoding.UTF8.GetString(c.ApplicationMessage.Payload));
                //        var timestampProperty = content.Property("timestamp");
                //        if (timestampProperty != null && timestampProperty.Value.Type == JTokenType.Null)
                //        {
                //            timestampProperty.Value = DateTime.Now.ToString("O");
                //            c.ApplicationMessage.Payload = Encoding.UTF8.GetBytes(content.ToString());
                //        }
                //    }
                //    catch (Exception)
                //    {
                //    }
                //};

                mqttServer.ClientDisconnected += (s, e) =>
                {
                    Console.Write("Client disconnected event fired.");
                };

                await mqttServer.StartAsync(options);

                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();

               // await mqttServer.StopAsync();                       6
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
        private  async void StopServerAsync()
        {
            await mqttServer.StopAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
