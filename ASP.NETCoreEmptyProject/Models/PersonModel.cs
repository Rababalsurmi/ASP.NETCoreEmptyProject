using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreEmptyProject.Models
{
    public class PersonModel
    {
        public PersonModel()
        {
            this.PeopleLanguages = new List<PeoplLanguagesModel>();
        }

        [Key]
        [MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int PersonId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public int Phone { get; set; }

        //[Required]
        //public string City { get; set; }

        //public List<PeopleCityModel>PeopleCity { get; set; }

        public CityModel City { get; set; }

        public int CurrentCityId { get; set; }

        public virtual List<PeoplLanguagesModel> PeopleLanguages { get; set; }
    }
}
