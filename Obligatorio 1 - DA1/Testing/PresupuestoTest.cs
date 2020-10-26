using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;

namespace Testing
{
    [TestClass]
    public class PresupuestoTest
    {
        [TestMethod]
        public void ConstructorSinParametrosTest()
        {
            Presupuesto p = new Presupuesto();
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            int Año = 2020;
            string Mes = "Octubre";
            Presupuesto p = new Presupuesto(Año, Mes, new Dictionary<Categoria, decimal>());
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void RegistroDePresupuestoValidoTest()
        {
            int Año = 2021;
            string Mes = "Mayo";
            Dictionary<Categoria, decimal> unPresupuestoMontos = new Dictionary<Categoria, decimal>();
            Presupuesto p = new Presupuesto(Año, Mes, unPresupuestoMontos);
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void ValidacionAñoValido()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            int Año = 2025;
            Manager.ValidacionAño(Año);
            Assert.IsNotNull(Año);
        }

        [ExpectedException(typeof(ExceptionAñoPresupuesto))]
        [TestMethod]
        public void ValidacionAñoMayorA2030()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            int Año = 2031;
            Manager.ValidacionAño(Año);
        }

        [ExpectedException(typeof(ExceptionAñoPresupuesto))]
        [TestMethod]
        public void ValidacionAñoMenorA2018()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            int Año = 2015;
            Manager.ValidacionAño(Año);
        }

        [TestMethod]
        public void ValidacionMontoValido()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            decimal unMonto = 10.00M;
            Manager.ValidacionMonto(unMonto);
            Assert.IsNotNull(unMonto);
        }

        [ExpectedException(typeof(ExceptionMontoPresupuesto))]
        [TestMethod]
        public void ValidacionMontoNegativo()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            decimal unMonto = -10.00M;
            Manager.ValidacionMonto(unMonto);
        }

        [ExpectedException(typeof(ExceptionMontoPresupuesto))]
        [TestMethod]
        public void ValidacionMontoSinDecimales()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            decimal unMonto = 1000M;
            Manager.ValidacionMonto(unMonto);
        }

        [ExpectedException(typeof(ExceptionMontoPresupuesto))]
        [TestMethod]
        public void ValidacionMontoCon1Decimal()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            decimal unMonto = 1000.0M;
            Manager.ValidacionMonto(unMonto);
        }

        [TestMethod]
        public void TransformarMontoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            decimal unMonto = 1000.0000M;
            Assert.AreEqual(1000.00M, Manager.TransformarMonto(unMonto));
        }

        [TestMethod]
        public void CargarCategoriasAPresupuestoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Categoria c1 = new Categoria("Entretenimiento");
            Categoria c2 = new Categoria("Cine");
            Repositorio.AgregarCategoria(c1);
            Repositorio.AgregarCategoria(c2);
            Dictionary<Categoria, decimal> MontoCategorias = Manager.CargarCategoriasPresupuesto();
            Assert.AreEqual(MontoCategorias.ElementAt(1).Key, c2);
        }

        [TestMethod]
        public void AgregarUnMontoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Categoria c1 = new Categoria("Entretenimiento");
            Categoria c2 = new Categoria("Cine");
            Repositorio.AgregarCategoria(c1);
            Repositorio.AgregarCategoria(c2);
            Dictionary<Categoria, decimal> MontoCategorias = Manager.CargarCategoriasPresupuesto();
            decimal unMonto = 1200.00M;
            Manager.ValidacionAgregarUnMonto(MontoCategorias, c1, unMonto);
            Assert.AreEqual(MontoCategorias[c1], unMonto);
        }

        [TestMethod]
        public void ValidacionAgregarPresupuestoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Categoria c1 = new Categoria("Entretenimiento");
            Repositorio.AgregarCategoria(c1);
            Dictionary<Categoria, decimal> MontoCategorias = Manager.CargarCategoriasPresupuesto();
            int unAño = 2018;
            string unMes = "Julio";
            Manager.ValidacionAgregarPresupuesto(unAño, unMes, MontoCategorias);
            Assert.AreEqual(Repositorio.GetPresupuestos()[0].Año, unAño);
        }

        [TestMethod]
        public void ValidacionModificacionPresupuestoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Categoria c1 = new Categoria("Entretenimiento");
            Repositorio.AgregarCategoria(c1);
            Dictionary<Categoria, decimal> MontoCategorias = Manager.CargarCategoriasPresupuesto();
            int unAño = 2018;
            string unMes = "Julio";
            Manager.ValidacionAgregarPresupuesto(unAño, unMes, MontoCategorias);
            decimal nuevoMontoDeC1 = 15000.00M;
            Manager.ValidacionModificarPresupuesto(Repositorio.GetPresupuestos()[0], c1, nuevoMontoDeC1);
            Assert.AreEqual(Repositorio.GetPresupuestos()[0].PresupuestosCategorias[c1], nuevoMontoDeC1);
        }
    }
}

