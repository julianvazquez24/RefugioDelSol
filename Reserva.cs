using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public Reserva(int idReserva, DateTime fechaInicio, DateTime fechaFin, int precioBase)
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
        
    }
}