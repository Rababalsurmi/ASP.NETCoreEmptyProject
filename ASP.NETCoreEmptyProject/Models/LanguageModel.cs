using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETCoreEmptyProject.Models
{
    public class LanguageModel
    {

        public LanguageModel()
        {
            this.PeopleLanguages = new List<PeoplLanguagesModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int LanguageId { get; set; }

        
        [Required]
        public string Language { get; set; }

        public virtual List<PeoplLanguagesModel> PeopleLanguages { get; set; }
    }

}

