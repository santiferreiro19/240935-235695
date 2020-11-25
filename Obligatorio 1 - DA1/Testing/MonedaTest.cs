using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;

namespace Testing
{
    [TestClass]
    public class MonedaTest
    {
        [TestInitialize]
        public void Initialize()
        {
            using (ContextoFinanzas db = new ContextoFinanzas())
            {
                db.Database.Initialize(true);
            }

        }

        [TestMethod]
        public void MonedaValidaTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYU", 1.00M);
            Assert.IsNotNull(unaMoneda);
        }

        [TestMethod]
        public void ContructorSinParametrosTest()
        {
            Moneda unaMoneda = new Moneda();
            Assert.AreEqual(unaMoneda.Nombre, "");
        }

        [TestMethod]
        public void ValidacionNombreValidoTest()
        {
            Moneda unaMoneda = new Moneda("Pesos", "UYU", 1.00M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionNombreMoneda(unaMoneda.Nombre);
            Assert.IsNotNull(unaMoneda);
        }

        [TestMethod]
        public void toStringTest()
        {
            Moneda unaMoneda = new Moneda("Pesos", "UYU", 1.00M);
            Assert.AreEqual(unaMoneda.ToString(), "UYU");
        }

        [ExpectedException(typeof(ExceptionNombreMoneda))]
        [TestMethod]
        public void ValidacionNombreConMasDe20CaracteresTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos123456789", "UYU", 1.00M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionNombreMoneda(unaMoneda.Nombre);
        }

        [ExpectedException(typeof(ExceptionNombreMoneda))]
        [TestMethod]
        public void ValidacionNombreConMenosDe3CaracteresTest()
        {
            Moneda unaMoneda = new Moneda("Pe", "UYU", 1.00M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionNombreMoneda(unaMoneda.Nombre);
        }

        [TestMethod]
        public void ValidacionSimboloValidoTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYU", 1.00M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionSimboloMoneda(unaMoneda.Simbolo);
            Assert.IsNotNull(unaMoneda);
        }

        [ExpectedException(typeof(ExceptionSimboloMoneda))]
        [TestMethod]
        public void ValidacionSimboloMenosDe1CaracterTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "", 1.00M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionSimboloMoneda(unaMoneda.Simbolo);
        }

        [ExpectedException(typeof(ExceptionSimboloMoneda))]
        [TestMethod]
        public void ValidacionSimboloMasDe3CaracteresTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", 1.00M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionSimboloMoneda(unaMoneda.Simbolo);
        }

        [TestMethod]
        public void ValidacionCotizacionValidaTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", 20.00M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionCotizacionMoneda(unaMoneda.Cotizacion);
            Assert.IsNotNull(unaMoneda);
        }

        [ExpectedException(typeof(ExceptionCotizacion))]
        [TestMethod]
        public void ValidacionCotizacionMenorACero()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", -20.00M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionCotizacionMoneda(unaMoneda.Cotizacion);
        }

        [ExpectedException(typeof(ExceptionCotizacion))]
        [TestMethod]
        public void ValidacionCotizacionMenos2DecimalesTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", 20.1M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionCotizacionMoneda(unaMoneda.Cotizacion);
        }

        [ExpectedException(typeof(ExceptionCotizacion))]
        [TestMethod]
        public void ValidacionCotizacionMasDe2DecimalesTest()
        {
            Moneda unaMoneda = new Moneda("Pesos Uruguayos", "UYUS", 20.155M);
            Repositorio unRepositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(unRepositorio);
            unManager.ValidacionCotizacionMoneda(unaMoneda.Cotizacion);
        }

        [TestMethod]
        public void ValidacionAgregarMonedaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(Repositorio);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            unManager.ValidacionAgregarMoneda(NuevaMoneda);
            Assert.AreEqual(NuevaMoneda.Nombre, Repositorio.GetMonedas().GetAll()[1].Nombre);
        }

        [TestMethod]
        public void ValidacionEliminarMonedaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(Repositorio);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            unManager.ValidacionAgregarMoneda(NuevaMoneda);
            unManager.ValidacionEliminarMoneda(NuevaMoneda);
            Assert.IsFalse(Repositorio.GetMonedas().Contains(NuevaMoneda));
        }

        [TestMethod]
        public void ValidacionModificarNombreMonedaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(Repositorio);
            Moneda MonedaVieja = new Moneda("Dolar", "USD", 43.00M);
            unManager.ValidacionAgregarMoneda(MonedaVieja);
            Moneda MonedaNueva = new Moneda("Libra", "$$", 43.00M);
            unManager.ValidacionModificacionMoneda(MonedaVieja, MonedaNueva);
            Moneda MonedaDbVieja = Repositorio.GetMonedas().Get(MonedaVieja.Id);
            Assert.AreEqual(MonedaDbVieja.Nombre, "Libra");
        }

        [TestMethod]
        public void ValidacionModificarSimboloMonedaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(Repositorio);
            Moneda MonedaVieja = new Moneda("Dolar", "USD", 43.00M);
            unManager.ValidacionAgregarMoneda(MonedaVieja);
            Moneda MonedaNueva = new Moneda("Libra", "$$", 43.00M);
            unManager.ValidacionModificacionMoneda(MonedaVieja, MonedaNueva);
            Moneda MonedaDbVieja = Repositorio.GetMonedas().Get(MonedaVieja.Id);
            Assert.AreEqual(MonedaDbVieja.Simbolo, "$$");
        }

        [TestMethod]
        public void ValidacionModificarCotizacionMonedaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerMoneda unManager = new ManagerMoneda(Repositorio);
            Moneda MonedaVieja = new Moneda("Dolar", "USD", 43.00M);
            unManager.ValidacionAgregarMoneda(MonedaVieja);
            Moneda MonedaNueva = new Moneda("Libra", "$$", 55.00M);
            unManager.ValidacionModificacionMoneda(MonedaVieja, MonedaNueva);
            Moneda MonedaDbVieja = Repositorio.GetMonedas().Get(MonedaVieja.Id);
            Assert.AreEqual(55.00M, MonedaDbVieja.Cotizacion);
        }

        [TestCleanup]
        public void CleanUp()
        {

            using (ContextoFinanzas db = new ContextoFinanzas())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM MONTOCATEGORIAS");
                db.Database.ExecuteSqlCommand("DELETE FROM PRESUPUESTOES;");
                db.Database.ExecuteSqlCommand("DELETE FROM GASTOES;");
                db.Database.ExecuteSqlCommand("DELETE FROM PALABRACLAVES;");
                db.Database.ExecuteSqlCommand("DELETE FROM CATEGORIAS;");
                db.Database.ExecuteSqlCommand("DELETE FROM MONEDAS;");

            }
        }
    }
}
