using System;
using System.Threading.Tasks;

namespace mqttservertest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(ServerTest.RunAsync);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
