using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace RefugioDelSol
{
    public class Reserva
    {
        private static int UltimoId {  get; set; }
        public int IdReserva { get; set; }
        public DateTime FechaInicioReserva { get; set; }
        public DateTime FechaFinReserva { get; set; }
        public int PrecioBase { get; set; }
        public List<Reserva> Reservas { get; set; }
        public Huesped Huesped { get; set; }
        public Apartamento Apartamento { get; set; }
        public Reserva(int idReserva, DateTime fechaInicio, DateTime fechaFin, int precioBase, Apartamento apartamento)
        {
            this.IdReserva = idReserva;
            this.FechaInicioReserva = fechaInicio;
            this.FechaFinReserva = fechaFin;
            this.PrecioBase = precioBase;
            this.Reservas = new List<Reserva>();
        }

        private static int NuevoId()
        {
            Reserva.UltimoId += 1; 
            return Reserva.UltimoId;
        }

        // public int EstPromedioPorApartamento()
        // {
            
        //     if (Reservas.Count == 0)
        //     {
        //         return 0; // si no hay reservas va a devolver 0
        //     }
        //     int sumaDuracion = Reservas.Sum(reserva => ((reserva.FechaFinReserva - reserva.FechaInicioReserva).Days));
        //     return sumaDuracion / Reservas.Count; // me va a dar el resultado del promedio de duracion de todas las reservas en dias del apartamento
        // }
        
        public int EstPromedioDurEst()
        {
            if (Reservas.Count == 0)
            {
                return 0;
            }
            int sumaDuracion = 0;
            foreach (var reserva in Reservas)
            {
                int duracion = (reserva.FechaFinReserva - reserva.FechaInicioReserva).Days;
                sumaDuracion += duracion;
            }
            return sumaDuracion / Reservas.Count;
        }
        public void DuracionReservaMenorA30()
        {
            // calcula la duración en dias
            int duracion = (FechaFinReserva - FechaInicioReserva).Days;
            if(duracion > 30)
            {
                Console.WriteLine("La reserva no puede exceder los 30 dias de estadia.");
            }
            else
            {
                Console.WriteLine($"La reserva tiene una duracion valida, {duracion} dias.");
            }
        }
        public bool EsHabitacionDisponible()
        {
            foreach(var reserva in Reservas)
            {
                if (reserva.FechaInicioReserva < FechaFinReserva && FechaInicioReserva < reserva.FechaFinReserva) // verifico si hay reserva en esas fechas
                {
                    return false;
                }
            }
            return true;
        }
    }
}