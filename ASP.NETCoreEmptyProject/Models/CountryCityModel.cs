using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CountryCityModel
    {
        [Key]
        [Required]
        public string CountryName { get; set; }

        public CountryModel country { get; set; }

        [Key]
        [Required]
        public string CityName { get; set; }

        public CityModel city { get; set; }
    }
}
