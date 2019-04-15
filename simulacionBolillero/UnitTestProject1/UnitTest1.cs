using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using simulacionBolillero;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Bolillero bolillero;
        Simulacion simulacion;

        [TestMethod]
        public void TestMethod1()
        {

            bolillero = new Bolillero();

            simulacion = new Simulacion();
            simulacion.bolillero = bolillero;
            simulacion.cantidadSimulaciones = 100;
            bolillero.cantidadBolilla = 120;
            
          

            Assert.AreEqual(100, (int)simulacion.cantidadAciertos);
           
        }
    }
}
