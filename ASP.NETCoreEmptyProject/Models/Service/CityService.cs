using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NETCoreEmptyProject.Data;
using ASP.NETCoreEmptyProject.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreEmptyProject.Models.Service
{
    public class CityService : ICityService
    {
        private readonly PeopleDBContext _context;
        public CityService(PeopleDBContext context)
        {
            _context = context;
        }

        public List<CityModel> GetAllCities()
        {
            return _context.City.Include(c => c.Country).ToList();
        }
        public CityModel GetCityById(int id)
        {
            return _context.City.Find(id);
        }
        public CityModel GetCityByName(string name)
        {
            return _context.City.First(n => n.CityName.Equals(name));
        }
        public void DeleteCityById(int id)
        {
            var city = GetCityById(id);
            _context.City.Remove(city);
            _context.SaveChanges();
        }
        public void CreateCity(CreateCityViewModel vm)
        {
            _context.City.Add(
                new CityModel { CityName = vm.Name, Country = _context.Country.Find(vm.CountryId) });
            _context.SaveChanges();

        }
    }
}
