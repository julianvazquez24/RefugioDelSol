using RefugioDelSol;
using System.ComponentModel.Design;

List<Huesped> huespedes = new List<Huesped>
        {

            new Huesped("Juan", "Alvez", 98321456, false),
            new Huesped("Pedro", "Perez", 94444444, true),
            new Huesped("Ana", "Martinez", 98218238, false)
            
        };

List<Apartamento> apartamentos = new List<Apartamento>
{
    new Apartamento(1, 250, "Sur", "Este",4, 240, true, false),
    new Apartamento(2, 250, "Norte", "Oeste",  3, 180, false, true),
    new Apartamento(3, 250, "Sur", "Oeste", 4,240, true, true),
    new Apartamento(4, 250, "Norte", "Este",  3, 180, true, false),
    new Apartamento(5, 250, "Sur", "Oeste", 4, 240, false, true)
};

Controladora controladora = new Controladora();
Apartamento.LosApartamentos();

string input = "";

while (input != "fin")
{
    Console.WriteLine("Menu Refugio Del Sol");
    Console.WriteLine("1. Gestion de Huespedes");
    Console.WriteLine("2. Gestion de Apartamentos");
    Console.WriteLine("3. Gestion de Reservas");
    Console.WriteLine("4. Ver Estadisticas");
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
        Console.WriteLine("(4) Lista de los Apartamentos ");

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
                Apartamento.ModificarApartamento();
                break;

            case 4:
                Apartamento.ListarApartamentos();
                Console.WriteLine();
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
<<<<<<< HEAD
        Console.WriteLine("(1) Lista apartamentos disponibles");
        Console.WriteLine("(2) Lista reservas por fecha");
        Console.WriteLine("(3) Reservas del huesped");
        Console.WriteLine("(4) Apartamentos con mas reservas");
        Console.WriteLine("(5) Lista de huespedes ordenada alfabeticamente");
    
        int opcionEstadistica = int.Parse(Console.ReadLine() ?? string.Empty);

        Controladora controladora = new Controladora();
    
        switch (opcionEstadistica)
        {
            case 1:
                Console.WriteLine("Lista de los apartamentos disponibles");
                List<Apartamento> apartamentosDisponibles = Reserva.ListaApartamentosDisponibles;
                Console.WriteLine($"Lista de los apartamentos disponibles: {apartamentosDisponibles.Count}");
=======
        Console.WriteLine("(1) Lista de huespedes ordenada alfabeticamente");
        Console.WriteLine("(2) Lista apartamentos disponibles");
        //Console.WriteLine("(3) Reservas del día");
        //Console.WriteLine("(4) Reservas del huésped: ");
        //Console.WriteLine("(5) Lista reservas por fecha");
        Console.WriteLine("(6) Informacion sobre el centro de convenciones");
        Console.WriteLine("(7) Informacion del parque");
        
        int opcionEstadistica = int.Parse(Console.ReadLine() ?? string.Empty);
        
        switch (opcionEstadistica)
        {
            case 1:
                Controladora.ListarHuespedesOrdenadosAlfabeticamente(huespedes);
>>>>>>> 0bab59d17042ffcbc86e5213d5efd2d0e5526171
                break;
            
            case 2:
<<<<<<< HEAD
            Console.WriteLine("Ingrese la fecha (yyyy-MM-dd)):");
            DateOnly fecha = DateOnly.Parse(Console.ReadLine());
            List<Reserva> reservasPorFecha = controladora.ListaReservaFecha(fecha);
            Console.WriteLine($"Lista de las reservas por fecha: {reservasPorFecha.Count}");
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

        case 5:
            Console.WriteLine("Lista de huespedes ordenada alfabeticamente:");
            controladora.ListaAlfabeticamenteHuespedes(controladora.Huespedes);
            break;
        
        default:
            Console.WriteLine("Opcion no valida");
            break;
=======
                Controladora.MostrarApartamentosDisponibles(apartamentos);
                break;

            //case 3:
            //    Console.WriteLine("Reservas del huesped");
                

               
            //    break;

            //case 4:
            //    Console.WriteLine("Apartamentos con mas reservas");


            //    break;

            //case 5:
            //    Console.WriteLine("Lista de los apartamentos disponibles");
                
            //    break;

            case 6:
                Console.WriteLine("Informacion del centro de convenciones:");
                Huesped.MostrarInformacionConvencionesYEsparcimiento();
                break;

            case 7:
                Console.WriteLine();
                Console.WriteLine("Informacion del parque:");
                Huesped.MostrarInformacionParque();
                break;
            
            default:
                Console.WriteLine("Opcion no valida");
                break;
>>>>>>> 0bab59d17042ffcbc86e5213d5efd2d0e5526171
        }
    }
}

