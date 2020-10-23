using System;
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
    }
}

