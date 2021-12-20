using System;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models
{
    public class LanguageViewModel : LanguageModel
    {
        public List<LanguageModel> LanguageListView { get; set; }

        public LanguageViewModel()
        {
            LanguageListView = new List<LanguageModel>();
        }
    }
}
