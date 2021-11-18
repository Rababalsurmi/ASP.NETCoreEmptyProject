using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ASP.NETCoreEmptyProject.Models
{
    public class CreatePersonViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please enter a name!"), MaxLength(50), MinLength(3)]
        [Display(Name = "Person Name")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="Enter Phone Number!")]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a city!"), MaxLength(50), MinLength(3)]
        [Display(Name = "City")]
        public string City { get; set; }
    }
}
