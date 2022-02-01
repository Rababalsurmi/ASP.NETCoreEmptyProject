using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETCoreEmptyProject.Models
{
    public class PersonModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[MaxLength(10, ErrorMessage = "Needs to be a valid ID!")]
        public int PersonId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        //[MaxLength(10)]
        public int Phone { get; set; }

        //[Required]
        //public string CityName { get; set; }

        //public List<PeopleCityModel>PeopleCity { get; set; }


        public int CurrentCityId { get; set; }
        public CityModel City { get; set; }


        public virtual List<PeoplLanguagesModel> PeopleLanguages { get; set; }


        public PersonModel()
        {
            this.PeopleLanguages = new List<PeoplLanguagesModel>();
        }


        public PersonModel(string name, CityModel city, int phone)
        {
            Name = name;
            City = city;
            Phone = phone;
        }


        public PersonModel(int id, string name, CityModel city, int cityId, int phone)
        {
            PersonId = id;
            Name = name;
            City = city;
            CurrentCityId = cityId;
            Phone = phone;
        }


        public PersonModel(int id, string name, int phone)
        {
            PersonId = id;
            Name = name;
            Phone = phone;
        }

        

    }
}
