using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torneoFutbol
{
    public class uiModels
    {
        public static void mainMenu()
        {
        
        const string mainMenu = """
        +-------------------------------------+
        |         ⚽ Menú Principal           |
        +-------------------------------------+
        | 1. Administrar Torneo               |
        | 2. Registrar Equipo                 |
        | 3. Registrar Jugador                |
        | 4. Transferencias                   |
        | 5. Estadísticas                     |
        | 6. Salir                            |
        +-------------------------------------+

        Por favor, elige una opción del menú principal: 
        """;
            Console.Write(mainMenu);
        }

        public static void tournamentMenu()
        {
            const string tournamentMenu = """
        +-------------------------------------+
        |   🏆 Administrador de Torneos       |
        |-------------------------------------|
        | 1. Añadir Torneo                    |
        | 2. Buscar Torneo                    |
        | 3. Eliminar Torneo                  |
        | 4. Actualizar Torneo (Editar)       |
        | 5. Regresar a Menú Principal        |
        +-------------------------------------+

        Por favor, elige una opción: 
        """;

        Console.Write(tournamentMenu);
        }


        public static void teamsMenu()
        {
            const string teamsMenu = """
        +-------------------------------------+
        |   👥 Administrador de Equipos       |
        |-------------------------------------|
        | 1. Registrar equipo                 |
        | 2. Registrar Cuerpo Técnico         |
        | 3. Registrar Cuerpo Médico          |
        | 4. Inscripción a Torneo             |
        | 5. Notificación de Transferencia    |
        | 6. Salir de Torneo                  |    
        | 7. Regresar a Menú Principal        |    
        +-------------------------------------+

        Por favor, elige una opción: 
        """;
        
        Console.Write(teamsMenu);
        }

        public static void playersMenu()
        {
            const string playersMenu = """
        +-------------------------------------+
        |   🏃 Administrador de Jugadores     |
        +-------------------------------------+
        | 1. Registrar Jugador                |
        | 2. Buscar Jugador                   |
        | 3. Editar Jugador                   |
        | 4. Eliminar Jugador                 |
        | 5. Regresar a Menú Principal        |
        +-------------------------------------+

        Por favor, elige una opción: 
        """;
            Console.Write(playersMenu);
        }

        public static void transferMenu()
        {
            const string transferMenu = """
        +-------------------------------------------------+
        |   💰 Menú de Transferencias (Compra/Préstamo)   |
        +-------------------------------------------------+
        | 1. Comprar Jugador                              |
        | 2. Prestar Jugador                              |
        | 3. Regresar a Menú Principal                    |
        +-------------------------------------------------+

        Por favor, elige una opción: 
        """;
            Console.Write(transferMenu);
        }

        public static void statsMenu()
        {
            const string statsMenu = """
        +-------------------------------------------------+
        |           📊 Menú de Estadísticas               |
        |-------------------------------------------------|
        | 1. Jugadores con más asistencias del torneo     |
        | 2. Equipos con más goles en contra del torneo   |
        | 3. Jugadores más caros por equipo               |
        | 4. Jugadores menores al promedio de edad        |
        | 5. Regresar a Menú Principal                    |
        +-------------------------------------------------+

        Por favor, elige una opción: 
        """;
            Console.Write(statsMenu);
        }
    }
}
