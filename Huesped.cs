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

        public List<Huesped> Huespedes { get; set; } = new List<Huesped>(); 

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

        public void AgregarHuesped(Huesped huesped)
        {
            Huespedes.Add(huesped);
            Console.WriteLine("Huesped agregado correctamente");
        }

        public Huesped BuscarHuespedPorId(int idHuesped)
        {
            foreach (Huesped huespedes in this.Huespedes)
            {
                if (huespedes.IdHuesped == idHuesped)
                {
                    return huespedes;
                }
            }
            return null;
        }

        public bool EliminarHuesped(int IdHuesped)
        {
            Console.WriteLine("Escriba el ID del huesped que desea eliminar");
            int idHuesped = int.Parse(Console.ReadLine() ?? string.Empty);

            Huesped? huesped = this.BuscarHuespedPorId(idHuesped);
            if (huesped != null)
            {
                this.Huespedes.Remove(huesped);
                return true;
            }
            return false;
        }

        public bool ModificarHuesped( string nuevoNombre, string nuevoApellido, int nuevoTelefono, int nuevasValijas)
        {
            Console.WriteLine("Escriba el ID del huesped que desea Modificar");
            int idHuesped = int.Parse (Console.ReadLine() ?? string.Empty);
            Huesped? huesped = this.BuscarHuespedPorId(idHuesped);
            if(huesped != null)
            {
                huesped.NombreHuesped = nuevoNombre;
                huesped.ApellidoHuesped = nuevoApellido;
                huesped.TelefonoHuesped = nuevoTelefono;
                huesped.CantidadValijas = nuevasValijas;
                Console.WriteLine("Huesped modificado correctamente");
                return true;
            }
            else
            {
                Console.WriteLine("Huesped no encontrado");
                return false;
            }

        }

        
        



        public override string ToString()
        {
            return $"{NombreHuesped} {ApellidoHuesped}, Tel: {TelefonoHuesped}, Cantidad de Valijas: {CantidadValijas}";
        }


        
        


    }
}