using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NETCoreEmptyProject.Data;
using ASP.NETCoreEmptyProject.Models.Interfaces;

namespace ASP.NETCoreEmptyProject.Models.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly PeopleDBContext _context;
        public LanguageService(PeopleDBContext context)
        {
            _context = context;
        }
        public List<LanguageModel> GetAllLanguages()
        {
            return _context.Languages.ToList();
        }
        public LanguageModel GetLanguageById(int id)
        {
            return _context.Languages.Find(id);
        }
        public LanguageModel GetLanguageByName(string name)
        {
            return _context.Languages.First(n => n.Language.Equals(name));
        }
        public void DeleteLanguageById(int id)
        {
            var l = GetLanguageById(id);
            _context.Languages.Remove(l);
            _context.SaveChanges();
        }
        public void CreateLanguage(CreateLanguageViewModel vm)
        {
            _context.Languages.Add(
               new LanguageModel { Language = vm.Name });
            _context.SaveChanges();
        }
    }
}
