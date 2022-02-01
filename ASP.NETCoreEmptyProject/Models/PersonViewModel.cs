using System;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public CityModel City { get; set; }

        public int Phone { get; set; }

        public List<PeoplLanguagesModel> PersonLanguage { get; set; }
    }
}
