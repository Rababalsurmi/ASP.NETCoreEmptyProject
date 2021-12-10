using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CityModel
    {
        //[MaxLength(6, ErrorMessage = "Needs to be a valid Number!")]
        //public int CityNum { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int CityId { get; set; }

        
        [Required]
        public string CityName { get; set; }

        public List<PersonModel> People { get; set; }

        //public List<CountryCityModel> CountryCity { get; set; }

        
        public CountryModel Country { get; set; }

        [Required]
        public int CurrentCountryId { get; set; }


    }
}
