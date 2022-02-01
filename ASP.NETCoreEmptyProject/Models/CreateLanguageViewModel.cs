using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CreateLanguageViewModel
    {
        [Required]
        [DisplayName("Language")]
        public string Name { get; set; }
    }
}
