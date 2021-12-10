using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class PeoplLanguagesModel
    {
        [Key]
        [MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public long PersonId { get; set; }

        public PersonModel person { get; set; }

        [Key]
        [MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int LanguageId { get; set; }

        public LanguageModel language { get; set; }


    }
}
