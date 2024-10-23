using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RefugioDelSol
{
    public class Apartamento
    {
        private static int UltimoNum {  get; set; }
        public int NumApartamento {get; set;}
        public int PrecioApartamento {get; set;}
        public string SurNorteApartamento {get; set;}
        public string EsteOesteMedio {get; set;}
        public int CantidadDormitorios {get; set;}
        public int SuperficieApartamento {  get; set;}

        public List<Apartamento> Apartamentos {get; set;} = new List<Apartamento>();
     
        public Apartamento( int precioApartamento, string surNorteApartamento, string esteOesteMedio, int cantidadDormitorios, int superficieApartamento)
        {
            this.NumApartamento = NuevoNum();
            this.PrecioApartamento = precioApartamento;
            this.SurNorteApartamento= surNorteApartamento;
            this.EsteOesteMedio = esteOesteMedio;   
            this.CantidadDormitorios = cantidadDormitorios;
            this.SuperficieApartamento = superficieApartamento;
        }

        private static int NuevoNum()
        {
            Apartamento.UltimoNum += 1;
            return Apartamento.UltimoNum;
        }
    }
}
