using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CreateCountryModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

       
    }
}
