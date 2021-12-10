using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CountryModel
    {

        //[MaxLength(6, ErrorMessage = "Needs to be a valid Number!")]
        //public int CountryNum { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int CountryId { get; set; }

        [Required]
        public string CountryName { get; set; }

        public List<CityModel> Cities { get; set; }

        public CountryModel()
        {
            Cities = new List<CityModel>();
        }

    }
}
