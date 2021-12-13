using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Models;
using ASP.NETCoreEmptyProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleDBContext _context;

        public PeopleController(PeopleDBContext context)
        {
            _context = context;

        }
        public IActionResult People()
        {
            List<PersonModel> ListOfPeople = _context.People
                                                .Include(p => p.City)
                                                .Include(l => l.PeopleLanguages)
                                                .ToList();
            return View(ListOfPeople);
        }

       
        public IActionResult CreateNewPerson()
        {
            ViewBag.CityId = _context.City.Select(a => new SelectListItem
            {
                Text = a.CityName,
                Value = a.CityName
            }).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult CreateNewPerson(PersonModel person)
        {
            if(ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("People");
            }
            return View();
        }

        public IActionResult EditExistingPerson(int personId)
        {
            var PersonData = _context.People.Where(x => x.PersonId == personId).FirstOrDefault();
            if (PersonData != null)
            {
                ViewBag.CityId = _context.City.Select(a => new SelectListItem
                {
                    Text = a.CityName,
                    Value = a.CityName
                }).ToList();
                TempData["PersonId"] = personId;
                TempData.Keep();
                return View(PersonData);
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditExistingPerson(PersonModel person)
        {
            int personID = (int)TempData["PersonId"];
            var PersonData = _context.People.Where(x => x.PersonId == personID).FirstOrDefault();

            if (PersonData != null)
            {
                PersonData.Name = person.Name;
                PersonData.Phone = person.Phone;
                PersonData.City.CityName = person.City.CityName;

                _context.Entry(PersonData).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("People");
        }

        public IActionResult DeleteExistingPerson(int personId)
        {
            if (personId > 0)
            {
                var personbyId = _context.People.Where(x => x.PersonId == personId).FirstOrDefault();
                if (personbyId != null)
                {
                    _context.Entry(personbyId).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("People");
        }

        // GET: /<controller>/
        public IActionResult PeopleIndex()
        {
            PersonMemory personMemory = new PersonMemory();

            PeopleViewModel PeopleViewModel = new PeopleViewModel() { PeopleListView = personMemory.Read() };

            if (PeopleViewModel.PeopleListView.Count == 0 || PeopleViewModel.PeopleListView == null)
            {
                personMemory.SeedPeople();
            }

            //if ( Person.listOfPeople.Count() < 1)
            //{
            //    Person.GeneratePeople();
            //}

            return View(PeopleViewModel);
        }

        [HttpPost]
        public IActionResult PeopleIndex(PeopleViewModel viewModel)
        {
            PersonMemory personMemory = new PersonMemory();
            viewModel.PeopleListView.Clear();

            foreach (Person p in personMemory.Read())
            {
                if (p.Name.Contains(viewModel.FilterString,
                    StringComparison.OrdinalIgnoreCase) ||
                    p.City.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase))
                {
                    viewModel.PeopleListView.Add(p);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel cPersonViewModel)
        {
            PeopleViewModel newViewModel = new PeopleViewModel();

            PersonMemory personMemory = new PersonMemory();

            if (ModelState.IsValid)
            {
                newViewModel.Name = cPersonViewModel.Name;
                newViewModel.Phone = cPersonViewModel.Phone;
                newViewModel.City = cPersonViewModel.City;

                newViewModel.PeopleListView = personMemory.Read();

                personMemory.Create(cPersonViewModel.Name, cPersonViewModel.Phone, cPersonViewModel.City);
                ViewBag.Message = "A new Person was added Successfully";

                return View("PeopleIndex", newViewModel);
            }

            ViewBag.Message = "Failed to add a new person!" + ModelState.Values;

            return View("PeopleIndex", newViewModel);
        }

        public IActionResult DeletePerson(int id)
        {
            PersonMemory personMemory = new PersonMemory();

            Person targetPerson = personMemory.Read(id);
            personMemory.Delet(targetPerson);

            return RedirectToAction("PeopleIndex");
        }

        public PartialViewResult PeopleList()
        {
            return PartialView("_PeopleListPartial");
        }


        public IActionResult ListAllPeople()
        {
            PeopleViewModel viewModel = new PeopleViewModel();

            viewModel.PeopleListView = Person.listOfPeople;

            return View(viewModel);
        }



    }

}

