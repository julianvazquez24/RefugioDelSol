using RefugioDelSol;
using System.ComponentModel.Design;

//Huesped zayn = new Huesped("zayn", "ndjndncj", 06188484, 1);
//Huesped juan = new Huesped("Juan", "Alvez", 98321456, 3);
//Huesped pedro = new Huesped("Pedro", "Perez", 94444444, 4);
//Huesped ana = new Huesped("Ana", "Martinez", 98218238, 5);

//List<Huesped> huespedes = new List<Huesped> { zayn, juan, pedro, ana };

//Controladora controladora = new Controladora();

//controladora.ListaAlfabeticaHuespedes(huespedes);

string input = "";

while (input != "fin")
{
    Console.WriteLine("Menu Refugio Del Sol");
    Console.WriteLine("1. Gestion de Huespedes");
    Console.WriteLine("2. Gestion de Apartamentos");
    Console.WriteLine("3. Gestion de Reservas");
    Console.WriteLine("4. Estadisticas");
    Console.WriteLine("Escribe fin para salir");
    Console.WriteLine("Seleccione una opcion: ");

    input = Console.ReadLine();

    if (input == "1")
    {
        Console.Clear();
        Console.WriteLine("Por favor selecciona una opcion");
        Console.WriteLine("(1) Agregar Huesped");
        Console.WriteLine("(2) Eliminar Huesped");
        Console.WriteLine("(3) Modificar Huesped");
        Console.WriteLine("(4) Listar Huespedes Alfabeticamente");

        int opcionHuesped = int.Parse(Console.ReadLine());
        switch (opcionHuesped)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Agregar huesped");
                break;

            case 2:
                Console.WriteLine("Eliminar huesped");
                break;

            case 3:
                Console.WriteLine("Modificar huesped");
                break;

            case 4:
                Console.WriteLine("Lista huespedes alfabeticamente");
                break;

            default:
                Console.WriteLine("Opcion no valida.");
                break;
        }
    }

    

    else if (input == "2") 
    {
        Console.Clear();
        Console.WriteLine("Por favor selecciona una opcion");
        Console.WriteLine("(1) Agregar Apartamento");
        Console.WriteLine("(2) Eliminar Apartamento");
        Console.WriteLine("(3) Modificar Apartamento");
        Console.WriteLine("(4) Listar Apartamentos Mas Reservados");
        
        int opcionApartamento = int.Parse(Console.ReadLine());;
        
        switch(opcionApartamento)
        {
            case 1:
            Console.WriteLine("Agregar apartamento");
            break;

            case 2:
            Console.WriteLine("Eliminar apartamento");
            break;

            case 3:
            Console.WriteLine("Modificar apartamento");
            break;

            case 4:
            Console.WriteLine("Lista de los apartamentos mas reservados");
            break;

            default:
            Console.WriteLine("Opcion no valida.");
            break;
        }
    }
    
    else if (input == "3")
    {
        Console.Clear();
        Console.WriteLine("Por favor selecciona una opcion");
        Console.WriteLine("(1) Agregar Reserva");
        Console.WriteLine("(2) Eliminar Reserva");
        Console.WriteLine("(3) Modificar Reserva");
        Console.WriteLine("(4) Listar Reservas");

        int opcionReserva = int.Parse(Console.ReadLine());

        switch(opcionReserva)
        {
            case 1:
            Console.WriteLine("Agregar reserva");
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
    
    else if(input == "4")
    {
        Console.Clear();
        Console.WriteLine("Por favor selecciona una opcion de estadistica");
        Console.WriteLine("(1) Listar apartamentos disponibles");
        Console.WriteLine("(2) Reservas del dia");
        Console.WriteLine("(3) Reservas del huesped");
        Console.WriteLine("(4) Apartamentos con mas reservas");

        int opcionEstadistica = int.Parse(Console.ReadLine());

        switch(opcionEstadistica)
        {
            case 1:
            Console.WriteLine("Lista de los apartamentos disponibles");
            break;

            case 2:
            Console.WriteLine("Reservas del dia");
            break;

            case 3:
            Console.WriteLine("Reservas del huesped");
            break;

            case 4:
            Console.WriteLine("Apartamentos con mas reservas");
            break;

            default:
            Console.WriteLine("Opcion no valida");
            break;
        }
    }
}
