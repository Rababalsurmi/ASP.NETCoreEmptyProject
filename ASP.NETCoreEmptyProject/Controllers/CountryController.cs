using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Data;
using ASP.NETCoreEmptyProject.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    public class CountryController : Controller
    {
        // GET: /<controller>/
        private readonly PeopleDBContext _context;

        public CountryController(PeopleDBContext context)
        {
            _context = context;

        }
        public IActionResult Country()
        {
            List<CountryModel> ListOfCountries = _context.Country.Include(c => c.Cities).ToList();
            return View(ListOfCountries);
        }

    }
}
