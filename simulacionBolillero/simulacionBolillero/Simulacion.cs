using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simulacionBolillero;

namespace simulacionBolillero
{
    public class Simulacion
    {
        public Bolillero bolillero { get; set; }
        public byte CantidadSimulaciones { get; set; }
        public ulong CantidadAciertos { get; private set; }
        public List<byte> Numero { get; set; }
        public byte jugada { get; set; }
        public ulong cantidadPorHilo { get; set; }
       
        public Simulacion()
        {

        }

        public void simularSinHilos()
        {
            this.CantidadAciertos = simularCon(bolillero, Numero, cantidadPorHilo, jugada, CantidadSimulaciones);
        }

       
        public void simularConHilos(int cantidadHilos)
        {
            List<Task<ulong>> hilos = new List<Task<ulong>>();
            List<Bolillero> Bolillero = new List<Bolillero>();
            ulong cantidadPorHilo = this.CantidadSimulaciones / (ulong)cantidadHilos;
            for (int i = 0; i < cantidadHilos; i++)
            {
                Bolillero bolilleroClon = (Bolillero)bolillero.Clone();
                Task<ulong> tarea = new Task<ulong>(() => simularCon(bolilleroClon, Numero, cantidadPorHilo, jugada, CantidadSimulaciones));
                hilos.Add(tarea);
            }

            hilos.ForEach(hilo => hilo.Start());
           
            while (!hilos.TrueForAll(hilo => hilo.IsCompleted)) ;
            
            this.CantidadAciertos = 0;
            
            hilos.ForEach(hilo => CantidadAciertos += hilo.Result);
        }

        private ulong simularCon(Bolillero bolilleroClon, List<byte> Numero, ulong cantidadPorHilo, byte jugada, object cantidadSimulaciones)
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

