using System;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models
{
    public class CityViewModel : CityModel
    {
        public List<CityModel> CityListView { get; set; }
        public CityViewModel()
        {
            CityListView = new List<CityModel>();
        }
    }
}
