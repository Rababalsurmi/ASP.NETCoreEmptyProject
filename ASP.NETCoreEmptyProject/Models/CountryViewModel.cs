using System;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CountryViewModel : CountryModel
    {
        public List<CountryModel> CountryListView { get; set; }

        public CountryViewModel()
        {
            CountryListView = new List<CountryModel>();
        }
    }
}
