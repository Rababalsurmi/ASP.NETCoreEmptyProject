using System;
using System.Linq;
using System.Collections.Generic;

namespace ASP.NETCoreEmptyProject.Models
{
    public class Person
    {
        private readonly int _personId;
        public int PersonId { get { return _personId; } }

        public string Name { get; set; }

        public int Phone { get; set; }

        public string City { get; set; }

        public static List<Person> listOfPeople = new List<Person>();

        public static void GeneratePeople()
        {
            listOfPeople.AddRange(new List<Person> {
                new Person {Name = "Sam", Phone = 1234567, City = "Göteborg"},
                new Person {Name = "Tom", Phone = 5436789, City = "Stockholm"},
                new Person {Name = "Kalle", Phone = 056432467, City = "Skövde"}
            });
        }

        public Person()
        {

        }
        public Person (int id, string name, int phone, string city)
        {
            this._personId = id;
            Name = name;
            Phone = phone;
            City = city;
        }
    }
}
