using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class LanguageModel
    {

        [Key]
        [Required]
        public string Language { get; set; }

    }
}
