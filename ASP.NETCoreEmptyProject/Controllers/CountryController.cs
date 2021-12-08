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
            List<CountryModel> ListOfCountries = _context.Country.ToList();
            return View(ListOfCountries);

            //CountryModel viewModel = new CountryModel();

            //viewModel.Cities = _context.City.ToList();

            //return View(viewModel);
        }

    }
}
