using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CountryCityModel
    {
        [Key]
        [MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int CountryId { get; set; }

        public CountryModel country { get; set; }

        [Key]
        [MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int CityId { get; set; }

        public CityModel city { get; set; }
    }
}
