using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CityModel
    {
        //[MaxLength(6, ErrorMessage = "Needs to be a valid Number!")]
        //public int CityNum { get; set; }

        [Key]
        [Required]
        public string CityName { get; set; }

        public List<PeopleCityModel> PeopleCity { get; set; }

        public List<CountryCityModel> CountryCity { get; set; }
    }
}
