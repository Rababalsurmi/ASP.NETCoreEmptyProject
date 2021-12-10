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
            List<LanguageModel> ListOfLanguages = _context.Languages.Include(l => l.PeopleLanguages).ToList();
            return View(ListOfLanguages);
        }
        public IActionResult CreateNewLanguage()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateNewLanguage(LanguageModel lang)
        {
            if (ModelState.IsValid)
            {
                _context.Languages.Add(lang);
                _context.SaveChanges();
                return RedirectToAction("Language");
            }
            return View();
        }


    }
}
