using RefugioDelSol;

class Program
{
    static void Main(string[] args)
    {
        Controladora controladora = new Controladora();

        while (true)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Agregar reserva");
            Console.WriteLine("2. Cancelar reserva");
            Console.WriteLine("3. Listar reservas por huésped");
            Console.WriteLine("4. Listar apartamentos más reservados");
            Console.WriteLine("5. Salir");

            int opcion = int.Parse(Console.ReadLine() ?? "0");

            switch (opcion)
            {
                case 1:
                    AgregarReserva(controladora);
                    break;
                case 2:
                    controladora.CancelarReserva();
                    break;
                case 3:
                    ListarReservasPorHuesped(controladora);
                    break;
                case 4:
                    List<Apartamento> apartamentos = controladora.ListarApartamentosMasReservados();
                    Console.WriteLine("Apartamentos más reservados:");
                    foreach (var apartamento in apartamentos)
                    {
                        Console.WriteLine($"- Apartamento ID: {apartamento.Id}"); // Ajusta según tus propiedades
                    }
                    break;
                case 5:
                    return; // Salir del programa
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }
    }

    static void AgregarReserva(Controladora controladora)
    {
        Console.WriteLine("Ingrese el ID de la reserva:");
        int idReserva = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Ingrese el ID del huésped:");
        int idHuesped = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Ingrese el ID del apartamento:");
        int idApartamento = int.Parse(Console.ReadLine() ?? "0");

        Reserva nuevaReserva = new Reserva
        {
            IdReserva = idReserva,
            Huesped = new Huesped { IdHuesped = idHuesped },
            Apartamento = new Apartamento { Id = idApartamento }
        };

        controladora.AgregarReserva(nuevaReserva);
        Console.WriteLine("Reserva agregada con éxito.");
    }

    static void ListarReservasPorHuesped(Controladora controladora)
    {
        Console.WriteLine("Ingrese el ID del huésped:");
        int idHuesped = int.Parse(Console.ReadLine() ?? "0");

        Huesped huesped = new Huesped { IdHuesped = idHuesped };
        List<Reserva> reservas = controladora.ListarReservasPorHuesped(huesped);

        Console.WriteLine($"Reservas para el huésped ID: {idHuesped}");
        foreach (var reserva in reservas)
        {
            Console.WriteLine($"- Reserva ID: {reserva.IdReserva}"); // Ajusta según tus propiedades
        }
    }
}


