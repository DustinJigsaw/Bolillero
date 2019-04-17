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
        public void testSimulacion()
        {

            
            var jugada = new List<byte>(){4, 6, 8};
            simulacion = new Simulacion();
            simulacion.bolillero = bolillero;
            simulacion.cantidadSimulaciones = 255;
           
            simulacion.simularSinHilos(jugada, 1000);
          

            Assert.AreEqual(255, (int)simulacion.cantidadAciertos);
           
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
