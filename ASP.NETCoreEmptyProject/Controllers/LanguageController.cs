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
            ViewBag.PersonId = _context.People.Select(a => new SelectListItem
            {
                Text = a.PersonId.ToString(),
                Value = a.PersonId.ToString()
            }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewLanguage(LanguageModel lang)
        {
            LanguageViewModel newViewModel = new LanguageViewModel();
            List<LanguageModel> ListOfLanguages = _context.Languages.Include(l => l.PeopleLanguages).ToList();

            if (ModelState.IsValid)
            {
                _context.Languages.Add(lang);
                _context.SaveChanges();
                
                newViewModel.LanguageListView = ListOfLanguages;
                return RedirectToAction("Language", newViewModel);
            }
            return View();
        }
        public IActionResult DeleteLanguage(int langid)
        {
            if (langid > 0)
            {
                var langbyid = _context.Languages.Where(x => x.LanguageId == langid).FirstOrDefault();
                if (langbyid != null)
                {
                    _context.Entry(langbyid).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Language");
        }


    }
}
