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
        [Required]
        public string Language { get; set; }

        public virtual List<PeoplLanguagesModel> PeopleLanguages { get; set; }
    }

}

