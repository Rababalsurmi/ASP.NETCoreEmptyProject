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

        
        public IActionResult GuessingGame()
        {
            ViewBag.GameMessage = GuessingGameModel.WriteMessage();
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int number)
        {
            GuessingGameModel gModel = new GuessingGameModel();
            gModel.GuessedNum = number;
           // int randomNumber = gModel.RndNum;
           
            HttpContext.Session.SetString("RandomNumber", ""+ gModel.RndNum + "");

            ViewBag.GameMessage = gModel.CheckNumber(number);

            ViewBag.SessionMessage = HttpContext.Session.GetString("RandomNumber");

            return View();
        }

        //public IActionResult SetSession()
        //{
            
        //    HttpContext.Session.SetString("TestSession", "Session was set for 10 minutes!");   
        //    return View();
        //}

        public IActionResult GetSession()
        {
            ViewBag.SessionMessage = HttpContext.Session.GetString("RandomNumber");
            return View();
        }
    }
}
