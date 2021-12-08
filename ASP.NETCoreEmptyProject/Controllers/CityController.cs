using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Data;
using ASP.NETCoreEmptyProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    public class CityController : Controller
    {

        // GET: /<controller>/
        private readonly PeopleDBContext _context;

        public CityController(PeopleDBContext context)
        {
            _context = context;

        }
        public IActionResult City()
        {
            List<CityModel> ListOfCities = _context.City.ToList();
            return View(ListOfCities);
        }
    }
}
