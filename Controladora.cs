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
        public static List<Reserva> Reservas { get; set; } = new List<Reserva>();
        public List<Huesped> Huespedes = new List<Huesped>();
        public List<Apartamento> Apartamentos = new List<Apartamento>();
        public Controladora()
        {
            this.Huespedes = new List<Huesped>();
            this.Apartamentos = new List<Apartamento>();
        }

        public static void ListarApartamentosDisponibles(DateOnly fechaInicioReserva, DateOnly fechaFinReserva)
        {
            List<Apartamento> apartamentosDisponibles = Apartamento.Apartamentos.ToList();

            foreach (Reserva reserva in Reservas)
            {
                if (!(fechaFinReserva < reserva.FechaInicioReserva || fechaInicioReserva > reserva.FechaFinReserva))
                {
                    apartamentosDisponibles.Remove(reserva.Apartamento);
                }
            }

            if (apartamentosDisponibles.Count > 0)
            {
                Console.WriteLine("Apartamentos disponibles en las fechas seleccionadas:");
                foreach (var apartamento in apartamentosDisponibles)
                {
                    Console.WriteLine($"Numero de Apartamento: {apartamento.NumApartamento}");
                }
            }
            else
            {
                Console.WriteLine("No hay apartamentos disponibles en las fechas seleccionadas.");
            }
        }

        public static void ListarApartamentosConMasReservas()
        {
            Console.WriteLine("Apartamentos con más reservas:");

            var apartamentosOrdenados = Apartamento.Apartamentos
                .OrderByDescending(a => a.VecesReservado)
                .ToList();

            foreach (Apartamento apartamento in apartamentosOrdenados)
            {
                Console.WriteLine($"Número de Apartamento: {apartamento.NumApartamento}, Veces Reservado: {apartamento.VecesReservado}");
            }
        }

        public static void MostrarReservasPorHuesped(int idHuesped)
        {

            List<Reserva> todasLasReservasHuesped = Reservas
                .Where(reserva => reserva.IdHuesped == idHuesped)
                .ToList();

            if (todasLasReservasHuesped.Count > 0)
            {
                Console.WriteLine($"Reservas del huésped con ID {idHuesped}:");
                foreach (Reserva reserva in todasLasReservasHuesped)
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
                Console.WriteLine($"No se encontraron reservas para el huésped con ID {idHuesped}.");
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

        public static int EstPromedioDurEst()
        {
            if (Reservas.Count == 0)
            {
                return 0;
            }
            int sumaDuracion = 0;
            foreach (Reserva reserva in Reservas)
            {
                DateOnly fechaFin = reserva.FechaFinReserva;
                DateOnly fechaInicio = reserva.FechaInicioReserva;
                int duracion = (fechaFin.DayNumber - fechaInicio.DayNumber);
                sumaDuracion += duracion;
            }
            return sumaDuracion / Reservas.Count;
        }

        public static void MostrarInformacionConvencionesYEsparcimiento()
        {

            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("El centro de convenciones y esparcimiento es de acceso libre para todos los huéspedes.");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        public static void MostrarInformacionParque()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("El parque Este es de acceso libre y se pueden llevar mascotas.");
            Console.WriteLine("El acceso al parque es por helicóptero o submarino.");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
