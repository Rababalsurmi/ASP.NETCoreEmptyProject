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
    public class LanguageController : Controller
    {
        // GET: /<controller>/
        private readonly PeopleDBContext _context;

        public LanguageController(PeopleDBContext context)
        {
            _context = context;

        }
        public IActionResult Language()
        {
            List<PeoplLanguagesModel> ListOfLanguages = _context.PeopleLanguages.ToList();
            return View(ListOfLanguages);
        }


    }
}
