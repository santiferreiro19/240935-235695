using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestClass]
    public class MonedaTest
    {
        [TestMethod]
        public void MonedaValidaTest() {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYU", 1.00M);
            Assert.IsNotNull(unaMoneda);
        }

        [TestMethod]
        public void ContructorSinParametrosTest() {
            Moneda unaMoneda = new Moneda();
            Assert.AreEqual(unaMoneda.Nombre, "");
        }

        [TestMethod]
        public void ValidacionNombreValidoTest()
        {
            Moneda unaMoneda = new Moneda("Pesos", "UYU", 1.00M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionNombreMoneda(unaMoneda.Nombre);
            Assert.IsNotNull(unaMoneda);
        }

        [ExpectedException(typeof(ExceptionNombreMoneda))]
        [TestMethod]
        public void ValidacionNombreConMasDe20CaracteresTest() {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos123456789", "UYU", 1.00M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionNombreMoneda(unaMoneda.Nombre);
        }

        [ExpectedException(typeof(ExceptionNombreMoneda))]
        [TestMethod]
        public void ValidacionNombreConMenosDe3CaracteresTest()
        {
            Moneda unaMoneda = new Moneda("Pe", "UYU", 1.00M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionNombreMoneda(unaMoneda.Nombre);
        }

        [TestMethod]
        public void ValidacionSimboloValidoTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYU", 1.00M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionSimboloMoneda(unaMoneda.Simbolo);
            Assert.IsNotNull(unaMoneda);
        }

        [ExpectedException(typeof(ExceptionSimboloMoneda))]
        [TestMethod]
        public void ValidacionSimboloMenosDe1CaracterTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "", 1.00M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionSimboloMoneda(unaMoneda.Simbolo);
        }

        [ExpectedException(typeof(ExceptionSimboloMoneda))]
        [TestMethod]
        public void ValidacionSimboloMasDe3CaracteresTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", 1.00M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionSimboloMoneda(unaMoneda.Simbolo);
        }

        [TestMethod]
        public void ValidacionCotizacionValidaTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", 20.00M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionCotizacionMoneda(unaMoneda.Cotizacion);
            Assert.IsNotNull(unaMoneda);
        }

        [ExpectedException(typeof(ExceptionCotizacion))]
        [TestMethod]
        public void ValidacionCotizacionMenorACero()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", -20.00M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionCotizacionMoneda(unaMoneda.Cotizacion);
        }
        
        [ExpectedException(typeof(ExceptionCotizacion))]
        [TestMethod]
        public void ValidacionCotizacionMenos2DecimalesTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", 20.1M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionCotizacionMoneda(unaMoneda.Cotizacion);
        }

        [ExpectedException(typeof(ExceptionCotizacion))]
        [TestMethod]
        public void ValidacionCotizacionMasDe2DecimalesTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", 20.155M);
            ManagerMoneda unManager = new ManagerMoneda();
            unManager.ValidacionCotizacionMoneda(unaMoneda.Cotizacion);
        }
    }
}
