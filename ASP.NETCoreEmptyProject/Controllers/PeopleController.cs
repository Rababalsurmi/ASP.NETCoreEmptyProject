using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    public class PeopleController : Controller
    {
        // GET: /<controller>/
        public IActionResult PeopleIndex()
        {
            if ( Person.listOfPeople.Count() < 1)
            {
                Person.GeneratePeople();
            }

            return View();
        }

        public IActionResult People()
        {
            Person person = new Person();

            return View(person);
        }

        public IActionResult ListAllPeople()
        {
            PeopleViewModel viewModel = new PeopleViewModel();

            viewModel.People = Person.listOfPeople;

            return View(viewModel);
        }
    }
}
