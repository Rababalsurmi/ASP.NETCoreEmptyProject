using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Data;
using ASP.NETCoreEmptyProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    [Authorize(Roles = "Admin")]
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
            List<CityModel> ListOfCities = _context.City.Include(c => c.People).ToList();
            return View(ListOfCities);
        }

        public IActionResult CreateCity()
        {
            ViewBag.CountryId = _context.Country.Select(a => new SelectListItem
            {
                Text = a.CountryName,
                Value = a.CountryName
            }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateCity(CityModel city)
        {
            if (ModelState.IsValid)
            {
                _context.City.Add(city);
                _context.SaveChanges();
                return RedirectToAction("City");
            }
            return View();
        }
        public IActionResult EditCity(int cityid)
        {
            var CityData = _context.City.Where(x => x.CityId == cityid).FirstOrDefault();
            if (CityData != null)
            {
                ViewBag.CountryId = _context.Country.Select(a => new SelectListItem
                {
                    Text = a.CountryName,
                    Value = a.CountryName
                }).ToList();
                TempData["CityID"] = cityid;
                TempData.Keep();
                return View(CityData);
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditCity(CityModel city)
        {
            int cityID = (int)TempData["CityID"];
            var CityData = _context.City.Where(x => x.CityId == cityID).FirstOrDefault();

            if (CityData != null)
            {
                CityData.CityName = city.CityName;
                CityData.Country.CountryName = city.Country.CountryName;
                
                _context.Entry(CityData).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("City");
        }

        public IActionResult DeleteCity(int cityid)
        {
            if (cityid > 0)
            {
                var citybyid = _context.City.Where(x => x.CityId == cityid).FirstOrDefault();
                if (citybyid != null)
                {
                    _context.Entry(citybyid).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("City");
        }
    }
}
