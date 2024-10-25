using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RefugioDelSol
{
    public class Huesped 
    {
        private static int UltimoId { get; set; } 
        public int IdHuesped { get; private set; }
        public string NombreHuesped { get; set; }
        public string ApellidoHuesped { get; set; }
        public int TelefonoHuesped { get; set; }
        public int CantidadValijas { get; set; }

        public static List<Huesped> Huespedes { get; set; } = new List<Huesped>(); 

        public Huesped(string nombreHuesped, string apellidoHuesped, int telefonoHuesped, int cantidadValijas)
        {
            this.IdHuesped = NuevoId();
            this.NombreHuesped = nombreHuesped;
            this.ApellidoHuesped = apellidoHuesped;
            this.TelefonoHuesped = telefonoHuesped;
            this.CantidadValijas = cantidadValijas;
        }

        private static int NuevoId()
        {
            UltimoId += 1;
            return UltimoId;
        }

        public static Huesped PedirDatosHuesped(){
            Console.Clear();
            Console.WriteLine("Agregar huesped");

            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese el apellido: ");
            string apellido = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese el telefono: ");
            int telefono = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Ingrese la cantidad de valijas: ");
            int cantidadValijas = int.Parse(Console.ReadLine() ?? string.Empty);

            return new Huesped(nombre, apellido, telefono, cantidadValijas);
        }

        public static string PedirDatosString(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine() ?? string.Empty;
        }

        public static int PedirDatosInt(string mensaje)
        {
            Console.WriteLine(mensaje);
            int respuesta = int.Parse(Console.ReadLine() ?? string.Empty);
            return respuesta;
        }
        
        public static void AgregarHuesped()
        {
            Huesped nuevoHuesped = PedirDatosHuesped();
            Huespedes.Add(nuevoHuesped);
            Console.WriteLine("Huesped Agregado correctamente");
        }

        public static Huesped BuscarHuespedPorId(int idHuesped)
        {
            foreach (Huesped huespedes in Huespedes)
            {
                if (huespedes.IdHuesped == idHuesped)
                {
                    return huespedes;
                }
            }
            return null;
        }

        public static bool EliminarHuesped()
        {
            Console.WriteLine("Escriba el ID del huesped que desea eliminar");

            if (!int.TryParse(Console.ReadLine(), out int idHuesped))
            {
                Console.WriteLine("ID invalido, intentalo denuevo");
                return false;
            }
            Huesped? huesped = BuscarHuespedPorId(idHuesped);
            if (huesped != null)
            {
                Huespedes.Remove(huesped);
                Console.WriteLine($"Huesped con ID {idHuesped} eliminado correctamente");
                return true;
            }
            else
            {
                Console.WriteLine($"No se encontro el huesped con ID {idHuesped}");
                return false;
            }
        }

        public static bool ModificarHuesped()
        {
            Console.WriteLine("Escriba el ID del huesped que desea modificar");
            int idHuesped = int.Parse (Console.ReadLine() ?? string.Empty);
            
            Huesped? huesped = BuscarHuespedPorId(idHuesped);
            if(huesped != null)
            {

                huesped.NombreHuesped = PedirDatosString("Ingrese un nuevo Nombre: ");
                huesped.ApellidoHuesped = PedirDatosString("Ingrese un nuevo Apellido: ");
                huesped.TelefonoHuesped = PedirDatosInt("Ingrese un nuevo Telefono: ");
                huesped.CantidadValijas = PedirDatosInt("Ingrese una nueva Cantidad de Valijas: ");
                Console.WriteLine("Huesped modificado correctamente");
                return true;
            }
            else
            {
                Console.WriteLine("Huesped no encontrado");
                return false;
            }
        }

        public static void ListarHuespedes()
        {
            Console.Clear();
            Console.WriteLine("Lista de huespedes");
            foreach( var huesped in Huespedes)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Nombre: {huesped.NombreHuesped}");
                Console.WriteLine($"Apellido: {huesped.ApellidoHuesped}");
                Console.WriteLine($"Telefono: {huesped.TelefonoHuesped}");
                Console.WriteLine($"Cantidad Valijas: {huesped.CantidadValijas}");
            }
        }
        
        public override string ToString()
        {
            return $"{NombreHuesped} {ApellidoHuesped}, Tel: {TelefonoHuesped}, Cantidad de Valijas: {CantidadValijas}";
        }
    }
}