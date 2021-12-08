using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class LanguageModel
    {

        public LanguageModel()
        {
            this.PeopleLanguages = new List<PeoplLanguagesModel>();
        }

        [Key]
        [MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int LanguageId { get; set; }

        
        [Required]
        public string Language { get; set; }

        public virtual List<PeoplLanguagesModel> PeopleLanguages { get; set; }
    }

}

