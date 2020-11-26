using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class PresupuestoTest
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
            Presupuesto UnPresupuesto = new Presupuesto();
            Assert.IsNotNull(UnPresupuesto);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            int Año = 2020;
            string Mes = "Octubre";
            Presupuesto UnPresupuesto = new Presupuesto(Año, Mes, new List<MontoCategoria>());
            Assert.IsNotNull(UnPresupuesto);
        }

        [TestMethod]
        public void toStringTest()
        {
            int Año = 2020;
            string Mes = "Octubre";
            Presupuesto UnPresupuesto = new Presupuesto(Año, Mes, new List<MontoCategoria>());
            Assert.AreEqual("Octubre 2020", UnPresupuesto.ToString());
        }

        [TestMethod]
        public void setPresupuestoCategoriasTest()
        {
            int Año = 2020;
            string Mes = "Octubre";
            List<MontoCategoria> ListaCategoriasMonto = new List<MontoCategoria>();
            MontoCategoria montoCategoriaTemporal = new MontoCategoria(new Categoria(), 0.00M);
            ListaCategoriasMonto.Add(montoCategoriaTemporal);
            Presupuesto UnPresupuesto = new Presupuesto(Año, Mes, new List<MontoCategoria>());
            UnPresupuesto.setPresupuestosCategorias(ListaCategoriasMonto);
            Assert.AreEqual(ListaCategoriasMonto, UnPresupuesto.getPresupuestosCategorias());
        }

        [TestMethod]
        public void RegistroDePresupuestoValidoTest()
        {
            int Año = 2021;
            string Mes = "Mayo";
            List<MontoCategoria> ListaCategoriasMonto = new List<MontoCategoria>();
            Presupuesto UnPresupuesto = new Presupuesto(Año, Mes, ListaCategoriasMonto);
            Assert.IsNotNull(UnPresupuesto);
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
            Categoria Categoria1 = new Categoria("Entretenimiento");
            Categoria Categoria2 = new Categoria("Cine");
            Repositorio.AgregarCategoria(Categoria1);
            Repositorio.AgregarCategoria(Categoria2);
            Presupuesto unPresupuesto = new Presupuesto();
            unPresupuesto.Año = 2020;
            unPresupuesto.Mes = "Ebola";
            Manager.ValidacionAgregarPresupuesto(unPresupuesto);
            Manager.CargarCategoriasPresupuesto(unPresupuesto);
            Assert.AreEqual(unPresupuesto.PresupuestosCategorias[1].Cat.Id, Categoria2.Id);
        }

        [TestMethod]
        public void AgregarUnMontoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Categoria Categoria1 = new Categoria("Entretenimiento");
            Categoria Categoria2 = new Categoria("Cine");
            Repositorio.AgregarCategoria(Categoria1);
            Repositorio.AgregarCategoria(Categoria2);
            Presupuesto unPresupuesto = new Presupuesto();
            unPresupuesto.Año = 2020;
            unPresupuesto.Mes = "Febrero";
            Manager.ValidacionAgregarPresupuesto(unPresupuesto);
            Manager.CargarCategoriasPresupuesto(unPresupuesto);
            decimal unMonto = 1200.00M;
            Manager.ValidacionAgregarUnMonto(unPresupuesto, Categoria1, unMonto);
            Assert.AreEqual(unPresupuesto.PresupuestosCategorias[0].Monto, unMonto);
        }

        [ExpectedException(typeof(ExceptionPresupuestoRepetido))]
        [TestMethod]
        public void PresupuestoRepetidoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Presupuesto UnPresupuesto = new Presupuesto(2020, "Octubre", new List<MontoCategoria>());
            Repositorio.AgregarPresupuesto(UnPresupuesto);
            Manager.ValidacionAgregarPresupuesto(UnPresupuesto);
        }

        [TestMethod]
        public void ValidacionAgregarPresupuestoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio.AgregarCategoria(UnaCategoria);
            Presupuesto unPresupuesto = new Presupuesto();
            unPresupuesto.Año = 2018;
            unPresupuesto.Mes = "Julio";
            Manager.ValidacionAgregarPresupuesto(unPresupuesto);
            Manager.CargarCategoriasPresupuesto(unPresupuesto);
            Assert.AreEqual(Repositorio.GetPresupuestos().GetAll()[0].Año, 2018);
        }

        [TestMethod]
        public void ValidacionModificacionPresupuestoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio.AgregarCategoria(UnaCategoria);
            MontoCategoria unMonto = new MontoCategoria(UnaCategoria, 0.00M);
            List<MontoCategoria> montos = new List<MontoCategoria>();
            montos.Add(unMonto);
            int unAño = 2018;
            string unMes = "Julio";
            Presupuesto presupuestoNuevo = new Presupuesto(unAño, unMes, montos);
            Manager.ValidacionAgregarPresupuesto(presupuestoNuevo);
            decimal nuevoMontoDeC1 = 15000.00M;
            Manager.ValidacionModificarPresupuesto(Repositorio.GetPresupuestos().GetAll()[0], UnaCategoria, nuevoMontoDeC1);
            Assert.AreEqual(Repositorio.GetPresupuestos().GetAll()[0].getPresupuestosCategorias()[0].Monto, nuevoMontoDeC1);
        }

        [TestMethod]
        public void BuscarPresupuestosPorFechaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Presupuesto UnPresupuesto = new Presupuesto(2020, "March", new List<MontoCategoria>());
            Repositorio.AgregarPresupuesto(UnPresupuesto);
            string Periodo = "March 2020";
            Assert.AreEqual(UnPresupuesto.Id, Manager.BuscarPresupuestosPorFecha(Periodo).Id);
        }

        [TestMethod]
        public void CargarListaDondeHuboPresupuestosTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Presupuesto presupuestoNuevo = new Presupuesto();
            presupuestoNuevo.Año = 2020;
            presupuestoNuevo.Mes = "March";
            Repositorio.AgregarPresupuesto(presupuestoNuevo);
            Manager.CargarCategoriasPresupuesto(presupuestoNuevo);
            List<string> Lista = Manager.CargarListaDondeHuboPresupuestos();
            Assert.AreEqual(1, Lista.Count);
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

