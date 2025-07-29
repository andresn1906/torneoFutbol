using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.DataContracts;
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
                    Console.WriteLine("======= Añadir Torneo =========");

                    Console.Write($"Id del torneo: ");
                    string? idInput = Console.ReadLine();
                    if (!int.TryParse(idInput, out int id) || id <= 0)
                        {
                            Console.Write("❌ El Id debe ser un número válido mayor a cero.");
                            Console.ReadKey();
                            return;
                        }
                    else
                        {
                            tournament.Id = id;
                            Console.Clear();
                        }  
                    foreach (Tournament t in Tournament.tournaments)
                    {
                        if (t.Id == tournament.Id)
                        {
                            Console.Write("⚠ Ese Id registra a otro torneo ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    }
                        
                    Console.Write("Ingrese el nombre del torneo: ");
                    tournament.Name = Console.ReadLine();
                    if (string.IsNullOrEmpty(tournament.Name))
                        {
                            Console.Write("⚠ El nombre del torneo no puede estar vacío ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    else
                        {
                            Console.Clear();
                        }
                    
                    foreach (Tournament t in Tournament.tournaments)
                        {
                            if (t.Name == tournament.Name)
                                {
                                    Console.Write("⚠ Ese nombre ya está en uso ⚠.");
                                    Console.ReadKey();
                                    return;
                                }
                            else
                            {
                                Console.Clear();
                            }    
                        }
                    
                    Console.Write("""
                    ======= Tipo de torneo =======
                    1 ---> Torneo local
                    2 ---> Torneo internacional
                    ==============================

                    Seleccione el tipo de torneo (1 ó 2): 
                    """);
                    string? optionType = Console.ReadLine();
                    if (string.IsNullOrEmpty(optionType))
                        {
                            Console.Write("⚠ No se puede dejar el campo vacío ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    else
                        {
                            if (optionType == "1")
                                {
                                    tournament.Type = "Local";
                                    Console.Clear();
                                }
                            else if (optionType == "2")
                                {
                                    tournament.Type = "Internacional";
                                    Console.Clear();
                                }
                            else
                                {
                                    Console.Write("❌ Opción inválida. Digite una opción entre \"1\" y \"2\".");
                                    Console.ReadKey();
                                    return;
                                }
                        }

                    Console.Write("Ingrese el país donde se desarrollará el torneo: ");
                    tournament.Country = Console.ReadLine();
                    if (string.IsNullOrEmpty(tournament.Country))
                        {
                            Console.Write("⚠ El campo no puede estar vacío ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    else if (tournament.Country.Length < 3)
                    {
                        Console.Write("⚠ El país debe contener al menos 3 caracteres ⚠.");
                        Console.ReadKey();
                        return;
                    }    
                    else
                        {
                            Console.Clear();
                        }

                    Console.Write($"Digite la fecha de inicio del torneo:\n\"(Formato: DD/MM/YYYY)\": ");
                    string? startDateInput = Console.ReadLine();
                    if (DateOnly.TryParse(startDateInput, out DateOnly startDate))
                        {
                            tournament.StartDate = startDate;
                            Console.Clear();
                        }
                    else if (string.IsNullOrEmpty(startDateInput))
                        {
                            Console.Write("⚠ La fecha no puede estar vacía ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    else
                        {
                            Console.Write("❌ Formato de fecha inválido. Por favor, use el formato DD/MM/YYYY.");
                            Console.ReadKey();
                            Console.Clear();
                            return;
                        }

                    Console.Write("Digite la fecha de finalización del torneo\n\"(Formato: DD/MM/YYYY)\": ");
                    string? endDateInput = Console.ReadLine();
                    if (DateOnly.TryParse(endDateInput, out DateOnly endDate))
                        {
                            if (endDate <= tournament.StartDate)
                                {
                                    Console.Write("❌ La fecha de finalización no puede ser antes de la fecha de inicio.");
                                    Console.ReadKey();
                                    return;
                                }
                            else
                                {
                                    tournament.EndDate = endDate;
                                    Console.Clear();
                                }
                        }
                    else if (string.IsNullOrEmpty(startDateInput))
                        {
                            Console.Write("⚠ La fecha no puede estar vacía ⚠.");
                            Console.ReadKey();
                            return;
                        }    
                    else
                        {
                            Console.Write("❌ Formato de fecha inválido. Por favor, use el formato DD/MM/YYYY.");
                            Console.ReadKey();
                            Console.Clear();
                            return;
                        }

                    Console.WriteLine($"Se ha creado el torneo: \"{tournament.Name}\" con ID: \"{tournament.Id}\" de tipo: \"{tournament.Type}\"\nEl torneo inicia el: {tournament.StartDate} y finaliza el: {tournament.EndDate}.\nEl torneo se desarrollará en: \"{tournament.Country}\".");
                    Tournament.AddTournament(tournament);
                    Console.ReadKey();
                    Console.Clear();

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("======== Buscar Torneo ========");
                    Console.WriteLine("""
                    ======= Opciones =======
                    1. Buscar torneo por ID
                    2. Ver lista de torneos
                    ========================
                    """);
                    Console.Write("Seleccione una opción: ");
                    string? buscador = Console.ReadLine();
                    if (string.IsNullOrEmpty(buscador))
                        {
                            Console.Write("⚠ El campo no puede estar vacío ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    else if (buscador != "1" && buscador != "2")
                        {
                            Console.Write("❌ Opción inválida. Por favor, elija \"1\" o \"2\".");
                            Console.ReadKey();
                            return;
                        }
                    else
                        {
                            Console.Clear();
                        }

                    switch (buscador)
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Ingrese el ID del torneo a buscar: ");
                            string? searchId = Console.ReadLine();
                            if (!int.TryParse(searchId, out int searchid) || searchid <= 0)
                            {
                                Console.Write("❌ El Id debe ser un número válido.");
                                Console.ReadKey();
                                return;
                            }
                            else
                            {
                                Console.Clear();
                            }
                            Tournament? foundTournament = Tournament.tournaments.FirstOrDefault(t => t.Id == searchid);
                            if (foundTournament != null)
                            {
                                Console.WriteLine($"===== Torneo Encontrado =====\n{foundTournament.ToString()}");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Write("❌ El torneo con ese Id no existe.");
                                Console.ReadKey();
                                return;
                            }
                            break;

                        case "2":
                            Console.Clear();
                            Console.Write("¿Desea ver la lista de torneos? (s/n): ");
                            string? verLista = Console.ReadLine();
                            Console.Clear();
                            if (verLista?.ToLower() == "s")
                            {
                                Console.WriteLine("======== Lista de Torneos =======");
                                foreach (Tournament t in Tournament.tournaments)
                                    {
                                        Console.WriteLine($"{t.ToString()}\n");
                                    }
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                                return;
                            }
                            break;
                    }            
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("======== Eliminar Torneo ========");

                    Console.WriteLine("Estos son los torneos existentes para eliminar: ");
                    if (Tournament.tournaments.Count == 0)
                    {
                        Console.WriteLine("⚠ No hay torneos disponibles para eliminar ⚠.");
                        Console.ReadKey();
                        return;
                    }
                    foreach (Tournament t in Tournament.tournaments)
                    {
                        Console.WriteLine($"{t.ToString()}\n");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    
                    Console.WriteLine("Ingrese el Id del torneo a eliminar: ");
                    int eliminarId = int.Parse(Console.ReadLine() ?? "0");
                    Tournament? idEncontrado = Tournament.tournaments.Find(t => t.Id == eliminarId);
                    if (idEncontrado != null)
                        {
                            while (true)
                                {        
                                    Console.WriteLine("¿Está seguro de eliminarlo? (s/n): ");
                                    string? eliminar = Console.ReadLine();
                                    if (eliminar?.ToLower() != "s")
                                        {
                                            Console.Clear();
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
                            Console.WriteLine("❌ El torneo con ese Id no existe.");
                            Console.ReadKey();
                            return;
                        }
                    break;
                    
                case "4":
                    Console.Clear();
                    Console.WriteLine("======== Editar Torneo ========");

                    Console.WriteLine("Estos son los torneos existentes para editar: ");
                    if (Tournament.tournaments.Count == 0)
                    {
                        Console.WriteLine("⚠ No hay torneos disponibles para editar ⚠.");
                        Console.ReadKey();
                        return;
                    }
                    foreach (Tournament t in Tournament.tournaments)
                    {
                        Console.WriteLine($"{t.ToString()}\n");
                    }
                    Console.ReadKey();
                    Console.Clear();

                    while (true)
                        {
                            Console.Clear();
                            Console.Write("""
                            =========== Opciones de Edición ===========
                            1. Editar nombre del torneo
                            2. Editar país del torneo
                            3. Editar tipo de torneo
                            4. Editar fecha de inicio del torneo
                            5. Editar fecha de finalización del torneo
                            6. Regresar al menú de torneos
                            ===========================================

                            Seleccione la opción que desea editar: 
                            """);
                            string? selectedOption = Console.ReadLine();
                            
                            switch (selectedOption)
                            {
                                case "1":
                                    Console.Clear();
                                    foreach (Tournament t in Tournament.tournaments)
                                    {
                                        Console.WriteLine($"Torneos disponibles:\nId: {t.Id}\nNombre: \"{t.Name}\".");
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int actualizar = int.Parse(Console.ReadLine() ?? "0");

                                    Tournament? foundedTournamentName = Tournament.tournaments.Find(t => t.Id == actualizar);
                                    if (foundedTournamentName != null)
                                        {
                                            Console.WriteLine($"Torneo: {foundedTournamentName.Name}");
                                            Console.Write("Ingrese el nuevo nombre del torneo: ");
                                            string? newName = Console.ReadLine();
                                            if (Tournament.tournaments.Any(t => t.Name == newName))
                                                {
                                                    Console.WriteLine($"⚠ Ese nombre ya está en uso ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }
                                            else if (string.IsNullOrEmpty(newName))
                                                {
                                                    Console.WriteLine("⚠ El campo no puede estar vacío ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }    
                                            else
                                                {
                                                    foundedTournamentName.Name = newName;
                                                    Console.WriteLine("Nombre actualizado con éxito.");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                        }
                                    else
                                        {
                                            Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    break;

                                case "2":
                                    Console.Clear();
                                    foreach (Tournament t in Tournament.tournaments)
                                {
                                    Console.WriteLine($"Torneos disponibles:\nId: {t.Id}\nNombre: {t.Name}\nPaís: \"{t.Country}\".");
                                }
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int buscarIdC = int.Parse(Console.ReadLine() ?? "0");

                                    Tournament? foundTournamentCountry = Tournament.tournaments.Find(t => t.Id == buscarIdC);
                                    if (foundTournamentCountry != null)
                                        {
                                            Console.WriteLine($"Torneo: {foundTournamentCountry.Country}");
                                            Console.Write("Ingrese el nuevo país del torneo: ");
                                            string? newCountry = Console.ReadLine();
                                            if (string.IsNullOrEmpty(newCountry))
                                                {
                                                    Console.WriteLine("⚠ El campo no puede estar vacío ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }
                                            else if (newCountry.Length < 3)
                                                {
                                                    Console.WriteLine("⚠ El país debe contener al menos 3 caracteres ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }    
                                            else
                                                {
                                                    foundTournamentCountry.Country = newCountry;
                                                    Console.WriteLine("País actualizado con éxito.");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                        }
                                    else
                                        {
                                            Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    break;
                                    
                                case "3":
                                    foreach (Tournament t in Tournament.tournaments)
                                        {
                                            Console.WriteLine($"Torneos disponibles:\nId: {t.Id}\nNombre: {t.Name}\nTipo de torneo: \"{t.Type}\".");
                                        }
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int buscarIdT = int.Parse(Console.ReadLine() ?? "0");

                                    Tournament? foundedTournamentType = Tournament.tournaments.Find(t => t.Id == buscarIdT);
                                    if (foundedTournamentType != null)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Tipo de torneo actual: {foundedTournamentType.Type}");
                                            Console.Write("""
                                            ======= Tipo de torneo =======
                                            1 ---> Torneo local
                                            2 ---> Torneo internacional
                                            ==============================

                                            Seleccione el tipo de torneo (1 ó 2): 
                                            """);
                                            string? newType = Console.ReadLine();
                                            if (string.IsNullOrEmpty(newType))
                                                {
                                                    Console.Write("⚠ No se puede dejar el campo vacío ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }
                                            else
                                                {
                                                    if (newType == "1")
                                                        {
                                                            foundedTournamentType.Type = "Local";
                                                            Console.Clear();
                                                        }
                                                    else if (newType == "2")
                                                        {
                                                            foundedTournamentType.Type = "Internacional";
                                                            Console.Clear();
                                                        }
                                                    else
                                                        {
                                                            Console.Write("❌ Opción inválida. Digite una opción entre \"1\" y \"2\".");
                                                            Console.ReadKey();
                                                            return;
                                                        }
                                                }
                                            }
                                    else
                                        {
                                            Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    break;

                                case "4":
                                    foreach (Tournament t in Tournament.tournaments)
                                        {
                                            Console.WriteLine($"Torneos disponibles:\nId: {t.Id}\nNombre: {t.Name}\nFecha de inicio: \"{t.StartDate}\".");
                                        }
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int buscarIdF = int.Parse(Console.ReadLine() ?? "0");
                                    Tournament? foundedTournamentStartD = Tournament.tournaments.Find(t => t.Id == buscarIdF);
                                    if (foundedTournamentStartD != null)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Torneo: {foundedTournamentStartD.Type}");
                                            string? newStartD = Console.ReadLine();
                                            if (DateOnly.TryParse(newStartD, out DateOnly startdate))
                                                {
                                                    foundedTournamentStartD.StartDate = startdate;
                                                    Console.Clear();
                                                }
                                            else if (string.IsNullOrEmpty(newStartD))
                                                {
                                                    Console.Write("⚠ La fecha no puede estar vacía ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }
                                            else
                                                {
                                                    Console.Write("❌ Formato de fecha inválido. Por favor, use el formato DD/MM/YYYY.");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    return;
                                                }
                                        }
                                    else
                                        {
                                            Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    break;

                                case "5":
                                    foreach (Tournament t in Tournament.tournaments)
                                        {
                                            Console.WriteLine($"Torneos disponibles:\nId {t.Id}\nNombre: {t.Name}\nFecha de finalización: \"{t.EndDate}\".");
                                        }
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int buscarIdFn = int.Parse(Console.ReadLine() ?? "0");
                                    Tournament? foundedTournamentFn = Tournament.tournaments.Find(t => t.Id == buscarIdFn);
                                    if (foundedTournamentFn != null)
                                    {
                                        string? newEndD = Console.ReadLine();
                                        if (DateOnly.TryParse(newEndD, out DateOnly newEndDate))
                                            {
                                                if (newEndDate <= foundedTournamentFn.StartDate)
                                                    {
                                                        Console.Write("❌ La fecha de finalización no puede ser antes de la fecha de inicio.");
                                                        Console.ReadKey();
                                                        return;
                                                    }
                                                else
                                                    {
                                                        foundedTournamentFn.EndDate = newEndDate;
                                                        Console.Clear();
                                                    }
                                            }
                                        else if (string.IsNullOrEmpty(newEndD))
                                            {
                                                Console.Write("⚠ La fecha no puede estar vacía ⚠.");
                                                Console.ReadKey();
                                                return;
                                            }    
                                        else
                                            {
                                                Console.Write("❌ Formato de fecha inválido. Por favor, use el formato DD/MM/YYYY.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                return;
                                            }
                                    }
                                    else
                                    {
                                        Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                    break;
                                case "6":
                                    Console.Clear();
                                    Console.WriteLine("Saliendo al menú principal... ");
                                    Console.ReadKey();
                                    return;
                                default:
                                    Console.WriteLine("❌ Opción inválida. Por favor, elija una opción válida.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } 

                case "5":
                    Console.Clear();
                    Console.WriteLine("Saliendo al menú principal... ");
                    Console.ReadKey();
                    return;

                default:
                    Console.WriteLine("Opción inválida, vuelva a intentar con una opción disponible.");
                    break;
            }           
        }
    }
}
