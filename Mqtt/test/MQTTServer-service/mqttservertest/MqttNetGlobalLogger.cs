using MQTTnet.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace mqttservertest
{
    public static class MqttNetGlobalLogger
    {
        public static event EventHandler<MqttNetLogMessagePublishedEventArgs> LogMessagePublished;

        public static bool HasListeners => LogMessagePublished != null;

        public static void Publish(MqttNetLogMessage logMessage)
        {
            if (logMessage == null) throw new ArgumentNullException(nameof(logMessage));

            LogMessagePublished?.Invoke(null, new MqttNetLogMessagePublishedEventArgs(logMessage));
        }
    }
}
