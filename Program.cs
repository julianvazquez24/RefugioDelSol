using RefugioDelSol;
using System.ComponentModel.Design;



Huesped.Huespedes.Add(
    new Huesped("Juan", "Alvez", 98321456));
Huesped.Huespedes.Add(
    new Huesped("Pedro", "Perez", 94444444));
Huesped.Huespedes.Add(
    new Huesped("Ana", "Martinez", 98218238));



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
                Apartamento.EliminarApartamento();
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
        Console.WriteLine("(2) Cancelar Reserva");
        Console.WriteLine("(3) Modificar Reserva");
        Console.WriteLine("(4) Listar Reservas");

        int opcionReserva = int.Parse(Console.ReadLine() ?? string.Empty);

        switch (opcionReserva)
        {
            case 1:
                Reserva.AgregarReserva();
                break;

            case 2:
                Console.WriteLine("Cancelar reserva");
                Reserva.CancelarReserva();
                break;

            case 3:
                Reserva.ModificarReserva();
                break;

            case 4:
                Reserva.ListarReservas();
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
        Console.WriteLine("(2) Apartamentos con mas reservas");
        Console.WriteLine("(3) Lista reservas por fecha");
        Console.WriteLine("(4) Reservas del huesped");
        Console.WriteLine("(5) Reservas del día");
        Console.WriteLine("(6) Lista de huespedes ordenada alfabeticamente");
        Console.WriteLine("(7) Informacion sobre el centro de convenciones");
        Console.WriteLine("(8) Informacion del parque");

        int opcionEstadistica = int.Parse(Console.ReadLine() ?? string.Empty);

        switch (opcionEstadistica)
        {
            case 1:

                Console.WriteLine("Ingrese la fecha de inicio en la cual quiere ver los apartamentos disponibles (yyyy-MM-dd):");
                DateOnly fechaInicioReserva = DateOnly.Parse(Console.ReadLine() ?? string.Empty);

                Console.WriteLine("Ingrese la fecha de fin en la cual quiere ver los apartamentos disponibles (yyyy-MM-dd):");
                DateOnly fechaFinReserva = DateOnly.Parse(Console.ReadLine() ?? string.Empty);

                Reserva.ListarApartamentosDisponibles(fechaFinReserva, fechaInicioReserva);

                // hay que hacer una funcion en la clase reserva que se llame listarApartamentosDisponibles(), esta tiene que crear una lista con todos los apartamentos que hay, fijarse si en las reservas hay fechas que coinciden, quitarlos de esa lista, y luego listar cada uno de los que quedo

                break;

            case 2:
                Console.WriteLine("Apartamentos con mas reservas");
                Reserva.ListarApartamentosConMasReservas();
                // tendriamos que hacer una propiedad de el apartamento o de la reserva que se llame vecesReservado, y que cuando se agrega una reserva se le haga +1 a esa propiedad, luego usar el listar todos los apartamentos y solo mostrar el id y las veces de reserva en vez de todo
                break;

            case 3:
                Console.WriteLine("Lista reservas por Fecha");
                Console.WriteLine("Ingresar fecha (yyyy-MM-dd):");

                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly fechaIngresada))
                {
                    Controladora.MostrarReservasPorFecha(fechaIngresada);
                }
                else
                {
                    Console.WriteLine("Fecha inválida. Por favor ingrese la fecha en el formato yyyy-MM-dd.");
                }

                // va a tener que buscar en las reservas las que tengan como fecha de inicio a ingresada aca, y mostrar cada una de las reservas incluyendo id, fechainicio y fecha fin, o directamente toda la informacion
                break;

            case 4:
                Console.WriteLine("Reservas del huésped");
                Console.WriteLine("Ingresar ID del huésped:");
                int idHuesped = int.Parse(Console.ReadLine() ?? string.Empty);
                Reserva.MostrarReservasPorHuesped(idHuesped);
                break;
            
            case 5:
                Console.WriteLine("Reservas del Día");
                DateOnly fechaHoy = DateOnly.FromDateTime(DateTime.Now);
                Controladora.MostrarReservasPorFecha(fechaHoy);

                break;

            case 6:

                Console.WriteLine("Lista de huespedes ordenada alfabeticamente");
                Controladora.ListarHuespedesOrdenadosAlfabeticamente(Huesped.Huespedes);
                break;

            case 7:
                Console.WriteLine("Informacion del Centro de Convenciones");
                Huesped.MostrarInformacionConvencionesYEsparcimiento();
                break;
            
            case 8:
                Console.WriteLine();
                Console.WriteLine("Informacion del parque:");
                Huesped.MostrarInformacionParque();
                break;

            default:
                Console.WriteLine("Opcion no valida");
                break;
        }
    }
}


