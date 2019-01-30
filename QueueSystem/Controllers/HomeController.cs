using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueueSystem.Models;

namespace QueueSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Queue()
        {
            List<string> queueNos = new List<string>();
            for (int i = 0; i < 3; i++) queueNos.Add("test");
            ViewData["queueNos"] = queueNos;
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet("/Home/Register/{qType}")]
        public JsonResult Register(char qType)
        {
            QueueService qService = new QueueService();
            Queue qNo = qService.Register((QueueType) qType);
            return new JsonResult(qNo);
        }
    }
}
