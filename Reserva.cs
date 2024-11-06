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
        public DateOnly FechaInicioReserva { get; set; }
        public DateOnly FechaFinReserva { get; set; }
        public int PrecioBase { get; set; }
        public int CantidadValijas { get; set; }
        public static List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public static List<Apartamento> ListaApartamentosDisponibles { get; set; } = new List<Apartamento>();
        public Huesped Huesped { get; set; }
        public Apartamento Apartamento { get; set; }
        public Reserva(int idReserva, DateOnly fechaInicio, DateOnly fechaFin,int numApartamento, int precioBase, int cantidadValijas)
        {
            this.IdReserva = NuevoId();
            this.FechaInicioReserva = fechaInicio;
            this.FechaFinReserva = fechaFin;
            this.Apartamento.NumApartamento = numApartamento;
            this.PrecioBase = precioBase;
            this.CantidadValijas = cantidadValijas;
        }

        private static int NuevoId()
        {
            Reserva.UltimoId += 1; 
            return Reserva.UltimoId;
        }
        
        public int EstPromedioDurEst()
        {
            if (Reservas.Count == 0)
            {
                return 0;
            }
            int sumaDuracion = 0;
            foreach (var reserva in Reservas)
            {
                DateOnly fechaFin = reserva.FechaFinReserva;
                DateOnly fechaInicio = reserva.FechaInicioReserva;
                int duracion = (fechaFin.DayNumber - fechaInicio.DayNumber);
                sumaDuracion += duracion;
            }
            return sumaDuracion / Reservas.Count;
        }
        public void DuracionReservaMenorA30()
        {
            // calcula la duracion en dias
            
            int duracion = (FechaFinReserva.DayNumber - FechaInicioReserva.DayNumber);
            if(duracion > 30)
            {
                Console.WriteLine("La reserva no puede exceder los 30 dias de estadia.");
            }
            else
            {
                Console.WriteLine($"La reserva tiene una duracion valida, {duracion} dias.");
            }
        }


        public static Reserva PedirDatosReserva() 
        {
            Console.WriteLine("Agregar Reserva");
            int idReserva = NuevoId();

            DateOnly fechaInicio, fechaFin;

            try
            {
                Console.WriteLine("Agregue una fecha de Ingreso (yyyy-MM-dd):");
                fechaInicio = DateOnly.Parse(Console.ReadLine() ?? throw new Exception("Fecha Invalida"));

                Console.WriteLine("Agregue una fecha de Salida (yyyy-MM-dd):");
                fechaFin = DateOnly.Parse(Console.ReadLine() ?? throw new Exception("Fecha inválida."));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ha tenido el siguiente error: {exception.Message}");
                return null;
            }

            BuscarApartamentoDisponible(fechaInicio, fechaFin);
            Console.WriteLine("Ingresar Numero de apartamento");
            int numApartamento = int.Parse(Console.ReadLine() ?? string.Empty);


            Console.WriteLine("Agregar Precio Base:");
            int precioBase = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Agregar Cantidad de Valijas:");
            int cantidadValija = int.Parse(Console.ReadLine() ?? string.Empty);
            return new Reserva(idReserva,fechaInicio,fechaFin,numApartamento,precioBase,cantidadValija);
        } 


        public static bool BuscarApartamentoDisponible(DateOnly fechaInicio, DateOnly fechaFin)
        {
            ListaApartamentosDisponibles.Clear();

            ListaApartamentosDisponibles = Apartamento.Apartamentos.ToList();

            foreach (Reserva reserva in Reserva.Reservas)
            {
                
                if (!(fechaFin < reserva.FechaInicioReserva || fechaInicio > reserva.FechaFinReserva))
                {
                    ListaApartamentosDisponibles.Remove(reserva.Apartamento);
                }
            }

            if (ListaApartamentosDisponibles.Count > 0)
            {
                Console.WriteLine("Apartamentos disponibles:");
                foreach (var apartamento in ListaApartamentosDisponibles)
                {
                    Console.WriteLine($"Numero: {apartamento.NumApartamento}");
                }
                return true;
            }
            else
            {
                Console.WriteLine("No hay apartamentos disponibles en las fechas seleccionadas.");
                return false;
            }
        }

        public static void AgregarReserva()
        {
            Reserva nuevaReserva = PedirDatosReserva();
            Reservas.Add(nuevaReserva);
            
        }

        public static void ListarReservas()
        {
            Console.Clear();
            Console.WriteLine("Lista de huespedes");
            foreach (var reserva in Reservas)
            {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Id Reserva: {reserva.IdReserva}");
            Console.WriteLine($"Fecha Inicio: {reserva.FechaInicioReserva}");
            Console.WriteLine($"Fecha Fin: {reserva.FechaFinReserva}");
            Console.WriteLine($"Numero de Apartamento {reserva.Apartamento.NumApartamento}");
            Console.WriteLine($"Precio Base US$: {reserva.PrecioBase}");
            Console.WriteLine($"Cantidad de valijas: {reserva.CantidadValijas}");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            }    
        }
    }
}   