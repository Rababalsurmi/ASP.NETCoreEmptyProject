using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreEmptyProject.Models;
using ASP.NETCoreEmptyProject.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ASP.NETCoreEmptyProject.Models.Interfaces;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreEmptyProject.Controllers
{

    public class ReactController : Controller
    {
        private readonly PeopleDBContext _context;

        private readonly IPersonService _personService;
        private readonly ICityService _cityService;
        private readonly ILanguageService _languageService;

        public ReactController(IPersonService personService, ICityService cityService, ILanguageService languageService)
        {
            _personService = personService;
            _cityService = cityService;
            _languageService = languageService;

        }

        // GET: /<controller>/
        
        public IActionResult ReactIndex()
        {
           
            return View();
        }

        [HttpGet]
        [Route("/React/People")]
        public IActionResult GetPeople()
        {
            var people = _personService.GetAllPeople();

            var dto = new List<PersonDTO>();
            foreach(var p in people)
            {
                dto.Add(
                    new PersonDTO
                    {
                        Id = p.PersonId,
                        Name = p.Name,
                        CityName = p.City.CityName,
                        CountryName = p.City.Country.CountryName,
                        Phone = p.Phone,
                        Languages = new List<string>()
                        
                    });
            }

            return Ok(JsonConvert.SerializeObject(dto));
            
        }

        [HttpGet]
        [Route("/React/People/{id:int}")]
        public IActionResult GetPersonById(int id)
        {
            PersonModel person = _personService.GetPersonById(id);
            var languages = new List<string>();
            foreach(var pl in person.PeopleLanguages)
            {
                languages.Add(pl.language.Language);
            }
            var dto = new PersonDTO
            {
                Id = person.PersonId,
                Name = person.Name,
                Phone = person.Phone,
                CityName = person.City.CityName,
                CountryName = person.City.Country.CountryName,
                Languages = languages

            };
            return Ok(JsonConvert.SerializeObject(dto));
        }


        [HttpPost]
        [Route("/React/People/Create")]
        public IActionResult CreatePerson([FromBody] CreatePersonViewModel pVm)
        {
            _personService.CreatePerson(pVm);

            return Ok();
        }

        [HttpDelete]
        [Route("/React/People/{id:int}")]
        public IActionResult DeletePerson(int id)
        {
            try
            {
                _personService.DeletePersonById(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/React/Cities")]
        public IActionResult GetCities()
        {
            var cities = _cityService.GetAllCities();

            var dto = new List<CityDTO>();
            foreach (var c in cities)
            {
                dto.Add(
                    new CityDTO
                    {
                        Id = c.CityId,
                        CityName = c.CityName,
                        CountryName = c.Country.CountryName,
                        CountryId = c.Country.CountryId

                    });
            }

            return Ok(JsonConvert.SerializeObject(dto));

        }

        [HttpGet]
        [Route("/React/Languages")]
        public IActionResult GetLanguages()
        {
            var languages = _languageService.GetAllLanguages();

            var dto = new List<LanguageDTO>();
            foreach (var l in languages)
            {
                dto.Add(
                    new LanguageDTO
                    {
                        Id = l.LanguageId,
                        Language = l.Language

                    });
            }

            return Ok(JsonConvert.SerializeObject(dto));

        }
    }
}
