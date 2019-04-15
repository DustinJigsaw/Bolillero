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
        public byte cantidadSimulaciones { get; set; }
        public long cantidadAciertos { get; private set; }


        public Simulacion()
        {

        }
        public long simularSinHilos(List<byte> jugada, long cantJugadas)
        {
            return bolillero.Jugar(jugada, cantJugadas);
        }

        public long simularConHilos(List<byte> jugada, long cantJugada, int cantHilos)
        {
            var hilos = new List<Task<long>>();
            var bolilleros = new List<Bolillero>();
            long cantPorHilo = this.cantidadSimulaciones / (long)cantHilos;

            asignarHilos(jugada, cantHilos, hilos, bolilleros, cantPorHilo);

            hilos.ForEach(hilo => hilo.Start());

            Task<long>.WaitAll(hilos.ToArray());

            return hilos.Sum(task => task.Result);
        }

       private void asignarHilos(List<byte> jugada, int cantHilos, List<Task<long>> hilos, List<global::simulacionBolillero.Bolillero> bolilleros, long cantPorHilo)
        {
            for (int i = 0; i < cantHilos; i++)
            {
                Bolillero bolilleroClon = (Bolillero)bolillero.Clone();
                bolilleros.Add(bolilleroClon);
                var tarea = new Task<long>(() => bolilleroClon.Jugar(jugada, cantPorHilo));
                hilos.Add(tarea);
            }
        }


    }
}






 
