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
        public List<byte> bolillas { get; set; }

        Random r;
    

         public Bolillero()
        {
            r = new Random(DateTime.Now.Millisecond);
        }

        public void agregarBolillas(Bolillero bolillero)
         {
             bolillas.Add(bolillero);
         }
    

        public int IndiceAlAzar()
        {
            return r.Next(1, this.BollillasAdentro.Count);
        }

        public byte SacarBolilla()
        {
            byte bolilla = BollillasAdentro[IndiceAlAzar()];
            sacarBolilla(bolilla);
            return bolilla;
        }
        
        public void sacarBolilla(byte bolilla)
        {
            BollillasAdentro.Remove(SacarBolilla());
            BollillasAfuera.Add(SacarBolilla());
        }

        public void ReingresarBolilla()
        {
            BollillasAdentro.AddRange(BollillasAfuera);
        }

        public bool jugar(List<byte> jugada)
        {
            for (byte i=0; i<jugada.Count; i++)
            {
                if(jugada[i] == this.SacarBolilla())
                
                    return false;
                }
                
                return true;
        }

        public long jugar(List<byte> Jugada, long cantSimu )
        {
            long cant = 0;
            for (long i = 0; i < cantSimu; i++)
            {
                if (jugar(Jugada))
                {
                    cant++;
                }
                ReingresarBolilla();
            }
            return cant;
        }

        public object Clone()
        {
            Bolillero clon = new Bolillero();
            clon.BollillasAdentro = new List<byte>(this.BollillasAdentro);
            clon.BollillasAfuera = new List<byte>(this.BollillasAfuera);
            return clon;

        }
    }
 }

