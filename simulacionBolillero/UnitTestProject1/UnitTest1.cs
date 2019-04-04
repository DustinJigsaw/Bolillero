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
            bolillero = new Bolillero(10, 1);

            simulacion = new Simulacion();
           
           
        }
    }
}
