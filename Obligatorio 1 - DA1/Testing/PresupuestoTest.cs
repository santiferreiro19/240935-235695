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
        public void toStringTest()
        {
            int Año = 2020;
            string Mes = "Octubre";
            Presupuesto p = new Presupuesto(Año, Mes, new Dictionary<Categoria, decimal>());
            Assert.AreEqual("Octubre 2020", p.ToString());
        }

        [TestMethod]
        public void setPresupuestoCategoriasTest()
        {
            int Año = 2020;
            string Mes = "Octubre";
            Dictionary<Categoria, decimal> d = new Dictionary<Categoria, decimal>();
            d.Add(new Categoria(), 0.00M);
            Presupuesto p = new Presupuesto(Año, Mes, new Dictionary<Categoria, decimal>());
            p.setPresupuestosCategorias(d);
            Assert.AreEqual(d, p.getPresupuestosCategorias());
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

        [ExpectedException(typeof(ExceptionPresupuestoRepetido))]
        [TestMethod]
        public void PresupuestoRepetidoTest() 
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Presupuesto p = new Presupuesto(2020, "Octubre", new Dictionary<Categoria, decimal>());
            Repositorio.AgregarPresupuesto(p);
            Manager.ValidacionAgregarPresupuesto(p);
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
            Presupuesto presupuestoNuevo = new Presupuesto(unAño, unMes, MontoCategorias);
            Manager.ValidacionAgregarPresupuesto(presupuestoNuevo);
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
            Presupuesto presupuestoNuevo = new Presupuesto(unAño, unMes, MontoCategorias);
            Manager.ValidacionAgregarPresupuesto(presupuestoNuevo);
            decimal nuevoMontoDeC1 = 15000.00M;
            Manager.ValidacionModificarPresupuesto(Repositorio.GetPresupuestos()[0], c1, nuevoMontoDeC1);
            Assert.AreEqual(Repositorio.GetPresupuestos()[0].getPresupuestosCategorias()[c1], nuevoMontoDeC1);
        }

        [TestMethod]
        public void BuscarPresupuestosPorFechaTest() {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Presupuesto p1 = new Presupuesto(2020, "March", new Dictionary<Categoria, decimal>());
            Repositorio.AgregarPresupuesto(p1);
            string Periodo = "March 2020";
            Assert.AreEqual(p1, Manager.BuscarPresupuestosPorFecha(Periodo));
        }

        [TestMethod]
        public void CargarListaDondeHuboPresupuestosTest() {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Dictionary<Categoria, decimal> MontoCategorias = Manager.CargarCategoriasPresupuesto();
            Presupuesto presupuestoNuevo = new Presupuesto(2020, "March", MontoCategorias);
            Repositorio.AgregarPresupuesto(presupuestoNuevo);
            List<string> Lista = Manager.CargarListaDondeHuboPresupuestos();
            Assert.AreEqual(1, Lista.Count);
        }
    }
}

