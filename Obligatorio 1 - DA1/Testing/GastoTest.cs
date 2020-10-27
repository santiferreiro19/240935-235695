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
            Gasto g = new Gasto();
            Assert.IsNotNull(g);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            Categoria c = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Gasto g = new Gasto("Entradas al cine", DecimalRandom, c, FechaRandom);
            Assert.IsNotNull(g);
        }

        [TestMethod]
        public void CreacionDeGastoValidoTest()
        {
            Categoria c = new Categoria("Teatro");
            DateTime FechaRandom = new DateTime(2019, 04, 05);
            Gasto g = new Gasto("Entradas al teatro", 1.34M, c, FechaRandom);
            Assert.IsNotNull(g);
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
            Categoria c = new Categoria();
            Gasto g = new Gasto("Descripcion x", 100.00M, c, new DateTime(2018, 1, 1));
            unManager.ValidacionAgregarGasto(g);
            Assert.AreEqual(g.Descripcion, Repositorio.GetGastos()[0].Descripcion);
        }

        [TestMethod]
        public void ValidacionEliminarGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria c = new Categoria();
            Gasto g = new Gasto("Descripcion x", 100.00M, c, new DateTime(2018, 1, 1));
            unManager.ValidacionAgregarGasto(g);
            unManager.ValidacionEliminarGasto(g);
            Assert.IsFalse(Repositorio.GetGastos().Contains(g));
        }

        [TestMethod]
        public void ValidacionModificarDescripcionGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria c = new Categoria();
            String nuevaDescripcion = "Nueva descrp";
            Gasto g = new Gasto("Descripcion x", 100.00M, c, new DateTime(2018, 1, 1));
            unManager.ValidacionAgregarGasto(g);
            unManager.ValidacionModificacionDescripcionGasto(g, nuevaDescripcion);
            Assert.AreEqual(g.Descripcion, nuevaDescripcion);
        }

        [TestMethod]
        public void ValidacionModificarMontoGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria c = new Categoria();
            Gasto g = new Gasto("Descripcion x", 100.00M, c, new DateTime(2018, 1, 1));
            unManager.ValidacionAgregarGasto(g);
            unManager.ValidacionModificacionMontoGasto(g, 102.00M);
            Assert.AreEqual((decimal)102.00M, g.Monto);
        }

        [TestMethod]
        public void ValidacionModificarFechaGastoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repositorio);
            Categoria c = new Categoria();
            Gasto g = new Gasto("Descripcion x", 100.00M, c, new DateTime(2018, 1, 1));
            unManager.ValidacionAgregarGasto(g);
            DateTime nuevaFecha = new DateTime(2019, 1, 1);
            unManager.ValidacionModificacionFechaGasto(g, nuevaFecha);
            Assert.AreEqual(nuevaFecha, g.Fecha);
        }

        [TestMethod]
        public void ValidacionBusquedaCategoriaGastoTest()
        {
            Repositorio unRepositorio = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(unRepositorio);
            List<string> Lista = new List<string> { "Cine", "Carreras", "Teatro", "Autos" };
            Categoria c = new Categoria("CategoriaConAutos", Lista);
            String DescripcionGasto = "Autos";
            unRepositorio.AgregarCategoria(c);
            Assert.AreEqual(c, unManager.ValidacionBusquedaCategorias(DescripcionGasto));
        }

        [TestMethod]
        public void ValidacionModificacionCategoriaGasto()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            DateTime FechaRandom = new DateTime(2020, 1, 1);
            Categoria categoria = new Categoria("Entretenimiento");
            Gasto gasto = new Gasto("Entradas al cine", 10.00M, categoria, FechaRandom);
            Repo.AgregarGasto(gasto);
            Categoria categoriaNueva = new Categoria("Formula 1");
            unManager.ValidacionModificacionCategoriaGasto(gasto, categoriaNueva);
            Assert.AreEqual("Formula 1", Repo.GetGastos()[0].unaCategoria.Nombre);
        }

        [TestMethod]
        public void CargarFechasDondeHuboGastosTest()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            Gasto g1 = new Gasto("Gasto1", 100.00M, new Categoria("Cine"), new DateTime(2019, 1, 1));
            Gasto g2 = new Gasto("Gasto2", 100.00M, new Categoria("Entretenimiento"), new DateTime(2019, 1, 20));
            Gasto g3 = new Gasto("Gasto3", 100.00M, new Categoria("Autos"), new DateTime(2020, 1, 14));
            Repo.AgregarGasto(g1);
            Repo.AgregarGasto(g2);
            Repo.AgregarGasto(g3);
            List<string> Lista = unManager.CargarFechasDondeHuboGastos();
            Assert.AreEqual(Lista[1], "January 2020");
        }

        [TestMethod]
        public void FiltrarGastosPorFechaTest()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            string FechaAFiltrar = new DateTime(2018, 1, 2).ToString("MMMM yyyy");
            Gasto g1 = new Gasto("Gasto1", 100.00M, new Categoria("Cine"), new DateTime(2019, 1, 1));
            Gasto g2 = new Gasto("Gasto2", 100.00M, new Categoria("Entretenimiento"), new DateTime(2019, 1, 1));
            Gasto g3 = new Gasto("Gasto3", 100.00M, new Categoria("Autos"), new DateTime(2018, 1, 2));
            Repo.AgregarGasto(g1);
            Repo.AgregarGasto(g2);
            Repo.AgregarGasto(g3);
            List<Gasto> ListaFiltrada = unManager.FiltrarGastosPorFecha(FechaAFiltrar);
            Assert.AreEqual(1, ListaFiltrada.Count);
        }

        [TestMethod]
        public void SumaDeGastosParaFechaTest()
        {
            Repositorio Repo = new Repositorio();
            ManagerGasto unManager = new ManagerGasto(Repo);
            List<Gasto> ListParaSumarMontos = new List<Gasto>();
            Gasto g1 = new Gasto("Gasto1", 100.00M, new Categoria("Cine"), new DateTime(2019, 1, 1));
            Gasto g2 = new Gasto("Gasto2", 100.00M, new Categoria("Entretenimiento"), new DateTime(2019, 1, 20));
            Gasto g3 = new Gasto("Gasto3", 100.00M, new Categoria("Autos"), new DateTime(2019, 1, 12));
            ListParaSumarMontos.Add(g1);
            ListParaSumarMontos.Add(g2);
            ListParaSumarMontos.Add(g3);
            Assert.AreEqual(300.00M, decimal.Parse(unManager.SumaDeGastosParaFecha(ListParaSumarMontos)));
        }
    }
}

