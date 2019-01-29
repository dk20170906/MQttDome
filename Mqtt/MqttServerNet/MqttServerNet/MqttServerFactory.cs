using MQTTnet.Adapter;
using MQTTnet.Diagnostics;
using MQTTnet.Implementations;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttServerNet
{
   public  class MqttServerFactory : IMqttServerFactory
    {
        public IMqttServer CreateMqttServer()
        {
            var logger = new MqttNetLogger();
            return CreateMqttServer(logger);
        }

        public IMqttServer CreateMqttServer(IMqttNetLogger logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            return CreateMqttServer(new List<IMqttServerAdapter> { new MqttTcpServerAdapter(logger) }, logger);
        }

        public IMqttServer CreateMqttServer(IEnumerable<IMqttServerAdapter> adapters, IMqttNetLogger logger)
        {
            if (adapters == null) throw new ArgumentNullException(nameof(adapters));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            return new MqttServer(adapters, logger);
        }
    }
}
