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
        public int IdApartamento { get; set; }
        public int NumApartamento {get; set;}
        public int PrecioApartamento {get; set;}
        public string SurNorteApartamento {get; set;}
        public string EsteOesteMedio {get; set;}
        public int CantidadDormitorios {get; set;}
        public int SuperficieApartamento {  get; set;}

        public List<Apartamento> Apartamentos {get; set;} = new List<Apartamento>();
     
        public Apartamento( int precioApartamento, int idApartamento, string surNorteApartamento, string esteOesteMedio, int cantidadDormitorios, int superficieApartamento)
        {
            this.NumApartamento = NuevoNum();
            this.PrecioApartamento = precioApartamento;
            this.IdApartamento = idApartamento;
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

        public void AgregarApartamento(Apartamento apartamento)
        {
            Apartamentos.Add(apartamento);
            Console.WriteLine("Apartamento agregado correctamente");
        }

        public Apartamento BuscarApartamentoPorId(int idApartamento)
        {
            foreach(Apartamento apartamentos in this.Apartamentos)
            {
                if(apartamentos.IdApartamento == idApartamento)
                {
                    return apartamentos;
                }
            }
            return null;
        }

        public bool EliminarApartamento(int IdApartamento)
        {
            Console.Write("Escriba el id del apartamento que desea eliminar");
            int idApartamento = int.Parse(Console.ReadLine() ?? string.Empty);

            Apartamento? apartamento = this.BuscarApartamentoPorId(idApartamento);
            if(apartamento != null)
            {
                this.Apartamentos.Remove(apartamento);
                return true;
            }
            return false;
        }

        public bool ModificarApartamento(int nuevoNumApartamento, int nuevoPrecioApartamento, string nuevoSurNorteApartamento, string nuevoEsteOesteMedio, int nuevaCantidadDormitorios, int nuevaSuperficieApartamento)
        {
            Console.WriteLine("Escriba el id del apartamento que desea modificar");
            int idApartamento = int.Parse(Console.ReadLine() ?? string.Empty);

            Apartamento? apartamento = this.BuscarApartamentoPorId(idApartamento);
            if(apartamento != null)
            {
                apartamento.NumApartamento = nuevoNumApartamento;
                apartamento.PrecioApartamento = nuevoPrecioApartamento;
                apartamento.SurNorteApartamento = nuevoSurNorteApartamento;
                apartamento.EsteOesteMedio = nuevoEsteOesteMedio;
                apartamento.CantidadDormitorios = nuevaCantidadDormitorios;
                apartamento.SuperficieApartamento = nuevaSuperficieApartamento;
                Console.WriteLine("Apartamento modificado correctamente");
                return true;
            }
            else
            {
                Console.WriteLine("Apartamento no encontrado");
                return false;
            }
        }

        public void ListarApartamentos()
        {
            if(Apartamentos.Count == 0)
            {
                Console.WriteLine("No hay apartamentos registrados");
            }
            else
            {
                Console.WriteLine("Lista de los apartamentos");
                foreach(var apartamento in Apartamentos)
                {
                    Console.WriteLine(apartamento);
                }
            }
        }


    }
}
