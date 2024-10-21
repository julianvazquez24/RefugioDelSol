using RefugioDelSol;


Huesped juan = new Huesped("Juan", "Alvez", 098321456, 3);
Huesped pedro = new Huesped("Pedro", "Perez", 094444444, 4);
Huesped ana = new Huesped("Ana", "Martinez", 098218238, 5);

List<Huesped> huespedes = new List<Huesped> { juan, pedro, ana };

huespedes.Sort();

Console.WriteLine("Lista de huespedes ordenada Alfabeticamente");
Console.WriteLine("-------------------------------------------");

foreach (var huesped in huespedes)
{
    Console.WriteLine("{0}", huesped);
}






