using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace torneoFutbol.Models
{
    public class ManageTeam
    {
        public static void ManageTeams()
        {
            Console.Clear();
            uiModels.teamsMenu();

            string? teamOption = Console.ReadLine();

            switch (teamOption)
            {
                case "1":
                    Console.Clear();
                    Team team = new Team();
                    Console.WriteLine("======= Registrar Equipo =======");

                    Console.Write($"Id del equipo: ");
                    string? idInput = Console.ReadLine();
                    if (!int.TryParse(idInput, out int id) || id <= 0)
                        {
                            Console.Write("❌ El Id debe ser un número válido mayor a cero.");
                            Console.ReadKey();
                            return;
                        }
                    else
                        {
                            team.Id = id;
                            Console.Clear();
                        }  
                    foreach (Team t in Team.teams)
                    {
                        if (t.Id == team.Id)
                        {
                            Console.Write("⚠ Ese Id ya está relacionado a otro equipo ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    }

                    Console.Write("Registre el nombre del equipo: ");
                    team.Name = Console.ReadLine();
                    if (string.IsNullOrEmpty(team.Name))
                        {
                            Console.Write("⚠ El nombre del equipo no puede estar vacío ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    else
                        {
                            Console.Clear();
                        }
                    
                    foreach (Team t in Team.teams)
                        {
                            if (t.Name == team.Name)
                                {
                                    Console.Write("⚠ Ese nombre ya está registrado ⚠.");
                                    Console.ReadKey();
                                    return;
                                }
                            else
                            {
                                Console.Clear();
                            }    
                        }

                    Console.Write("Registre el país del equipo: ");
                    team.Country = Console.ReadLine();
                    if (string.IsNullOrEmpty(team.Country))
                        {
                            Console.Write("⚠ El campo no puede estar vacío ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    else if (team.Country.Length < 3)
                        {
                            Console.Write("⚠ El país debe contener al menos 3 caracteres ⚠.");
                            Console.ReadKey();
                            return;
                        }
                    else
                        {
                            Console.Clear();
                        }

                    Console.Write("""
                    ========== Tipo de equipo ==========
                    1 ---> Selección nacional
                    2 ---> Club (Amateur o Profesional)
                    ====================================

                    Seleccione el tipo de equipo (1 ó 2): 
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
                                    team.Type = "Selección nacional";
                                    Console.Clear();
                                }
                            else if (optionType == "2")
                                {
                                    team.Type = "Club";
                                    Console.Clear();
                                }
                            else
                                {
                                    Console.Write("❌ Opción inválida. Digite una opción entre \"1\" y \"2\".");
                                    Console.ReadKey();
                                    return;
                                }
                        }

                    Console.WriteLine($"Se ha registrado el equipo: \"{team.Name}\" con ID: {team.Id} de tipo: \"{team.Type}\", ubicado en el país: \"{team.Country}\".");
                    Team.AddTeam(team);
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine("¿Desea ver la lista de equipos? (s/n): ");
                    string? verLista = Console.ReadLine();
                    if (verLista?.ToLower() == "s")
                        {
                            Console.Clear();
                            Console.WriteLine("======== Lista de Equipos =======");
                            foreach (Team t in Team.teams)
                                {
                                    Console.WriteLine($"{t.ToString()}\n");
                                }
                            Console.ReadKey();
                            Console.Clear();
                            }
                    else
                        {
                            Console.ReadKey();
                            Console.Clear();
                            return;
                        }
                    break;

                case "2":
                    Console.Clear();
                    while (true)
                        {
                            Console.WriteLine("Desea registrar un miembro de cuerpo técnico? (s/n): ");
                            string? respuesta = Console.ReadLine();
                            if (respuesta?.ToLower() == "s")
                            {
                                Console.Clear();
                                TechnicalStaff technicalStaff = new TechnicalStaff();

                                Console.WriteLine("======== Registrar Cuerpo Técnico =======");
                                Console.Write($"""
                                ========== Documento Identificador ==========
                                1 ---> C.C
                                2 ---> C.E (Cédula de Extranjería)
                                3 ---> Pasaporte
                                =============================================

                                Seleccione el tipo de documento (1, 2 ó 3): 
                                """);
                                string? idType = Console.ReadLine();
                                if (string.IsNullOrEmpty(idType))
                                    {
                                        Console.Write("⚠ No se puede dejar el campo vacío ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else
                                    {
                                        if (idType == "1")
                                            {
                                                technicalStaff.IdType = "La Cédula de Ciudadanía";
                                                Console.Clear();
                                            }
                                        else if (idType == "2")
                                            {
                                                technicalStaff.IdType = "La Cédula de Extranjería";
                                                Console.Clear();
                                            }
                                        else if (idType == "3")
                                            {
                                                technicalStaff.IdType = "El Pasaporte";
                                                Console.Clear();
                                            }
                                        else
                                            {
                                                Console.Write("❌ Opción inválida. Digite una opción entre \"1\", \"2\" ó \"3\".");
                                                Console.ReadKey();
                                                return;
                                            }
                                    }

                                Console.Write($"Digite el Id del miembro a registrar: ");
                                technicalStaff.Id = Console.ReadLine();
                                if (string.IsNullOrEmpty(technicalStaff.Id))
                                    {
                                        Console.Write($"❌ {technicalStaff.IdType} debe tener un número válido.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else if (idType == "1" && technicalStaff.Id.Length < 10)
                                    {
                                        Console.Write("⚠ La cédula de ciudadanía debe contener 10 dígitos ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else if (idType == "2" && technicalStaff.Id.Length < 11)
                                    {
                                        Console.Write("⚠ La cédula de extranjería debe contener 11 dígitos ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else if (idType == "3" && technicalStaff.Id.Length < 8)
                                    {
                                        Console.Write("⚠ El pasaporte debe contener al menos 8 caracteres ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else
                                {
                                Console.Write($"{technicalStaff.IdType} de {technicalStaff.FullName} se registró como: {technicalStaff.Id}");
                                    Console.ReadKey();
                                    Console.Clear();
                                }  
                                foreach (TechnicalStaff t in TechnicalStaff.teams)
                                {
                                    if (t.Id == technicalStaff.Id)
                                    {
                                        Console.Write("⚠ Ese Id ya identifica a otro miembro ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }
                                }

                                Console.Write("Registre el nombre completo del miembro: ");
                                technicalStaff.FullName = Console.ReadLine();
                                if (string.IsNullOrEmpty(technicalStaff.FullName))
                                    {
                                        Console.Write("⚠ No se puede dejar el campo vacío ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else
                                    {
                                        Console.Clear();
                                    }
                                
                                Console.Write($"Registre el país de origen de {technicalStaff.FullName}: ");
                                technicalStaff.Origin = Console.ReadLine();
                                if (string.IsNullOrEmpty(technicalStaff.Origin))
                                    {
                                        Console.Write("⚠ El campo no puede estar vacío ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else if (technicalStaff.Origin.Length < 3)
                                    {
                                        Console.Write("⚠ El país debe contener al menos 3 caracteres ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else
                                    {
                                        Console.Clear();
                                    }

                                Console.Write("Registre el email completo del miembro: ");
                                technicalStaff.Email = Console.ReadLine();
                                if (string.IsNullOrEmpty(technicalStaff.Email))
                                    {
                                        Console.Write("⚠ No se puede dejar el campo vacío ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else if (!technicalStaff.Email.Contains("@") || !technicalStaff.Email.Contains(".com"))
                                    {
                                        Console.Write("⚠ El email debe contener un \"@\" y un \".com\" ⚠.");
                                        Console.ReadKey();
                                        return;
                                    }    
                                else
                                    {
                                        Console.Clear();
                                    }
                                
                                Console.Write("""
                                ========= Cargo/Puesto =========
                                1 ---> Director Técnico
                                2 ---> Asistente Técnico
                                3 ---> Preparador Físico
                                4 ---> Entrenador de Porteros
                                5 ---> Analista Táctico
                                ================================

                                Seleccione el cargo del miembro: 
                                """);
                                technicalStaff.Job = Console.ReadLine();
                                if (string.IsNullOrEmpty(technicalStaff.Job))
                                    {
                                        Console.Write("⚠ No se puede dejar el campo vacío ⚠.");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                else if(technicalStaff.Job == "1")
                                    {
                                        technicalStaff.Job = "Director Técnico";
                                        Console.WriteLine($"{technicalStaff.FullName} ha sido registrado como {technicalStaff.Job}.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Clear();
                                    }
                                else if(technicalStaff.Job == "2")
                                    {
                                        technicalStaff.Job = "Asistente Técnico";
                                        Console.WriteLine($"{technicalStaff.FullName} ha sido registrado como {technicalStaff.Job}.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Clear();
                                    }
                                else if(technicalStaff.Job == "3")
                                    {
                                        technicalStaff.Job = "Preparador Físico";
                                        Console.WriteLine($"{technicalStaff.FullName} ha sido registrado como {technicalStaff.Job}.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Clear();
                                    }
                                else if(technicalStaff.Job == "4")
                                    {
                                        technicalStaff.Job = "Entrenador de Porteros";
                                        Console.WriteLine($"{technicalStaff.FullName} ha sido registrado como {technicalStaff.Job}.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Clear();
                                    }
                                else if(technicalStaff.Job == "5")
                                    {
                                        technicalStaff.Job = "Analista Táctico";
                                        Console.WriteLine($"{technicalStaff.FullName} ha sido registrado como {technicalStaff.Job}.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.Clear();
                                    }
                                else
                                    {
                                        Console.Write("❌ Opción inválida. Digite una opción entre \"1\", \"2\", \"3\", \"4\" ó \"5\".");
                                        Console.ReadKey();
                                        return;
                                    }      
                                
                                Console.Write($"Digite el tiempo de experiencia laboral de {technicalStaff.FullName} en meses: ");
                                string? expInput = Console.ReadLine();
                                if (string.IsNullOrEmpty(expInput) || !int.TryParse(expInput, out int expI))
                                    {
                                        Console.Write($"❌ La experiencia laboral debe ser un número válido.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else if (expI <= 0)
                                    {
                                        Console.Write("❌ Tiempo de experiencia laboral no válido.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else
                                    {
                                        technicalStaff.Exp = expI;
                                        Console.Clear();
                                    }  

                                Console.Write($"Digite la edad de {technicalStaff.FullName} en años: ");
                                string? ageInput = Console.ReadLine();
                                if (string.IsNullOrEmpty(ageInput) || !int.TryParse(ageInput, out int ageI))
                                    {
                                        Console.Write($"❌ La edad debe ser un número válido.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else if (ageI < 18)
                                    {
                                        Console.Write("❌ No cumple con la edad mínima requerida.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else if (ageI > 60)
                                    {
                                        Console.Write("❌ Supera la edad límite para seguir trabajando.");
                                        Console.ReadKey();
                                        return;
                                    }
                                else
                                    {
                                        technicalStaff.Age = ageI;
                                        Console.Clear();
                                    }  
                            }
                            else if (respuesta?.ToLower() == "n")
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Write("❌ Opción inválida. Por favor, ingrese \"s\" o \"n\".");
                                Console.ReadKey();
                                continue;
                            }
                        }

                    break;
                case "3":
                    
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}