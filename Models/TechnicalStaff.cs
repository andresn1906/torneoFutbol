using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneoFutbol.Models
{
    public class TechnicalStaff : Person
    {
        public string? Job { get; set; }
        public int Exp { get; set; }

        public TechnicalStaff(string? id, string? idType, string? fullname, string? origin, string? email, int age, string? job, int exp) : base(id, idType, fullname, origin, email, age)
        {
            Id = id;
            IdType = idType;
            FullName = fullname;
            Origin = origin;
            Email = email;
            Job = job;
            Exp = exp;
            Age = age;
        }
        public TechnicalStaff() { }
        public static List<TechnicalStaff> teams = new List<TechnicalStaff>();
        public static void AddTechnicalStaff(TechnicalStaff technicalStaff)
        {
            teams.Add(technicalStaff);
        }
    }
}