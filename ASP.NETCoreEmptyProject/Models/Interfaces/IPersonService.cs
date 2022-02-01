using System;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models.Interfaces
{
    public interface IPersonService
    {
        public List<PersonModel> GetAllPeople();
        public PersonModel GetPersonById(int id);
        public PersonModel GetPersonByName(string name);
        public void DeletePersonById(int id);
        public void CreatePerson(CreatePersonViewModel vm);

    }
}
