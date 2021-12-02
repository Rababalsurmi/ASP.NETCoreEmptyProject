using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Models;
using ASP.NETCoreEmptyProject.Data;


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
            List<PersonModel> ListOfPeople = _context.People.ToList();
            return View(ListOfPeople);
        }

        // GET: /<controller>/
        public IActionResult PeopleIndex()
        {
            PersonMemory personMemory = new PersonMemory();

            PeopleViewModel PeopleViewModel = new PeopleViewModel() { PeopleListView = personMemory.Read() };

            if(PeopleViewModel.PeopleListView.Count == 0 || PeopleViewModel.PeopleListView == null)
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

            foreach(Person p in personMemory.Read())
            {
                if(p.Name.Contains(viewModel.FilterString,
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

            if(ModelState.IsValid)
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
