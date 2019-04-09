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
            simulacion = new Simulacion();
            simulacion.bolillero = bolillero;
            simulacion.CantidadSimulaciones = 1000;
            simulacion.Numero = 1;
            simulacion.SimularSinHilos();

           
           
        }
    }
}
