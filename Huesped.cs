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
        public bool TieneMascota { get; set; }
        


        public static List<Huesped> Huespedes { get; set; } = new List<Huesped>(); 

        public Huesped(string nombreHuesped, string apellidoHuesped, int telefonoHuesped,  bool tieneMascota)
        {
            this.IdHuesped = NuevoId();
            this.NombreHuesped = nombreHuesped;
            this.ApellidoHuesped = apellidoHuesped;
            this.TelefonoHuesped = telefonoHuesped;
            this.TieneMascota = tieneMascota;
        }

        private static int NuevoId()
        {
            UltimoId += 1;
            return UltimoId;
        }
        public override string ToString()
        {
            return $"{NombreHuesped} {ApellidoHuesped}, Tel: {TelefonoHuesped}, Mascota: {(TieneMascota ? "Si" : "No")}";
        }
        public void MostrarInformacionTienenAcceso()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"{IdHuesped}, {NombreHuesped}, {ApellidoHuesped},{TieneMascota}");
            Console.WriteLine("---------------------------------------------------------------");
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

        public static Huesped PedirDatosHuesped(){
            Console.Clear();
            Console.WriteLine("Agregar huesped");

            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese el apellido: ");
            string apellido = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese el telefono: ");
            int telefono = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("¿Tiene mascotas?");
            bool tieneMascota = bool.Parse(Console.ReadLine() ?? string.Empty);

            return new Huesped(nombre, apellido, telefono, tieneMascota);
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
        //public static bool PedirDatosBool(bool mensaje)
        //{
        //    Console.WriteLine(mensaje);
        //    bool respuesta = bool.Parse(Console.ReadLine() ?? string.Empty);
        //    return respuesta;
        //}
        
        public static void AgregarHuesped()
        {
            Huesped nuevoHuesped = PedirDatosHuesped();
            Huespedes.Add(nuevoHuesped);
            Console.WriteLine("Huesped Agregado correctamente");
            nuevoHuesped.MostrarInformacionTienenAcceso();
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
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        
    }
}