using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioDelSol
{
    public class Controladora
    {
        public List<Reserva> Reservas { get; set; }
        public List<Huesped> Huespedes { get; set; }
        public List<Apartamento> Apartamentos { get; set; }
        public Controladora()
        {
            this.Reservas = new List<Reserva>();
            this.Huespedes = new List<Huesped>();
            this.Apartamentos = new List<Apartamento>();
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

        public List<Apartamento> ListarApartamentosMasReservados()
        {
            List<Apartamento> apartamentosMasReservados = new List<Apartamento>();
            foreach (var reserva in Reservas)
            {
                apartamentosMasReservados.Add(reserva.Apartamento);
            }
            return apartamentosMasReservados;
        }
        
        public void ListaAlfabeticaHuespedes(List<Huesped> huespedes)
        {
            huespedes.Sort();
            Console.WriteLine("Lista de huespedes ordenada Alfabeticamente");
            Console.WriteLine("-------------------------------------------");
            foreach (var huesped in huespedes)
            {
                Console.WriteLine("{0}", huesped);
            }
        }

        public List<Huesped> ListarReservaFecha(DateTime fecha)
        {
            List<Huesped> reservasPorFecha = new List<Huesped>();
            List<Huesped> listaHuespedes = ObtenerListaDeHuespedes();
            foreach (var huesped in ListarHuespedes)
            {
                if (huesped.FechaFinReserva.Date == fecha.Date)
                {
                    reservasPorFecha.Add(huesped);
                }
            }
            return reservasPorFecha;
        }

        public void ListarReservasPorHuesped(List<Reserva> reservas)
        {
            List<Reserva> listaReservasPorHuesped = new List<Reserva>();
            foreach(var reserva in reservas)
            {
                
            }
        }

      //  public void ListarApartamentosMasReservados(List<)

        // public List<Apartamento> ListaApartamentosDisponibles()
        // {
        //     List<Apartamento> ListaApartamentosDisponibles = new List<Apartamento>();

        //     foreach(var apartamento in ListaApartamento)
        //     {
                
        //     }

        // }
    }
}