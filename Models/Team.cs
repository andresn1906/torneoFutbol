using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneoFutbol.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Type { get; set; }

        public Team(int id, string? name, string? country, string? type)
        {
            Id = id;
            Name = name;
            Country = country;
            Type = type;
        }
        public Team() { }
        public static List<Team> teams = new List<Team>();
        public static void AddTeam(Team team)
        {
            teams.Add(team);
        }
        public override string ToString()
        {
            return $"Id: {Id}, Nombre: \"{Name}\", País: {Country}, Tipo: \"{Type}\".";
        }
    }
}