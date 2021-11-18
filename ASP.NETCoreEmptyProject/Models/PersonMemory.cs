using System;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models
{
    public class PersonMemory
    {
        private static List<Person> _personList= new List<Person>();
        private static int _idCounter;

        public void SeedPeople()
        {
            PersonMemory personMemory = new PersonMemory();
            personMemory.Create("Edward", 92837465, "Malmö");
            personMemory.Create("Tom", 92837465, "Malmö");
            personMemory.Create("Marie", 92837465, "Malmö");

            personMemory.Create("Lucas", 849210643, "Göteborg");
            personMemory.Create("Stina", 849210643, "Göteborg");
            personMemory.Create("Sabina", 849210643, "Göteborg");
            personMemory.Create("John", 849210643, "Göteborg");

            personMemory.Create("Alex", 37291028, "Jönköping");
            personMemory.Create("Simon", 37291028, "Jönköping");
            personMemory.Create("Ahmen", 37291028, "Jönköping");
            personMemory.Create("Ali", 37291028, "Jönköping");

            personMemory.Create("Hugo", 38097654, "Kungälv");
            personMemory.Create("George", 38097654, "Kungälv");
        }

        public Person Create(string name, int phone, string city)
        {
            Person newPerson = new Person(_idCounter, name, phone, city);
            _personList.Add(newPerson);
            _idCounter++;

            return newPerson;
        }

        public bool Delet(Person person)
        {
            bool status = _personList.Remove(person);

            return status;
        }

        public List<Person> Read()
        {
            return _personList;
        }

        public Person Read(int id)
        {
            Person targetPerson = _personList.Find(p => p.PersonId == id);

            return targetPerson;
        }

        public Person Read(string name, string city)
        {
            Person targetPerson = _personList.Find(p => p.Name == name || p.City == city);

            return targetPerson;
        }

        //public Person Read(string city)
        //{
        //    Person targetPerson = _personList.Find(p => p.City == city);

        //    return targetPerson;
        //}
    }
}
