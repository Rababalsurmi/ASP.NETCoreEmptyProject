using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class PeoplLanguagesModel
    {
        [Key]
        [MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int PersonId { get; set; }

        public PersonModel person { get; set; }

        [Key]
        [Required]
        public string Language { get; set; }

        public LanguageModel language { get; set; }


    }
}
