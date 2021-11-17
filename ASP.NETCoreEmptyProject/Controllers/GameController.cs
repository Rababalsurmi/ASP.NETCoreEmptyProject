using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NET_Core_Empty_Project.Models;
using ASP.NETCoreEmptyProject.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        // GET: /<controller>/



        [HttpGet]
        public IActionResult GuessingGame()
        {
            ViewBag.GreetingMessage = GuessingGameModel.WriteGameMessage();

            Random random = new Random();
            int RndNum = random.Next(1, 100);

            HttpContext.Session.SetInt32("RandomNumber", RndNum);


            return View();
        }


        [HttpPost]
        public IActionResult GuessingGame(int number)
        {
            GuessingGameModel gmodel = new GuessingGameModel();


            ViewBag.SessionMessageRandom = HttpContext.Session.GetInt32("RandomNumber");

            HttpContext.Session.SetInt32("UserNumber", number);
            ViewBag.SessionMessageUser = HttpContext.Session.GetInt32("UserNumber");

            var rnd = HttpContext.Session.GetInt32("RandomNumber");
            var userInput = HttpContext.Session.GetInt32("UserNumber");


            if (rnd == userInput)
            {
                ViewBag.GameMessage = gmodel.Success();
            }
            else if (rnd > userInput)
            {
                ViewBag.GameMessage = gmodel.WasLow();
            }
            else if (rnd < userInput)
            {
                ViewBag.GameMessage = gmodel.WasHigh();
            }


            return View();
        }


        //public IActionResult SetSession()
        //{

        //    HttpContext.Session.SetString("TestSession", "Session was set for 10 minutes!");   
        //    return View();
        //}

        //public IActionResult GetSession()
        //{
        //    ViewBag.SessionMessage = HttpContext.Session.GetString("RandomNumber");
        //    return View();
        //}
    }
}
