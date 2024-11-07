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
        public int IdHuesped { get; set; } 
        public static List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public static List<Apartamento> ListaApartamentosDisponibles { get; set; } = new List<Apartamento>();
        public Huesped Huesped { get; set; }
        public Apartamento Apartamento { get; set; }
        public Reserva(int idReserva, DateOnly fechaInicio, DateOnly fechaFin,int numApartamento, int precioBase, int cantidadValijas, int idHuesped)
        {
            this.IdReserva = NuevoId();
            this.FechaInicioReserva = fechaInicio;
            this.FechaFinReserva = fechaFin;
            this.Apartamento = ListaApartamentosDisponibles.FirstOrDefault(a => a.NumApartamento == numApartamento);
            if (this.Apartamento == null)
            {
                throw new Exception($"No se encontró un apartamento con el número {numApartamento} disponible.");
            }
            this.PrecioBase = precioBase;
            this.CantidadValijas = cantidadValijas;
            this.IdHuesped = idHuesped;

        }

        private static int NuevoId()
        {
            Reserva.UltimoId += 1; 
            return Reserva.UltimoId;
        }
        
        public void CantidadValijasPorPersona(int cantidadValijas)
        {
            
            if (cantidadValijas > 5)
            {
                Console.WriteLine("No se permite tener mas de 5 valijas por personas");
                this.CantidadValijas = 5;
            }
            else
            {
                this.CantidadValijas = cantidadValijas;
            }
        }
        
        public int EstPromedioDurEst()
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
        public static bool EsDuracionValida(DateOnly fechaInicio, DateOnly fechaFin)
        {
            int duracion = (fechaFin.DayNumber - fechaInicio.DayNumber);
            if (duracion > 30)
            {
                Console.WriteLine("La reserva no puede exceder los 30 días de estadía.");
                return false;
            }
            Console.WriteLine($"La reserva tiene una duración válida de {duracion} días.");
            return true;
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

            // hace la excepcion 
            catch (Exception exception)
            {
                Console.WriteLine($"Ha tenido el siguiente error: {exception.Message}");
                return null;
            }

            if (!EsDuracionValida(fechaInicio, fechaFin))
            {
                return null;
            }

            BuscarApartamentoDisponible(fechaInicio, fechaFin);
            Console.WriteLine("Ingresar Numero de apartamento");
            int numApartamento = int.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Agregar Cantidad de Valijas:");
            int cantidadValija = int.Parse(Console.ReadLine() ?? string.Empty);

            int precioBase = 250;
            Console.WriteLine($"El precio base por noche es: {precioBase} USD");

            Console.WriteLine("Ingresar Id del huesped que hara la reserva");
            int idHuesped = int.Parse(Console.ReadLine() ?? string.Empty);

            return new Reserva(idReserva,fechaInicio,fechaFin,numApartamento,precioBase,cantidadValija, idHuesped);
            
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
            nuevaReserva.Apartamento.VecesReservado += 1;
        }

        public static bool CancelarReserva(){
            Console.WriteLine("Ingrese el ID de la reserva que deseas cancelar: ");

            if (!int.TryParse(Console.ReadLine(), out int idReserva))
            {
                Console.WriteLine("ID invalido, intentalo denuevo");
                return false;
            }
            Reserva? reserva = BuscarReservaPorId(idReserva);
            if(reserva != null)
            {
                Reservas.Remove(reserva);
                Console.WriteLine($"Reserva con ID {idReserva} eliminado correctamente");
                return true;
            }
            else
            {
                Console.WriteLine($"No se encontro la Reserva con ID {idReserva}");
                return false;
            }
        }

        public static Reserva? BuscarReservaPorId(int idReserva)
        {
            foreach(Reserva reserva in Reservas)
            {
                if(reserva.IdReserva == idReserva)
                {
                    return reserva;
                }
            }
            return null;
        }

        public  static DateOnly PedirFecha(string mensaje)
        {
            while (true)
            {
                Console.WriteLine(mensaje);
                string input = Console.ReadLine() ?? string.Empty;

                if (DateOnly.TryParse(input, out DateOnly fecha))
                {
                    return fecha;
                }
                else
                {
                    Console.WriteLine("Fecha inválida. Por favor, ingrese una fecha en el formato yyyy-MM-dd.");
                }
            }
        }

        public static bool ModificarReserva()
        {
           Console.WriteLine("Ingrese el ID de la reserva que deses modificar");
           int idReserva = int.Parse (Console.ReadLine() ?? string.Empty);

           Reserva? reserva = BuscarReservaPorId(idReserva);
           if(reserva != null)
           {
                reserva.FechaInicioReserva = Reserva.PedirFecha("Ingrese una nueva Fecha de Inicio (yyyy-MM-dd): ");
                reserva.FechaFinReserva = Reserva.PedirFecha("Ingrese una nueva Fecha de Fin (yyyy-MM-dd): ");
                reserva.PrecioBase = Huesped.PedirDatosInt("Ingrese un nuevo Precio Base: ");
                reserva.CantidadValijas = Huesped.PedirDatosInt("Ingrese la nueva cantidad de Valijas: ");
                Console.WriteLine("Reserva modificada correctamente");
                return true;
           }
           else
           {
            Console.WriteLine("Reserva no encontrada");
            return false;
           }
        }

        public static DateOnly PedirDatosFecha(string mensaje)
        {
            Console.WriteLine(mensaje);
            DateOnly fecha;
            while (!DateOnly.TryParse(Console.ReadLine(), out fecha))
            {
                Console.WriteLine("Fecha inválida. Intente nuevamente en formato yyyy-MM-dd:");
            }
            return fecha;
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




        public static void ListarReservas()
        {

            Console.WriteLine("Lista de Reservas");
            foreach (Reserva reserva in Reservas)
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