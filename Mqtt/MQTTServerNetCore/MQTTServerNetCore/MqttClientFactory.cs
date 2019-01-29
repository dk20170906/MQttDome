using MQTTnet.Client;
using MQTTnet.Diagnostics;
using MQTTnet.Implementations;
using MQTTnet.ManagedClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTServerNetCore
{
    public class MqttClientFactory : IMqttClientFactory
    {
        public IMqttClient CreateMqttClient()
        {
            return CreateMqttClient(new MqttNetLogger());
        }

        public IMqttClient CreateMqttClient(IMqttNetLogger logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            return new MqttClient(new MqttClientAdapterFactory(), logger);
        }

        public IManagedMqttClient CreateManagedMqttClient()
        {
            return new ManagedMqttClient(CreateMqttClient(), new MqttNetLogger());
        }

        public IManagedMqttClient CreateManagedMqttClient(IMqttNetLogger logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            return new ManagedMqttClient(CreateMqttClient(), logger);
        }

    }
}
