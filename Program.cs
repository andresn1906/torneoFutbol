using System;
using torneoFutbol;
internal class Program
{
    private static void Main(string[] args)
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al sistema de gestión de torneos de fútbol.");
            uiModels.mainMenu();

            string? options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    ManageTournament.ManageTournaments();
                    break;
                case "2":
                    uiModels.teamsMenu();
                    break;
                case "3":
                    uiModels.playersMenu();
                    break;
                case "4":
                    uiModels.transferMenu();
                    break;
                case "5":
                    uiModels.statsMenu();
                    break;
                case "6":
                    Console.WriteLine("Saliendo del programa... ");
                    return;
                default:
                    Console.WriteLine("Opción inválida, por favor intenta de nuevo.");
                    break;
            }
        }
    }
}