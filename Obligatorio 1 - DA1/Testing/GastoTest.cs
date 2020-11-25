using System;
using System.Collections.Generic;
using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;

namespace Testing
{
    [TestClass]
    public class GastoTest
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
        public void ConstructorSinParametrosTest()
        {
            Gasto UnGasto = new Gasto();
            Assert.IsNotNull(UnGasto);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            Categoria UnaCategoria = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom, NuevaMoneda, 12.00M);
            Assert.IsNotNull(UnGasto);
        }

        [TestMethod]
        public void CreacionDeGastoValidoTest()
        {
            Categoria UnaCategoria = new Categoria("Teatro");
            DateTime FechaRandom = new DateTime(2019, 04, 05);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Gasto UnaGasto = new Gasto("Entradas al teatro", 1.34M, UnaCategoria, FechaRandom, NuevaMoneda, 12.00M);
            Assert.IsNotNull(UnaGasto);
        }

        [TestMethod]
        public void toStringTest()
        {
            Categoria UnaCategoria = new Categoria("Teatro");
            DateTime FechaRandom = new DateTime(2019, 04, 05);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Gasto UnaGasto = new Gasto("Entradas al teatro", 1.34M, UnaCategoria, FechaRandom, NuevaMoneda, 12.00M);
            Assert.AreEqual("Descripcion: Entradas al teatro Monto: 1.34 Categoria: Teatro Fecha: 4/5/2019 Moneda: USD", UnaGasto.ToString());
        }

        [TestMethod]
        public void ValidacionDeDescripcionValidaTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            String unaDescripcion = "Entradas para niños";
            unManager.ValidacionDescripcionGasto(unaDescripcion);
            Assert.IsNotNull(unaDescripcion);
        }

        [ExpectedException(typeof(ExceptionDescripcionGasto))]
        [TestMethod]
        public void ValidacionDeDescripcionConMasDe20CaracteresTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            String unaDescripcion = "Entradas para niños con 8 años";
            unManager.ValidacionDescripcionGasto(unaDescripcion);
        }

        [ExpectedException(typeof(ExceptionDescripcionGasto))]
        [TestMethod]
        public void ValidacionDeDescripcionConMenosDe3CaracteresTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            String unaDescripcion = "ET";
            unManager.ValidacionDescripcionGasto(unaDescripcion);
        }

        [TestMethod]
        public void TransformarMontoTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            decimal unMonto = 1000;
            unMonto = unManager.TransformarMonto(unMonto);
            Assert.AreEqual(unMonto, (decimal)1000.00);
        }

        [ExpectedException(typeof(ExceptionMonto))]
        [TestMethod]
        public void MontoInvalidoTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            decimal unMonto = -1.44M;
            unManager.ValidarMonto(unMonto);
        }

        [TestMethod]
        public void MontoValidoTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            decimal unMonto = 1.44M;
            unManager.ValidarMonto(unMonto);
            Assert.IsNotNull(unMonto);
        }

        [TestMethod]
        public void ValidacionFechaValidaTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            DateTime FechaValida = new DateTime(2028, 01, 01);
            unManager.ValidacionFechaGasto(FechaValida);
            Assert.IsNotNull(FechaValida);
        }

        [ExpectedException(typeof(ExceptionFechaGasto))]
        [TestMethod]
        public void ValidacionFechaMenorTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            DateTime FechaInvalida = new DateTime(2017, 01, 01);
            unManager.ValidacionFechaGasto(FechaInvalida);
        }

        [ExpectedException(typeof(ExceptionFechaGasto))]
        [TestMethod]
        public void ValidacionFechaMayorTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            DateTime FechaInvalida = new DateTime(2031, 01, 01);
            unManager.ValidacionFechaGasto(FechaInvalida);
        }

        [TestMethod]
        public void ValidacionAgregarGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria UnaCategoria = new Categoria();
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repositorio.AgregarMoneda(NuevaMoneda);
            Repositorio.AgregarCategoria(UnaCategoria);
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1), NuevaMoneda, 12.00M);
            unManager.ValidacionAgregarGasto(UnGasto);
            Assert.AreEqual(UnGasto.Descripcion, Repositorio.GetGastos().GetAll()[0].Descripcion);
        }

        [TestMethod]
        public void ValidacionEliminarGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria UnaCategoria = new Categoria();
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repositorio.AgregarMoneda(NuevaMoneda);
            Repositorio.AgregarCategoria(UnaCategoria);
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1), NuevaMoneda, 12.00M);
            unManager.ValidacionAgregarGasto(UnGasto);
            unManager.ValidacionEliminarGasto(UnGasto);
            Assert.IsFalse(Repositorio.GetGastos().Contains(UnGasto));
        }

        [TestMethod]
        public void ValidacionModificarDescripcionGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria UnaCategoria = new Categoria();
            Repositorio.AgregarCategoria(UnaCategoria);
            String nuevaDescripcion = "Nueva descrp";
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repositorio.AgregarMoneda(NuevaMoneda);
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1), NuevaMoneda, 12.00M);
            unManager.ValidacionAgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Nueva descrp", 100.00M, UnaCategoria, new DateTime(2018, 1, 1), NuevaMoneda, 12.00M);
            unManager.ValidacionModificacionGasto(UnGasto, GastoModificado);
            Gasto gastoValidar = Repositorio.GetGastos().Get(GastoModificado.Id);
            Assert.AreEqual(gastoValidar.Descripcion, nuevaDescripcion);
        }

        [TestMethod]
        public void ValidacionModificarMontoGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria UnaCategoria = new Categoria();
            Repositorio.AgregarCategoria(UnaCategoria);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repositorio.AgregarMoneda(NuevaMoneda);
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1), NuevaMoneda, 12.00M);
            unManager.ValidacionAgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Descripcion x", 102.00M, UnaCategoria, new DateTime(2018, 1, 1), NuevaMoneda, 12.00M);
            unManager.ValidacionModificacionGasto(UnGasto, GastoModificado);
            Gasto gastoValidar = Repositorio.GetGastos().Get(GastoModificado.Id);
            Assert.AreEqual((decimal)102.00M, gastoValidar.Monto);
        }

        [TestMethod]
        public void ValidacionModificarFechaGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria UnaCategoria = new Categoria();
            Repositorio.AgregarCategoria(UnaCategoria);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repositorio.AgregarMoneda(NuevaMoneda);
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1), NuevaMoneda, 12.00M);
            unManager.ValidacionAgregarGasto(UnGasto);
            DateTime nuevaFecha = new DateTime(2019, 1, 1);
            Gasto GastoModificado = new Gasto("Descripcion x", 100.00M, UnaCategoria, nuevaFecha, NuevaMoneda, 12.00M);
            unManager.ValidacionModificacionGasto(UnGasto, GastoModificado);
            Gasto gastoValidar = Repositorio.GetGastos().Get(GastoModificado.Id);
            Assert.AreEqual(nuevaFecha, gastoValidar.Fecha);
        }

        [TestMethod]
        public void ValidacionBusquedaCategoriaGastoTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            PalabraClave palabraTemporal1 = new PalabraClave("Cine Mudo");
            PalabraClave palabraTemporal2 = new PalabraClave("Carreras");
            PalabraClave palabraTemporal3 = new PalabraClave("Teatro");
            PalabraClave palabraTemporal4 = new PalabraClave("Autos");
            List<PalabraClave> Lista = new List<PalabraClave> { palabraTemporal1, palabraTemporal2, palabraTemporal3, palabraTemporal4 };
            Categoria UnaCategoria = new Categoria("CategoriaAuto", Lista);
            String DescripcionGasto = "Autos";
            unRepositorio.AgregarCategoria(UnaCategoria);
            Assert.IsTrue(UnaCategoria.Id == unManager.ValidacionBusquedaCategorias(DescripcionGasto)[0].Id);
        }
        [TestMethod]
        public void ValidacionBusquedaCategoriaMultiplesPalabrasClaveGastoTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            PalabraClave palabraTemporal1 = new PalabraClave("Cines");
            PalabraClave palabraTemporal2 = new PalabraClave("Carreras");
            PalabraClave palabraTemporal3 = new PalabraClave("Teatro");
            PalabraClave palabraTemporal4 = new PalabraClave("Autos");
            List<PalabraClave> Lista = new List<PalabraClave> { palabraTemporal1, palabraTemporal2, palabraTemporal3, palabraTemporal4 };
            Categoria UnaCategoria = new Categoria("CategoriaAutos", Lista);
            String DescripcionGasto = "Autos de Carreras";
            unRepositorio.AgregarCategoria(UnaCategoria);
            Assert.IsTrue(UnaCategoria.Id == unManager.ValidacionBusquedaCategorias(DescripcionGasto)[0].Id);
        }

        [TestMethod]
        public void ValidacionModificacionCategoriaGasto()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            DateTime FechaRandom = new DateTime(2020, 1, 1);
            Categoria categoria = new Categoria("Entretenimiento");
            Repo.AgregarCategoria(categoria);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repo.AgregarMoneda(NuevaMoneda);
            Gasto UnGasto = new Gasto("Entradas al cine", 10.00M, categoria, FechaRandom, NuevaMoneda, 12.00M);
            Repo.AgregarGasto(UnGasto);
            Categoria categoriaNueva = new Categoria("Formula 1");
            Repo.AgregarCategoria(categoriaNueva);
            Gasto GastoModificado = new Gasto("Entradas al cine", 10.00M, categoriaNueva, FechaRandom, NuevaMoneda, 12.00M);
            unManager.ValidacionModificacionGasto(UnGasto, GastoModificado);
            Categoria categoriaValidar = Repo.GetGastos().Get(GastoModificado.Id).Categoria;
            Assert.AreEqual("Formula 1", categoriaValidar.Nombre);
        }

        [TestMethod]
        public void CargarFechasDondeHuboGastosTest()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repo.AgregarMoneda(NuevaMoneda);
            Categoria cat1 = new Categoria("Cine");
            Categoria cat2 = new Categoria("Entretenimiento");
            Categoria cat3 = new Categoria("CiAutosne");
            Repo.AgregarCategoria(cat1);
            Repo.AgregarCategoria(cat2);
            Repo.AgregarCategoria(cat3);
            Gasto Gasto1 = new Gasto("Gasto1", 100.00M, cat1, new DateTime(2019, 1, 1), NuevaMoneda, 12.00M);
            Gasto Gasto2 = new Gasto("Gasto2", 100.00M, cat2, new DateTime(2019, 1, 20), NuevaMoneda, 12.00M);
            Gasto Gasto3 = new Gasto("Gasto3", 100.00M, cat3, new DateTime(2020, 1, 14), NuevaMoneda, 12.00M);
            Repo.AgregarGasto(Gasto1);
            Repo.AgregarGasto(Gasto2);
            Repo.AgregarGasto(Gasto3);
            List<string> Lista = unManager.CargarFechasDondeHuboGastos();
            Assert.AreEqual(Lista[1], "January 2020");
        }

        [TestMethod]
        public void FiltrarGastosPorFechaTest()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            string FechaAFiltrar = new DateTime(2018, 1, 2).ToString("MMMM yyyy");
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repo.AgregarMoneda(NuevaMoneda);
            Categoria cat1 = new Categoria("Cine");
            Categoria cat2 = new Categoria("Entretenimiento");
            Categoria cat3 = new Categoria("CiAutosne");
            Repo.AgregarCategoria(cat1);
            Repo.AgregarCategoria(cat2);
            Repo.AgregarCategoria(cat3);
            Gasto Gasto1 = new Gasto("Gasto1", 100.00M, cat1, new DateTime(2019, 1, 1), NuevaMoneda, 12.00M);
            Gasto Gasto2 = new Gasto("Gasto2", 100.00M, cat2, new DateTime(2019, 1, 1), NuevaMoneda, 12.00M);
            Gasto Gasto3 = new Gasto("Gasto3", 100.00M, cat3, new DateTime(2018, 1, 2), NuevaMoneda, 12.00M);
            Repo.AgregarGasto(Gasto1);
            Repo.AgregarGasto(Gasto2);
            Repo.AgregarGasto(Gasto3);
            List<Gasto> ListaFiltrada = unManager.FiltrarGastosPorFecha(FechaAFiltrar);
            Assert.AreEqual(1, ListaFiltrada.Count);
        }

        [TestMethod]
        public void SumaDeGastosParaFechaTest()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            List<Gasto> ListParaSumarMontos = new List<Gasto>();
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repo.AgregarMoneda(NuevaMoneda);
            Categoria cat1 = new Categoria("Cine");
            Categoria cat2 = new Categoria("Entretenimiento");
            Categoria cat3 = new Categoria("CiAutosne");
            Repo.AgregarCategoria(cat1);
            Repo.AgregarCategoria(cat2);
            Repo.AgregarCategoria(cat3);
            Gasto Gasto1 = new Gasto("Gasto1", 100.00M, cat1, new DateTime(2019, 1, 1), NuevaMoneda, 12.00M);
            Gasto Gasto2 = new Gasto("Gasto2", 100.00M, cat2, new DateTime(2019, 1, 20), NuevaMoneda, 12.00M);
            Gasto Gasto3 = new Gasto("Gasto3", 100.00M, cat3, new DateTime(2019, 1, 12), NuevaMoneda, 12.00M);
            ListParaSumarMontos.Add(Gasto1);
            ListParaSumarMontos.Add(Gasto2);
            ListParaSumarMontos.Add(Gasto3);
            decimal resultado = decimal.Parse(unManager.SumaDeGastosParaFecha(ListParaSumarMontos));
            Assert.AreEqual(3600.00M, Math.Round(resultado, 2));
        }

        [TestMethod]
        public void ObtenerGastosPorFechaCategoriaTest()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repo.AgregarCategoria(UnaCategoria);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repo.AgregarMoneda(NuevaMoneda);
            Gasto UnGasto = new Gasto("Gasto1", 100.00M, UnaCategoria, new DateTime(2019, 1, 1), NuevaMoneda, 12.00M);
            string FechaFormateada = UnGasto.Fecha.ToString("MMMM yyyy");
            Repo.AgregarGasto(UnGasto);
            List<Gasto> GastosRetorno = unManager.ObtenerGastosPorFechaCategoria(UnaCategoria, FechaFormateada);
            Assert.IsTrue(UnGasto.Id == GastosRetorno[0].Id);
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

