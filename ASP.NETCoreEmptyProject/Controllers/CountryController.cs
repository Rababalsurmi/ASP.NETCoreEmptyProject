using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Data;
using ASP.NETCoreEmptyProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public IActionResult CreateCountry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCountry(CountryModel country)
        {
            CountryViewModel newViewModel = new CountryViewModel();
            List<CountryModel> ListOfCountries = _context.Country.Include(c => c.Cities).ToList();

            if (ModelState.IsValid)
            {
                _context.Country.Add(country);
                _context.SaveChanges();
                newViewModel.CountryListView = ListOfCountries;
                return RedirectToAction("Country", newViewModel);
            }
            return View();
        }
        public IActionResult EditCountry(String countryName)
        {
            var Countrydata = _context.Country.Where(x => x.CountryName == countryName).FirstOrDefault();
            if (Countrydata != null)
            {
                TempData["CountryName"] = countryName;
                TempData.Keep();
                return View(Countrydata);
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditCountry(CountryModel country)
        {
            String countryName = (string)TempData["CountryName"];
            var Countrydata = _context.Country.Where(x => x.CountryName == countryName).FirstOrDefault();
            if (Countrydata != null)
            {
                Countrydata.CountryName = country.CountryName;
                
                _context.Entry(Countrydata).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Country");
        }

        public IActionResult DeleteCountry(string countryName)
        {
            if (countryName != null || countryName != "")
            {
                var countrybyName = _context.Country.Where(x => x.CountryName == countryName).FirstOrDefault();

                if (countrybyName != null)
                {
                    _context.Entry(countrybyName).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Country");
        }

    }
}
