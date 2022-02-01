using System;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models.Interfaces
{
    public interface ILanguageService
    {
        public List<LanguageModel> GetAllLanguages();
        public LanguageModel GetLanguageById(int id);
        public LanguageModel GetLanguageByName(string name);
        public void DeleteLanguageById(int id);
        public void CreateLanguage(CreateLanguageViewModel vm);
    }
}
