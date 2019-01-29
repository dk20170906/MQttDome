using MQTTnet;
using MQTTnet.Client;
using System;
using System.Text;

namespace mqttclienttest
{
    class Program
    {
        static void Main(string[] args)
        {


            //创建一个新的MQTT客户端。
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();


            var clientid = "Eohi_"+Guid.NewGuid().ToString();
            //使用构建器创建基于TCP的选项。
            var options = new MqttClientOptionsBuilder();
            options.WithClientId(clientid);
            options.WithTcpServer("192.168.3.125", 1884);
            options.WithCredentials("user", "password");
            options.WithTls();
            options.WithCleanSession();


            try
            {
                mqttClient.ConnectAsync(options.Build());

                mqttClient.ApplicationMessageReceived += (s, e) =>
                {
                    Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                    Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                    Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                    Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                    Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                    Console.WriteLine();
                };




                //var message = new MqttApplicationMessageBuilder()
                //    .WithTopic("TestTopicUserPassword")
                //    .WithPayload("123456")
                //    .WithExactlyOnceQoS()
                //    .WithRetainFlag()
                //    .Build();
                // mqttClient.PublishAsync(message);


                Console.WriteLine("success");
  }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();




        }
    }
}
