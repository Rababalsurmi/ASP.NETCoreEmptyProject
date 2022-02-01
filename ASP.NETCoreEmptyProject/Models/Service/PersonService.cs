using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NETCoreEmptyProject.Data;
using ASP.NETCoreEmptyProject.Models;
using ASP.NETCoreEmptyProject.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreEmptyProject.Service
{
    public class PersonService : IPersonService
    {
        private readonly PeopleDBContext _context;

        public PersonService(PeopleDBContext context)
        {
            _context = context;

        }
        public List<PersonModel> GetAllPeople()
        {
            return _context.People.Include(p => p.City)
                                    .ThenInclude(c => c.Country)
                                    .Include(l => l.PeopleLanguages)
                                    .ToList();
        }
        public PersonModel GetPersonById(int id)
        {
            var person = _context.People.Find(id);
            var personLanguages = _context.PeopleLanguages
                                    .Include(pl => pl.language)
                                    .Where(p => p.PersonId == id);
            person.City = _context.City.Find(person.City.CurrentCountryId);
            person.PeopleLanguages = _context.PeopleLanguages.ToList();
            return person;
        }
        public PersonModel GetPersonByName(string name)
        {
            return _context.People.AsQueryable().First(n => n.Name.Equals(name));
        }

        public void DeletePersonById(int id)
        {
            var person = GetPersonById(id);
            if (person is null) return;
            _context.People.Remove(person);
            _context.SaveChanges();
        }

        public void CreatePerson(CreatePersonViewModel vm)
        {
            var newPerson = new PersonModel
            {
                Name = vm.Name,
                City = _context.City.Find(vm.City),
                Phone = vm.Phone
            };
            _context.People.Add(newPerson);
            _context.SaveChanges();

            foreach(var languageId in vm.Languages)
            {
                _context.PeopleLanguages.Add(new PeoplLanguagesModel
                {
                    PersonId = newPerson.PersonId,
                    LanguageId = languageId

                });      
            }
            _context.SaveChanges();
            
        }

        
    }
}
