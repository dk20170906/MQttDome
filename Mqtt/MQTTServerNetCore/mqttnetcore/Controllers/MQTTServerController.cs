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
    public class MQTTServerController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
       
    }
}