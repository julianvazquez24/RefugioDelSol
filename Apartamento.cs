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
        public int SuperficieApartamento { get; set;}

        public static List<Apartamento> Apartamentos {get; set;} = new List<Apartamento>();
     
        public Apartamento( int precioApartamento,string surNorteApartamento, string esteOesteMedio, int cantidadDormitorios, int superficieApartamento)
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

        public static Apartamento PedirDatosApartamento()
        {

            Console.Clear();
            Console.WriteLine("Agregar Apartamento:");

            Console.WriteLine("Ingrese el precio del apartamento: ");
            int precioApartamento = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Ingrese la orientacion (Sur o Norte): ");
            string surNorteApartamento = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese la orientacion (Este/Oeste/Medio): ");
            string esteOesteMedio = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Ingrese la cantidad de dormitorios: ");
            int cantidadDormitorios = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Ingrese la superficie del apartamento: ");
            int superficieApartamento = int.Parse(Console.ReadLine() ?? string.Empty);

            return new Apartamento(precioApartamento,surNorteApartamento,esteOesteMedio,cantidadDormitorios,superficieApartamento);
        }

        public static void AgregarApartamento()
        {
            Apartamento nuevoApartamento = PedirDatosApartamento();
            Apartamentos.Add(nuevoApartamento);
            Console.WriteLine("Apartamento agregado correctamente");
            
        }


        public Apartamento BuscarApartamentoPorNum(int numApartamento)
        {
            foreach(Apartamento apartamentos in Apartamentos)
            {
                if(apartamentos.NumApartamento == numApartamento)
                {
                    return apartamentos;
                }
            }
            return null;
        }

        public bool EliminarApartamento(int numApartamento)
        {
            Console.Write("Escriba el numero del apartamento que desea eliminar");
            int numApartamentoInt = int.Parse(Console.ReadLine() ?? string.Empty);

            Apartamento? apartamento = this.BuscarApartamentoPorNum(numApartamentoInt);
            if(apartamento != null)
            {
                Apartamentos.Remove(apartamento);
                return true;
            }
            return false;
        }

        public bool ModificarApartamento()
        {
            Console.WriteLine("Escriba el numero del apartamento que desea modificar");
            int numApartamento = int.Parse(Console.ReadLine() ?? string.Empty);

            Apartamento? apartamento = this.BuscarApartamentoPorNum(numApartamento);
            if(apartamento != null)
            {
                apartamento.PrecioApartamento = Huesped.PedirDatosInt("Ingrese un nuevo precio:");
                apartamento.SurNorteApartamento = Huesped.PedirDatosString("Ingrese una nueva opcion (Sur / Norte):");
                apartamento.EsteOesteMedio = Huesped.PedirDatosString("Ingrese una nueva opcion (Este / Oeste / Medio):");
                apartamento.CantidadDormitorios = Huesped.PedirDatosInt("Ingrese una nueva cantidad de Dormitorios):");
                apartamento.SuperficieApartamento = Huesped.PedirDatosInt("Ingrese una nueva superficie:");
                Console.WriteLine("Apartamento modificado correctamente");
                return true;
            }
            else
            {
                Console.WriteLine("Apartamento no encontrado");
                return false;
            }
        }

        public static void ListarApartamentos()
        {
            Console.Clear();
            Console.WriteLine("Lista de Apartamentos");
            foreach ( var apartamento in Apartamentos)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Numero: {apartamento.NumApartamento}");
                Console.WriteLine($"Precio: {apartamento.PrecioApartamento}");
                Console.WriteLine($"Orientacion N/S: {apartamento.SurNorteApartamento}");
                Console.WriteLine($"Orientacion E/O/M: {apartamento.EsteOesteMedio}");
                Console.WriteLine($"Cantidad dormitorios: {apartamento.CantidadDormitorios}");
                Console.WriteLine($"Superficie: {apartamento.SuperficieApartamento} m2");
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
        }


    }
}
