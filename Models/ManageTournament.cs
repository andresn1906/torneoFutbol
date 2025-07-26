using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneoFutbol
{
    public class ManageTournament
    {
        public static void ManageTournaments()
        {
            Console.Clear();
            uiModels.tournamentMenu();

            string? tournamentOption = Console.ReadLine();

            switch (tournamentOption)
            {
                case "1":
                    Console.Clear();
                    Tournament tournament = new Tournament();
                    Console.WriteLine("--------- Añadir Torneo ---------");
                    Console.Write($"Id del torneo: ");
                    tournament.Id = int.Parse(Console.ReadLine() ?? "0");
                    if (tournament.Id <= 0)
                    {
                        Console.WriteLine("❌ Id Inválido ");
                        Console.ReadKey();
                        return;
                    }
                    foreach (Tournament t in Tournament.tournaments)
                    {
                        if (t.Id == tournament.Id)
                        {
                            Console.WriteLine("Ese Id ya está en uso. Por favor, elija otro.");
                            Console.ReadKey();
                            return;
                        }
                    }
                    Console.Write("Ingrese el nombre del torneo: ");
                    tournament.Name = Console.ReadLine();
                    if (string.IsNullOrEmpty(tournament.Name))
                    {
                        Console.WriteLine("El nombre del torneo no puede estar vacío.");
                        Console.ReadKey();
                        return;
                    }
                    tournament.StartDate = DateTime.Now;
                    Console.WriteLine($"Se ha creado el torneo: \"{tournament.Name}\" con ID: \"{tournament.Id}\".");
                    Tournament.AddTournament(tournament);
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Lista de Torneos:");
                    foreach (Tournament t in Tournament.tournaments)
                    {
                        Console.WriteLine($"{t.ToString()}");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("--------- Buscar Torneo ---------");
                    Console.Write("Ingrese el ID del torneo a buscar: ");
                    int searchId = int.Parse(Console.ReadLine() ?? "0");
                    Tournament? foundTournament = Tournament.tournaments.FirstOrDefault(t => t.Id == searchId);
                    if (foundTournament != null)
                    {
                        Console.WriteLine($"Torneo encontrado:\n{foundTournament.ToString()}");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("❌ Torneo no encontrado ❌");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;

                case "3":
                    Console.WriteLine("--------- Eliminar Torneo ---------");
                    Console.WriteLine("Ingrese el Id del torneo a eliminar: ");
                    int eliminarId = Convert.ToInt32(Console.ReadLine());
                    Tournament? idEncontrado = Tournament.tournaments.Find(t => t.Id == eliminarId);
                    if (idEncontrado != null)
                    {
                        while (true)
                        {
                            Console.WriteLine("¿Está seguro de eliminarlo? (si/no)");
                            string? eliminar = Console.ReadLine();
                            if (eliminar?.ToLower() != "si")
                            {
                                break;
                            }
                            else
                            {
                                Tournament.tournaments.Remove(idEncontrado);
                                Console.WriteLine("El torneo ha sido eliminado.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("El torneo con ese ID no existe.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                    
                case "4":
                    Console.WriteLine("Actualizar Torneo seleccionado.");
                    // Aquí iría la lógica para actualizar un torneo
                    break;
                case "5":
                    Console.WriteLine("Regresando... ");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opción inválida, reintenta.");
                    break;
            }           
        }
    }
}