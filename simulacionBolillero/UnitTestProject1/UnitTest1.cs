using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using simulacionBolillero;
using System.Collections.Generic;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Bolillero bolillero;
        Simulacion simulacion;
       

        [TestMethod]
        public void testSimulacionConHilos()
        {
            Bolillero bolillero = new Bolillero(1);
            Simulacion simulacion = new Simulacion();
            var jugada = new List<byte>(){4, 6, 8};

            simulacion.bolillero = bolillero;
            simulacion.simularConHilos(jugada, 4, 4);

            Assert.AreEqual(3, (int)simulacion.cantidadAciertos, 10);         
        }

        [TestMethod]
        public void testSimulacionSinHilos()
        {
            Bolillero bolillero = new Bolillero(1);
            Simulacion simulacion = new Simulacion();
            var jugada = new List<byte>() { 1 };

            simulacion.bolillero = bolillero;
            simulacion.simularSinHilos(jugada, 1000000);

            Assert.AreEqual(1000000, (int)simulacion.cantidadAciertos); 
            
        }


       [TestMethod]
       public void TestBolillero()
        {
            bolillero = new Bolillero(1);
            var jugada = new List<byte>() { 1 };
            Assert.IsTrue(bolillero.jugar(jugada));
            Assert.AreEqual(500, bolillero.Jugar(jugada, 500));
            
        }

       
    }
}
