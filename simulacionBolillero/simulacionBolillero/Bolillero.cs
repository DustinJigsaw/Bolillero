using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulacionBolillero
{
   public class Bolillero:ICloneable
   {
       Random r;
       public int cantidadBolilla { get; set; }
       public List<byte> bolillasAdentro { get; set; }
       public List<byte> bolillasAfuera { get; set; }

       public Bolillero()
       {
          
           r = new Random(DateTime.Now.Millisecond);
       }

       public int indiceAlAzar()
       {
           return r.Next(0, bolillasAdentro.Count);
       }
       public byte sacarBolilla()
       {
           byte bolilla = bolillasAdentro[indiceAlAzar()];
           sacarBolilla(bolilla);
           return bolilla;
  
       }

       public void sacarBolilla(byte bolilla)
       {
           bolillasAdentro.Remove(sacarBolilla());
           bolillasAfuera.Add(sacarBolilla());
       }

       public void regresarBolillas()
       {
           bolillasAdentro.AddRange(bolillasAfuera);
       }

       public bool jugar(List<byte> jugada)
       {
           for(byte i = 0; i < jugada.Count; i++)
           {
               if(jugada[i] == this.sacarBolilla())
                   return false;
           }
           return true;

       }
       public long Jugar(List<byte> jugada, long cantSimu)
       {
           long cant = 0;
           for(long i=0; i< cantSimu ; i++)
           {
               if(jugar(jugada))
               {
                   cant++;
               }
             regresarBolillas();
           }
           return cant;
       }

       public object Clone()
       {
           Bolillero clon = new Bolillero();
           clon.bolillasAdentro = new List<byte>(this.bolillasAdentro);
           clon.bolillasAfuera = new List<byte>(this.bolillasAfuera);
           return clon;
       }

      
       
   }
}
 

