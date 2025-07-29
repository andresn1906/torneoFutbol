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
        public string? Country { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Type { get; set; }
        
        public Tournament(int id, string name, string country, DateOnly startdate, DateOnly enddate, string type)
        {
            Id = id;
            Name = name;
            Country = country;
            StartDate = startdate;
            EndDate = enddate;
            Type = type;
        }

        public Tournament() { }

        public override string ToString()
        {
            return $"""
            Torneo: "{Name}"
            ID: {Id}
            País: "{Country}"
            Tipo de torneo: "{Type}"
            Fecha de inicio: {StartDate.ToShortDateString()}
            Fecha de finalización: {EndDate.ToShortDateString()}
            Registro del torneo: {DateTime.Now.ToShortDateString()}
            """;
        }
        
        public static List<Tournament> tournaments = new List<Tournament>();
        
        public static void AddTournament(Tournament tournament)
        {
            tournaments.Add(tournament);
        }
    }
}
