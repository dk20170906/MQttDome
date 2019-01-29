using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MQTTServer.Form1;

namespace MQTTServer
{


    //public static class ServerTest
    //{
    //    public static MqttServer mqttServer = null;
    //    public static string Msg = string.Empty;

    //    public static async Task RunAsync()
    //    {
    //        try
    //        {
    //            MqttNetConsoleLogger.ForwardToConsole();

    //            var options = new MqttServerOptions
    //            {
    //                ConnectionValidator = p =>
    //                {
    //                    if (p.ClientId == "SpecialClient")
    //                    {
    //                        if (p.Username != "USER" || p.Password != "PASS")
    //                        {
    //                            p.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
    //                        }
    //                    }
    //                },

    //               //Storage = new RetainedMessageHandler(),

    //                ApplicationMessageInterceptor = context =>
    //                {
    //                    if (MqttTopicFilterComparer.IsMatch(context.ApplicationMessage.Topic, "/myTopic/WithTimestamp/#"))
    //                    {
    //                        // Replace the payload with the timestamp. But also extending a JSON 
    //                        // based payload with the timestamp is a suitable use case.
    //                        context.ApplicationMessage.Payload = Encoding.UTF8.GetBytes(DateTime.Now.ToString("O"));
    //                    }

    //                    if (context.ApplicationMessage.Topic == "not_allowed_topic")
    //                    {
    //                        context.AcceptPublish = false;
    //                        context.CloseConnection = true;
    //                    }
    //                },
    //                SubscriptionInterceptor = context =>
    //                {
    //                    if (context.TopicFilter.Topic.StartsWith("admin/foo/bar") && context.ClientId != "theAdmin")
    //                    {
    //                        context.AcceptSubscription = false;
    //                    }

    //                    if (context.TopicFilter.Topic.StartsWith("the/secret/stuff") && context.ClientId != "Imperator")
    //                    {
    //                        context.AcceptSubscription = false;
    //                        context.CloseConnection = true;
    //                    }
    //                }
    //            };

    //            // Extend the timestamp for all messages from clients.
    //            // Protect several topics from being subscribed from every client.

    //            //var certificate = new X509Certificate(@"C:\certs\test\test.cer", "");
    //            //options.TlsEndpointOptions.Certificate = certificate.Export(X509ContentType.Cert);
    //            //options.ConnectionBacklog = 5;
    //            //options.DefaultEndpointOptions.IsEnabled = true;
    //            //options.TlsEndpointOptions.IsEnabled = false;

    //             mqttServer = new MqttFactory().CreateMqttServer()as MqttServer;

    //            mqttServer.ApplicationMessageReceived += (s, e) =>
    //            {
    //                MqttNetConsoleLogger.PrintToConsole(
    //                    $"'{e.ClientId}' reported '{e.ApplicationMessage.Topic}' > '{Encoding.UTF8.GetString(e.ApplicationMessage.Payload ?? new byte[0])}'",
    //                    ConsoleColor.Magenta);
    //            };

    //            //options.ApplicationMessageInterceptor = c =>
    //            //{
    //            //    if (c.ApplicationMessage.Payload == null || c.ApplicationMessage.Payload.Length == 0)
    //            //    {
    //            //        return;
    //            //    }

    //            //    try
    //            //    {
    //            //        var content = JObject.Parse(Encoding.UTF8.GetString(c.ApplicationMessage.Payload));
    //            //        var timestampProperty = content.Property("timestamp");
    //            //        if (timestampProperty != null && timestampProperty.Value.Type == JTokenType.Null)
    //            //        {
    //            //            timestampProperty.Value = DateTime.Now.ToString("O");
    //            //            c.ApplicationMessage.Payload = Encoding.UTF8.GetBytes(content.ToString());
    //            //        }
    //            //    }
    //            //    catch (Exception)
    //            //    {
    //            //    }
    //            //};

    //            await mqttServer.StartAsync(options);

    //            Form1. StopServerevent+= new StopServerDelgate(StopServerAsync);
    //        }
    //        catch (Exception e)
    //        {
    //            Msg = e.Message;
    //        }

 
    //    }
    //    private static async void StopServerAsync()
    //    {
    //        await mqttServer.StopAsync();
    //    }
    //}
  
}
