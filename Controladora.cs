using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RefugioDelSol
{
    public class Controladora
    {

        public List<Reserva> Reservas { get; set; }
        public List<Huesped> Huespedes = new List<Huesped>();
        public List<Apartamento> Apartamentos = new List<Apartamento>();
        public Controladora()
        {
            this.Reservas = new List<Reserva>();
            this.Huespedes = new List<Huesped>();
            this.Apartamentos = new List<Apartamento>();
        }




        public static void ListarHuespedesOrdenadosAlfabeticamente(List<Huesped> huespedes)
        {
            huespedes.Sort((a, b) => a.NombreHuesped.CompareTo(b.NombreHuesped));
            Console.WriteLine("Lista de huéspedes ordenada alfabéticamente:");
            Console.WriteLine("-------------------------------------------");

            foreach (Huesped huesped in huespedes)
            {
                Console.WriteLine(huesped);
            }
        }

        public static void MostrarReservasPorFecha(DateOnly fechaIngresada)
        {

            List<Reserva> reservasEnFecha = Reserva.Reservas
                .Where(reserva => reserva.FechaInicioReserva == fechaIngresada)
                .ToList();

            if (reservasEnFecha.Count > 0)
            {
                Console.WriteLine($"Reservas con fecha de inicio {fechaIngresada}:");
                foreach (var reserva in reservasEnFecha)
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"Id Reserva: {reserva.IdReserva}");
                    Console.WriteLine($"Fecha Inicio: {reserva.FechaInicioReserva}");
                    Console.WriteLine($"Fecha Fin: {reserva.FechaFinReserva}");
                    Console.WriteLine($"Número de Apartamento: {reserva.Apartamento?.NumApartamento ?? 0}");
                    Console.WriteLine($"Precio Base: {reserva.PrecioBase} USD");
                    Console.WriteLine($"Cantidad de Valijas: {reserva.CantidadValijas}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron reservas para la fecha {fechaIngresada}.");
            }
        }




    }
}
