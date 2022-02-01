using System;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public List<string> Languages { get; set; }

    }
}
