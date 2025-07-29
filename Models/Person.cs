using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneoFutbol.Models
{
    public class Person
    {
        public string? Id { get; set; }
        public string? IdType { get; set; }
        public string? FullName { get; set; }
        public string? Origin { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }

        public Person(string? id, string? idType, string? fullname, string? origin, string? email, int age)
        {
            Id = id;
            IdType = idType;
            FullName = fullname;
            Origin = origin;
            Email = email;
            Age = age;
        }
        public Person() { }
    }
}   