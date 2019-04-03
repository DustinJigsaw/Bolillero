using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulacionBolillero
{
    public class Bolillero
    {
        public List<byte> BollillasAdentro { get; set; }
        public List<byte> BollillasAfuera { get; set; }

        Random r;
         public Bolillero()
        {
            r = new Random(DateTime.Now.Millisecond);
        }
        public int IndiceAlAzar()
        {
            BollillasAdentro = (byte)r.Next(1, this.BollillasAfuera.Count + 1);
        }

        public byte SacarBolilla()
        {
            BollillasAdentro.ForEach(
        }

    }
}
