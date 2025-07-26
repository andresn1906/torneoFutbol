using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneoFutbol
{
    public class Tournament
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public Tournament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Tournament() { }

        public override string ToString()
        {
            return $"""
            Torneo: {Name}
            ID: {Id}
            Iniciado: {StartDate.ToShortDateString()}
            """;
        }
        public static List<Tournament> tournaments = new List<Tournament>();
        public static void AddTournament(Tournament tournament)
        {
            tournaments.Add(tournament);
        }
    }
}