using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class PeopleCityModel
    {
        [Key]
        [MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int PersonId { get; set; }

        public PersonModel person { get; set; }

        [Key]
        [Required]
        public string CityName { get; set; }

        public CityModel city { get; set; }
    }
}
