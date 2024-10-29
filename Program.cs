using RefugioDelSol;
using System.ComponentModel.Design;


string input = "";

Apartamento apartamento1 = new Apartamento(
    200,"Sur","Este",1,200
    );
Apartamento apartamento2 = new Apartamento(
    250, "Sur", "OEste", 4, 300
    );
Apartamento apartamento3 = new Apartamento(
    300, "Norte", "Este", 3, 150
    );
Apartamento apartamento4 = new Apartamento(
    350, "Norte", "OEste", 2, 100
    );

while (input != "fin")
{
    Console.WriteLine("Menu Refugio Del Sol");
    Console.WriteLine("1. Gestion de Huespedes");
    Console.WriteLine("2. Gestion de Apartamentos");
    Console.WriteLine("3. Gestion de Reservas");
    Console.WriteLine("4. Estadisticas");
    Console.WriteLine("Escribe fin para salir");
    Console.WriteLine("Seleccione una opcion: ");

    input = Console.ReadLine() ?? string.Empty;

    if (input == "1")
    {
        
        Console.WriteLine("Por favor selecciona una opcion");
        Console.WriteLine("(1) Agregar Huesped");
        Console.WriteLine("(2) Eliminar Huesped");
        Console.WriteLine("(3) Modificar Huesped");
        Console.WriteLine("(4) Listar Huespedes"); 

        int opcionHuesped = int.Parse(Console.ReadLine() ?? string.Empty);
        switch (opcionHuesped)
        {
            case 1:
                Huesped.AgregarHuesped();
                break;

            case 2:
                Huesped.EliminarHuesped();
                break;

            case 3:
                Huesped.ModificarHuesped();
                break;

            case 4:
                Huesped.ListarHuespedes();
                break;

            default:
                Console.WriteLine("Opcion no valida.");
                break;
        }
    }

    else if (input == "2")
    {
        
        Console.WriteLine("Por favor selecciona una opcion");
        Console.WriteLine("(1) Agregar Apartamento");
        Console.WriteLine("(2) Eliminar Apartamento");
        Console.WriteLine("(3) Modificar Apartamento");
        Console.WriteLine("(4) Listar Apartamentos ");

        int opcionApartamento = int.Parse(Console.ReadLine() ?? string.Empty);

        switch (opcionApartamento)
        {
            case 1:
                Apartamento.AgregarApartamento();
                break;
                
            case 2:
                
                Console.WriteLine("Eliminar Apartamento:");
                Console.Write("Ingrese el ID del apartamento que desea eliminar: ");
                int idEliminar = int.Parse(Console.ReadLine() ?? string.Empty); 
                break;

            case 3:
                Console.WriteLine("Modificar apartamento");
                break;

            case 4:
                Console.WriteLine("Lista de apartamentos:");
                Apartamento.ListarApartamentos();
                break;

            default:
                Console.WriteLine("Opcion no valida.");
                break;
        }
    }

    else if (input == "3")
    {
        
        Console.WriteLine("Por favor selecciona una opcion");
        Console.WriteLine("(1) Agregar Reserva");
        Console.WriteLine("(2) Eliminar Reserva");
        Console.WriteLine("(3) Modificar Reserva");
        Console.WriteLine("(4) Listar Reservas");

        int opcionReserva = int.Parse(Console.ReadLine() ?? string.Empty);

        switch (opcionReserva)
        {
            case 1:
                Console.WriteLine("Agregar reserva");
                Reserva.AgregarReserva();
                break;

            case 2:
                Console.WriteLine("Eliminar reserva");
                break;

            case 3:
                Console.WriteLine("Modificar reserva");
                break;

            case 4:
                Console.WriteLine("Lista de las reservas");
                break;

            default:
                Console.WriteLine("Opcion no valida");
                break;
        }
    }

    else if (input == "4")
    {
        
        Console.WriteLine("Por favor selecciona una opcion de estadistica");
        Console.WriteLine("(1) Lista apartamentos disponibles");
        Console.WriteLine("(2) Lista reservas por fecha");
        Console.WriteLine("(3) Reservas del huesped");
        Console.WriteLine("(4) Apartamentos con mas reservas");
        

        int opcionEstadistica = int.Parse(Console.ReadLine() ?? string.Empty);

        Controladora controladora = new Controladora();
        
        switch (opcionEstadistica)
        {
            case 1:
                Console.WriteLine("Lista de los apartamentos disponibles");

                List<Apartamento> apartamentosDisponibles = Reserva.ListaApartamentosDisponibles;
                Console.WriteLine($"Lista de los apartamentos disponibles: {apartamentosDisponibles.Count}");
                break;

            case 2:
                Console.WriteLine("Lista reservas por fecha");
                
                
                break;

            case 3:
                Console.WriteLine("Reservas del huesped");

                string NombreHuesped;
                string ApellidoHuesped;
                int TelefonoHuesped;
                Huesped huesped = new Huesped (NombreHuesped = "Juan", ApellidoHuesped = "Perez", TelefonoHuesped = 09333333);
                List<Reserva> reservaPorHuesped = controladora.ListarReservasPorHuesped(huesped);
                Console.WriteLine($"Numero de reservas para el huesped {huesped.NombreHuesped}: {reservaPorHuesped.Count}");
                break;

            case 4:
                Console.WriteLine("Apartamentos con mas reservas");

                List<Apartamento> apartamentosMasReservados = controladora.ListaApartamentosMasReservados();
                Console.WriteLine($"Numero de apartamentos con mas reservas {apartamentosMasReservados.Count}");
                break;

            default:
                Console.WriteLine("Opcion no valida");
                break;
        }
    }
}

