using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Bot;
using Main.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Main.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BotController : ControllerBase
    {
        [HttpGet]
        public string Notify(string key,string to,string content)
        {
            if (key != AppConfiguration.WebApi.Key) return "incorrect api key.";
            BotHelper.SendMessage(to,content);
            return "success";
        }
    }
}