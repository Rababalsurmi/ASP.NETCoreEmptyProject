using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CreateCityViewModel
    {
        [Required]
        [DisplayName ("City Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Country ")]
        public int CountryId { get; set; }
    }
}
