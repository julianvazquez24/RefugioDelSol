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

            foreach (var huesped in huespedes)
            {
                Console.WriteLine(huesped);
            }
        }
        
        //public static void MostrarApartamentosDisponibles(List<Apartamento> apartamentos)
        //{
        //    var disponibles = apartamentos.Where(apartamento => apartamento.EstaDisponible).ToList(); 

        //    if (disponibles.Count == 0)
        //    {
        //        Console.WriteLine("No hay apartamentos disponibles.");
        //        return;
        //    }

        //    foreach (var apartamento in disponibles)
        //    {
        //        Console.WriteLine($"Apartamento {apartamento.NumApartamento}: Precio ${apartamento.PrecioApartamento}, " +
        //                     $"Orientación: {apartamento.SurNorteApartamento}/{apartamento.EsteOesteMedio}, " +
        //                     $"Dormitorios: {apartamento.CantidadDormitorios}, " +
        //                     $"Superficie: {apartamento.SuperficieApartamento} m², " +
        //                     $"Disponible: {apartamento.EstaDisponible}");
        //    }
        //}

        public List<Reserva> ListaReservaPorFecha(DateOnly fecha) 
        {
            List<Reserva> reservasPorFecha = new List<Reserva>();

            foreach (var reserva in Reserva.Reservas)
            {
                if (fecha >= reserva.FechaInicioReserva && fecha <= reserva.FechaFinReserva)
                {
                    reservasPorFecha.Add(reserva);
                }
            }
            return reservasPorFecha;
        }


        public static void MostrarReservasPorHuesped(int idHuesped){
            List<Reserva> reservasDelHuesped = new List<Reserva>();

            foreach(var reserva in Reserva.Reservas)
            {
                if(reserva.Huesped.IdHuesped == idHuesped)
                {
                    reservasDelHuesped.Add(reserva);
                }
            }

            if(reservasDelHuesped.Count > 0)
            {
                Console.WriteLine($"Reservas del huesped");
                foreach(var reserva in reservasDelHuesped)
                {
                    Console.WriteLine($"Fecha Incio de la reserva: {reserva.FechaInicioReserva} - Fecha Fin de la reserva: {reserva.FechaFinReserva}");
                }
            }
            else
            {
                Console.WriteLine($"No se encuentran reservas por el Id {idHuesped}");
            }
        }

        public List<Apartamento> ListaApartamentosMasReservados()
        {
            List<Apartamento> apartamentosMasReservados = new List<Apartamento>();
            foreach (var reserva in Reservas)
            {
                apartamentosMasReservados.Add(reserva.Apartamento);
            }
            return apartamentosMasReservados;
        }

       

       




        




        

    



    }
}
