using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RefugioDelSol
{
    public class Huesped
    {
        private static int UltimoId {get; set; }
        public int IdHuesped { get; set; }
        public string NombreHuesped { get; set; }
        public string ApellidoHuesped { get; set; }
        public int TelefonoHuesped { get; set; }
        public int CantidadValijas { get; set; } // limitar a 5 x persona
        
        public Huesped(int idHuesped, string nombreHuesped, string apellidoHuesped, int telefonoHuesped, int cantidadValijas)
        {
            this.IdHuesped = idHuesped;
            this.NombreHuesped = nombreHuesped;
            this.ApellidoHuesped = apellidoHuesped;
            this.TelefonoHuesped = telefonoHuesped;
            this.CantidadValijas = cantidadValijas;
        }

        private static int NuevoId(){
            Huesped.UltimoId =+ 1;
            return Huesped.UltimoId;
        }
    }
}