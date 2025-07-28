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
        public string? COuntry { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public string? Type { get; set; }
        
        public Tournament(int id, string name, string country, DateTime startdate, DateTime enddate, string type)
        {
            Id = id;
            Name = name;
            Country = country;
            EndDate = enddate;
            Type = type;
        }

        public Tournament() { }

        public override string ToString()
        {
            return $"""
            Torneo: {Name}
            ID: {Id}
            País: {Country}
            Tipo de torneo: {Type}
            Fecha de inicio: {StartDate.ToShortDateString()}
            Fecha de finalización: {EndDate.ToShortDateString()}
            """;
        }
        
        public static List<Tournament> tournaments = new List<Tournament>();
        
        public static void AddTournament(Tournament tournament)
        {
            tournaments.Add(tournament);
        }
    }
}
