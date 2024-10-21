using RefugioDelSol;

Huesped juan = new Huesped("Juan", "Alvez", 98321456, 3);
Huesped pedro = new Huesped("Pedro", "Perez", 94444444, 4);
Huesped ana = new Huesped("Ana", "Martinez", 98218238, 5);

List<Huesped> huespedes = new List<Huesped> {juan, pedro, ana };

huespedes.Sort((a, b) => a.NombreHuesped.CompareTo(b.NombreHuesped));

Console.WriteLine("Lista de huéspedes ordenada alfabéticamente:");
Console.WriteLine("-------------------------------------------");
foreach (var huesped in huespedes)
{
    Console.WriteLine(huesped);
}

