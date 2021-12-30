using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Models;
using ASP.NETCoreEmptyProject.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    public class ReactController : Controller
    {
        private readonly PeopleDBContext _context;

        public ReactController(PeopleDBContext context)
        {
            _context = context;

        }

        // GET: /<controller>/
        public IActionResult ReactIndex()
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            List<PersonModel> ListOfPeople = _context.People
                                               .Include(p => p.City)
                                               .Include(l => l.PeopleLanguages)
                                               .ToList();

            
            return View("ReactIndex", ListOfPeople);
        }
    }
}
