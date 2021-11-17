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
            GuessingGameModel model = new GuessingGameModel();

            ViewBag.GreetingMessage = GuessingGameModel.WriteGameMessage();

            model.RandomNumber();
            
            HttpContext.Session.SetString("RandomNumber", "The Random Number is: " + model.RndNum + "");

            return View();
        }

        
        [HttpPost]
        public IActionResult GuessingGame(GuessingGameModel model)
        {
            int number = model.GuessedNum;

          
            
            //var random = model.RndNum;
            
            ViewBag.SessionMessage = HttpContext.Session.GetString("RandomNumber");

            ViewBag.GameMessage = model.CheckNumber(number);

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
