using System;
using System.Collections.Generic;


namespace ASP.NETCoreEmptyProject.Models
{
    public class PeopleViewModel : CreatePersonViewModel
    {
        
        public List<Person> PeopleListView { get; set;}

        public string FilterString { get; set; }

        public PeopleViewModel()
        {
            PeopleListView = new List<Person>(); 
        }
    }
}
