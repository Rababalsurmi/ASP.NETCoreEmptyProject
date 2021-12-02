using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CountryModel
    {
        
        //[MaxLength(6, ErrorMessage = "Needs to be a valid Number!")]
        //public int CountryNum { get; set; }

        [Key]
        [Required]
        public string CountryName { get; set; }

        public List<CountryCityModel> CountryCity { get; set; }

    }
}
