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
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom);
            Assert.IsNotNull(UnGasto);
        }

        [TestMethod]
        public void CreacionDeGastoValidoTest()
        {
            Categoria UnaCategoria = new Categoria("Teatro");
            DateTime FechaRandom = new DateTime(2019, 04, 05);
            Gasto UnaGasto = new Gasto("Entradas al teatro", 1.34M, UnaCategoria, FechaRandom);
            Assert.IsNotNull(UnaGasto);
        }

        [TestMethod]
        public void toStringTest()
        {
            Categoria UnaCategoria = new Categoria("Teatro");
            DateTime FechaRandom = new DateTime(2019, 04, 05);
            Gasto UnaGasto = new Gasto("Entradas al teatro", 1.34M, UnaCategoria, FechaRandom);
            Assert.AreEqual("Descripcion: Entradas al teatro Monto: 1.34 Categoria: Teatro Fecha: 05/04/2019", UnaGasto.ToString());
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
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1));
            unManager.ValidacionAgregarGasto(UnGasto);
            Assert.AreEqual(UnGasto.Descripcion, Repositorio.GetGastos()[0].Descripcion);
        }

        [TestMethod]
        public void ValidacionEliminarGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria UnaCategoria = new Categoria();
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1));
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
            String nuevaDescripcion = "Nueva descrp";
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1));
            unManager.ValidacionAgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Nueva descrp", 100.00M, UnaCategoria, new DateTime(2018, 1, 1));
            unManager.ValidacionModificacionGasto(UnGasto, GastoModificado);
            Assert.AreEqual(UnGasto.Descripcion, nuevaDescripcion);
        }

        [TestMethod]
        public void ValidacionModificarMontoGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria UnaCategoria = new Categoria();
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1));
            unManager.ValidacionAgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Descripcion x", 102.00M, UnaCategoria, new DateTime(2018, 1, 1));
            unManager.ValidacionModificacionGasto(UnGasto, GastoModificado);
            Assert.AreEqual((decimal)102.00M, UnGasto.Monto);
        }

        [TestMethod]
        public void ValidacionModificarFechaGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria UnaCategoria = new Categoria();
            Gasto UnGasto = new Gasto("Descripcion x", 100.00M, UnaCategoria, new DateTime(2018, 1, 1));
            unManager.ValidacionAgregarGasto(UnGasto);
            DateTime nuevaFecha = new DateTime(2019, 1, 1);
            Gasto GastoModificado = new Gasto("Descripcion x", 100.00M, UnaCategoria, nuevaFecha);
            unManager.ValidacionModificacionGasto(UnGasto, GastoModificado);
            Assert.AreEqual(nuevaFecha, UnGasto.Fecha);
        }

        [TestMethod]
        public void ValidacionBusquedaCategoriaGastoTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            List<string> Lista = new List<string> { "Cine", "Carreras", "Teatro", "Autos" };
            Categoria UnaCategoria = new Categoria("CategoriaConAutos", Lista);
            String DescripcionGasto = "Autos";
            unRepositorio.AgregarCategoria(UnaCategoria);
            Assert.AreEqual(UnaCategoria, unManager.ValidacionBusquedaCategorias(DescripcionGasto));
        }
        [TestMethod]
        public void ValidacionBusquedaCategoriaMultiplesPalabrasClaveGastoTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            List<string> Lista = new List<string> { "Cine", "Carreras", "Teatro", "Autos" };
            Categoria UnaCategoria = new Categoria("CategoriaConAutos", Lista);
            String DescripcionGasto = "Autos de Carreras";
            unRepositorio.AgregarCategoria(UnaCategoria);
            Assert.AreEqual(UnaCategoria, unManager.ValidacionBusquedaCategorias(DescripcionGasto));
        }

        [TestMethod]
        public void ValidacionModificacionCategoriaGasto()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            DateTime FechaRandom = new DateTime(2020, 1, 1);
            Categoria categoria = new Categoria("Entretenimiento");
            Gasto UnGasto = new Gasto("Entradas al cine", 10.00M, categoria, FechaRandom);
            Repo.AgregarGasto(UnGasto);
            Categoria categoriaNueva = new Categoria("Formula 1");
            Gasto GastoModificado = new Gasto("Entradas al cine", 10.00M, categoriaNueva, FechaRandom);
            unManager.ValidacionModificacionGasto(UnGasto, GastoModificado);
            Assert.AreEqual("Formula 1", Repo.GetGastos()[0].Categoria.Nombre);
        }

        [TestMethod]
        public void CargarFechasDondeHuboGastosTest()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            Gasto Gasto1 = new Gasto("Gasto1", 100.00M, new Categoria("Cine"), new DateTime(2019, 1, 1));
            Gasto Gasto2 = new Gasto("Gasto2", 100.00M, new Categoria("Entretenimiento"), new DateTime(2019, 1, 20));
            Gasto Gasto3 = new Gasto("Gasto3", 100.00M, new Categoria("Autos"), new DateTime(2020, 1, 14));
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
            Gasto Gasto1 = new Gasto("Gasto1", 100.00M, new Categoria("Cine"), new DateTime(2019, 1, 1));
            Gasto Gasto2 = new Gasto("Gasto2", 100.00M, new Categoria("Entretenimiento"), new DateTime(2019, 1, 1));
            Gasto Gasto3 = new Gasto("Gasto3", 100.00M, new Categoria("Autos"), new DateTime(2018, 1, 2));
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
            Gasto Gasto1 = new Gasto("Gasto1", 100.00M, new Categoria("Cine"), new DateTime(2019, 1, 1));
            Gasto Gasto2 = new Gasto("Gasto2", 100.00M, new Categoria("Entretenimiento"), new DateTime(2019, 1, 20));
            Gasto Gasto3 = new Gasto("Gasto3", 100.00M, new Categoria("Autos"), new DateTime(2019, 1, 12));
            ListParaSumarMontos.Add(Gasto1);
            ListParaSumarMontos.Add(Gasto2);
            ListParaSumarMontos.Add(Gasto3);
            Assert.AreEqual(300.00M, decimal.Parse(unManager.SumaDeGastosParaFecha(ListParaSumarMontos)));
        }

        [TestMethod]
        public void ObtenerGastosPorFechaCategoriaTest()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Gasto UnGasto = new Gasto("Gasto1", 100.00M, UnaCategoria, new DateTime(2019, 1, 1));
            string FechaFormateada = UnGasto.Fecha.ToString("MMMM yyyy");
            Repo.AgregarGasto(UnGasto);
            List<Gasto> GastosRetorno = unManager.ObtenerGastosPorFechaCategoria(UnaCategoria, FechaFormateada);
            Assert.AreEqual(UnGasto, GastosRetorno[0]);
        }
    }
}

