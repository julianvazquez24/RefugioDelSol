using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioDelSol
{
    class Controladora
    {
        public List<Reserva> Reservas { get; set; }
        public Controladora()
        {

            this.Reservas  = new List<Reserva>();

        }
    }
}