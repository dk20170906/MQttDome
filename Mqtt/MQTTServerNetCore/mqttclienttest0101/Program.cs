using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System;
using System.Text;
using System.Threading.Tasks;

namespace mqttclienttest0101
{
    class Program
    {
        static MqttClient mqttClient = null;
        static void Main(string[] args)
        {

            //var factory = new MqttFactory();
            //var mqttClient = factory.CreateMqttClient();

            //var options = new MqttClientOptionsBuilder();
            //options.WithClientId(new Guid().ToString());
            //options.WithTcpServer("192.168.3.193");
            //options.WithTls();
            //options.WithCleanSession();

            //var task = mqttClient.ConnectAsync(options.Build());
            RunAsync();
            Console.ReadLine();
            //if (mqttClient != null)
            //{
            //    var message = new MqttApplicationMessageBuilder();
            //    message.WithTopic("TopicTest");
            //    message.WithPayload("topictest001");

            //    message.WithExactlyOnceQoS();
            //    message.WithRetainFlag();
            //    mqttClient.PublishAsync(message.Build());
            //}


            Console.WriteLine("Hello World!");
        }
        public static async Task RunAsync()
        {
            try
            {
                var m = "Eohi_" + Guid.NewGuid().ToString();
                var options = new MqttClientOptions
                {
                    ClientId = m,
                    CleanSession = true,
                    ChannelOptions = new MqttClientTcpOptions
                    {
                        //server = "localhost",
                        Server = "192.168.3.125",
                        Port = 1884,

                    },
                    Credentials = new MqttClientCredentials()
                    {
                        Username = "user",
                        Password = "123456"
                    }




                };
                //channeloptions = new mqttclientwebsocketoptions
                //{
                //    uri = "ws://localhost:59690/mqtt"
                //}


                var factory = new MqttFactory();

                mqttClient = factory.CreateMqttClient() as MqttClient;

                mqttClient.ApplicationMessageReceived += (s, e) =>
                {
                    Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                    Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                    Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                    Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                    Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                    Console.WriteLine();
                };



                mqttClient.Connected += async (s, e) =>
                {
                    Console.WriteLine("### CONNECTED WITH SERVER ###");

                    await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("#").Build());

                    Console.WriteLine("### SUBSCRIBED ###");
                };

                mqttClient.Disconnected += async (s, e) =>
                {
                    Console.WriteLine("### DISCONNECTED FROM SERVER ###");
                    await Task.Delay(TimeSpan.FromSeconds(5));

                    try
                    {
                        await mqttClient.ConnectAsync(options);
                    }
                    catch
                    {
                        Console.WriteLine("### RECONNECTING FAILED ###");
                    }
                };

                try
                {
                    await mqttClient.ConnectAsync(options);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("### CONNECTING FAILED ###" + Environment.NewLine + exception);
                }

                Console.WriteLine("### WAITING FOR APPLICATION MESSAGES ###");


                var applicationMessage = new MqttApplicationMessageBuilder()
             .WithTopic("TestTopicUserPassword")
             .WithPayload("Hello World")
             .WithAtLeastOnceQoS()
             .Build();

                await mqttClient.PublishAsync(applicationMessage);


                while (true)

                {
                    Console.ReadLine();

                    await mqttClient.SubscribeAsync(new TopicFilter("TestTopicUserPassword", MqttQualityOfServiceLevel.AtMostOnce));


                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
