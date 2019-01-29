using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using MQTTnet.Server;
using Newtonsoft.Json;

namespace mqttnetcore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public MqttServer mqttServer = null;
        public Timer timer = null;
        public List<ConnectedMqttClient> ConnetedClients = new List<ConnectedMqttClient>();
        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //  //  return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //  [HttpGet("{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            StartMqttServer();
            return View();
          //  return "value";
        }
        public string StartMqttServer()
        {
            string msg = string.Empty;
            if (mqttServer == null)
            {
                if (CreateMqttServer())
                    msg = "MQTT服务器已开启！";
                else
                    msg = "MQTT服务器已停止！";
            }
            if (CreateMqttTimerToGetConnectClients())
            {
                timer.Start();
            }
            return JsonConvert.SerializeObject(ConnetedClients);
        }
        private bool CreateMqttServer()
        {
            if (mqttServer == null)
            {
                var options = new MqttServerOptions();
                mqttServer = new MqttServerFactory().CreateMqttServer() as MqttServer;
            }
            if (mqttServer != null)
                return true;
            else
                return false;
        }
        private bool CreateMqttTimerToGetConnectClients()
        {
            if (timer == null)
            {
                timer = new System.Timers.Timer();
                timer.Interval = 500;
                if (CreateMqttServer())
                {
                    timer.Elapsed += delegate
                    {
                        var clients = mqttServer.GetConnectedClientsAsync().Result;
                        if (clients.Count > 0)
                        {
                            foreach (var item in clients)
                            {
                                if (!ConnetedClients.Contains(item))
                                {
                                    ConnetedClients.Add(item);
                                }
                            }
                        }
                    };
                }
            }
            if (timer != null)
                return true;
            else
                return false;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
