using RefugioDelSol;

Huesped zayn = new Huesped("zayn", "ndjndncj", 06188484, 1);
Huesped juan = new Huesped("Juan", "Alvez", 98321456, 3);
Huesped pedro = new Huesped("Pedro", "Perez", 94444444, 4);
Huesped ana = new Huesped("Ana", "Martinez", 98218238, 5);

List<Huesped> huespedes = new List<Huesped> { zayn, juan, pedro, ana };

Controladora controladora = new Controladora();

controladora.ListaAlfabeticaHuespedes(huespedes);
