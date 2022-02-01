using System;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models.Interfaces
{
    public interface ICityService
    {
        public List<CityModel> GetAllCities();
        public CityModel GetCityById(int id);
        public CityModel GetCityByName(string name);
        public void DeleteCityById(int id);
        public void CreateCity(CreateCityViewModel vm);
    }
}
