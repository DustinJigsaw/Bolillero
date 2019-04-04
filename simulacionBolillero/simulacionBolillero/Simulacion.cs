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
        public byte CantidadSimulaciones { get; set; }
        public ulong CantidadAciertos { get; private set; }
        public List<byte> Numero { get; set; }
        public Simulacion()
        {

        }

        public long SimularSinHilos(List<byte> jugada, long cantSimu)
        {
          return bolillero.jugar(jugada, cantSimu);
        }

       
        public void simularConHilos(int cantidadHilos)
        {
            List<Task<ulong>> hilos = new List<Task<ulong>>();
            List<Bolillero> Bolillero = new List<Bolillero>();
            ulong cantidadPorHilo = this.CantidadSimulaciones / (ulong)cantidadHilos;
            for (int i = 0; i < cantidadHilos; i++)
            {
                Bolillero bolilleroClon = (Bolillero)bolillero.Clone();
                Task<ulong> tarea = new Task<ulong>(() => simularCon(bolilleroClon, cantidadPorHilo));
                hilos.Add(tarea);
            }

            hilos.ForEach(hilo => hilo.Start());
           
            while (!hilos.TrueForAll(hilo => hilo.IsCompleted)) ;
            
            this.CantidadAciertos = 0;
            
            hilos.ForEach(hilo => CantidadAciertos += hilo.Result);
        }

        private ulong simularCon(Bolillero bolilleroClon, ulong cantidadPorHilo)
        {
            ulong aciertos = 0;
            for (ulong i = 0; i < CantidadSimulaciones; i++)
            {
                
                bolillero.SacarBolilla();
                if (bolillero.jugar(Numero))
                {
                    aciertos++;
                }
            }
            return aciertos;
        }













    }
}
