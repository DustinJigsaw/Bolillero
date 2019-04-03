using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simulacionBolillero;

namespace simulacionBolillero
{
    class Simulacion
    {
        public Bolillero bolillero { get; set; }

        public Simulacion()
        {

        }

        public long SimularSinHilos(List<byte> jugada, long cantSimu)
        {
          return bolillero.jugar(jugada, cantSimu);
        }


    }
}
