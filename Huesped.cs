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

        public override string ToString()
        {
            return $"{NombreHuesped} {ApellidoHuesped}, Tel: {TelefonoHuesped}, Cantidad de Valijas: {CantidadValijas}";
        }



    }
}