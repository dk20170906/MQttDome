using MQTTnet.Server;
using System;
using System.Threading.Tasks;

namespace mqttservertest
{
    class Program
    {
        public static MqttServer mqttServer = null;
        static void Main(string[] args)
        {

            Task.Run(ServerTest.RunAsync);


            MqttNetConsoleLogger.ForwardToConsole();
            if (mqttServer == null)
            {
                var options = new MqttServerOptions();
                var mqttServer = new MqttFactory().CreateMqttServer();
            }
            Console.WriteLine("mqtt服务器打开！");

            Console.ReadKey();
        }
    }
}
