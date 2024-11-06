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
        
        public static void MostrarApartamentosDisponibles(List<Apartamento> apartamentos)
        {
            var disponibles = apartamentos.Where(apartamento => apartamento.EstaDisponible).ToList(); 

            if (disponibles.Count == 0)
            {
                Console.WriteLine("No hay apartamentos disponibles.");
                return;
            }

            foreach (var apartamento in disponibles)
            {
                Console.WriteLine($"Apartamento {apartamento.NumApartamento}: Precio ${apartamento.PrecioApartamento}, " +
                             $"Orientación: {apartamento.SurNorteApartamento}/{apartamento.EsteOesteMedio}, " +
                             $"Dormitorios: {apartamento.CantidadDormitorios}, " +
                             $"Superficie: {apartamento.SuperficieApartamento} m², " +
                             $"Disponible: {apartamento.EstaDisponible}");
            }
        }

        // public Reserva AgregarReserva(Reserva nuevaReserva)
        // {
        //     this.Reservas.Add(nuevaReserva);
        //     return nuevaReserva;
        // }

        // public void CancelarReserva()
        // {
        //     Console.WriteLine("Ingrese el ID de la reserva que quieres cancelar: ");
        //     int idReserva = int.Parse(Console.ReadLine() ?? string.Empty);

        //     for (int i = 0; i < this.Reservas.Count; i++)
        //     {
        //         if (this.Reservas[i].IdReserva == idReserva)
        //         {
        //             this.Reservas.RemoveAt(i);
        //             Console.WriteLine("La reserva fue cancelada con exito");
        //             break;
        //         }
        //     }
        //     Console.WriteLine("La reserva no fue encontrada");
        // }

        public List<Reserva> ListarReservasPorHuesped(Huesped huesped)
        {
            List<Reserva> reservaPorHuesped = new List<Reserva>();
            foreach (var reserva in Reservas)
            {
                if (reserva.Huesped.IdHuesped == huesped.IdHuesped)
                {
                    reservaPorHuesped.Add(reserva);
                }
            }
            return reservaPorHuesped;
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




        




        public List<Reserva> ListaReservaFecha(DateOnly fecha)
        {
            List<Reserva> reservasPorFecha = new List<Reserva>();

            foreach (var reserva in Reservas)
            {
                if (reserva.FechaFinReserva == fecha)
                {
                    reservasPorFecha.Add(reserva);
                }
            }
            return reservasPorFecha;
        }

    



    }
}
