using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NET_Core_Empty_Project.Models;
using ASP.NETCoreEmptyProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(ILogger<DoctorController> logger)
        {
            _logger = logger;
        }

        // GET: /<controller>/
        public IActionResult FeverCheck()
        {
            ViewBag.Message = FeverCheckModel.WriteMessage();
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(string name, float temperature)
        {
            FeverCheckModel fc = new FeverCheckModel();
            fc.Name = name;
            fc.Temperature = temperature;

            ViewBag.Message = fc.CheckTemperature(temperature);

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
