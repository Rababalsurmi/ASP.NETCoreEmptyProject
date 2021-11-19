using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    public class AjaxController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            PersonMemory personMemory = new PersonMemory();
            List<Person> peopleList = personMemory.Read();

            return PartialView("_PeopleListPartial", peopleList);
        }

        [HttpPost]
        public IActionResult FindPersonById(int personID)
        {
            PersonMemory personMemory = new PersonMemory();
            Person targetPerson = personMemory.Read(personID);
            List<Person> people = new List<Person>();

            if(targetPerson != null)
            {
                people.Add(targetPerson);
            }
            return PartialView("_PeopleListPartial", people);
        }
    }
}
