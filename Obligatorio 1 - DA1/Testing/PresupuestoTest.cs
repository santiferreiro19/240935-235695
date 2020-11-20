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
            Presupuesto UnPresupuesto = new Presupuesto(Año, Mes, new Dictionary<Categoria, decimal>());
            Assert.IsNotNull(UnPresupuesto);
        }

        [TestMethod]
        public void toStringTest()
        {
            int Año = 2020;
            string Mes = "Octubre";
            Presupuesto UnPresupuesto = new Presupuesto(Año, Mes, new Dictionary<Categoria, decimal>());
            Assert.AreEqual("Octubre 2020", UnPresupuesto.ToString());
        }

        [TestMethod]
        public void setPresupuestoCategoriasTest()
        {
            int Año = 2020;
            string Mes = "Octubre";
            Dictionary<Categoria, decimal> DiccionarioCategMonto = new Dictionary<Categoria, decimal>();
            DiccionarioCategMonto.Add(new Categoria(), 0.00M);
            Presupuesto UnPresupuesto = new Presupuesto(Año, Mes, new Dictionary<Categoria, decimal>());
            UnPresupuesto.setPresupuestosCategorias(DiccionarioCategMonto);
            Assert.AreEqual(DiccionarioCategMonto, UnPresupuesto.getPresupuestosCategorias());
        }

        [TestMethod]
        public void RegistroDePresupuestoValidoTest()
        {
            int Año = 2021;
            string Mes = "Mayo";
            Dictionary<Categoria, decimal> unPresupuestoMontos = new Dictionary<Categoria, decimal>();
            Presupuesto UnPresupuesto = new Presupuesto(Año, Mes, unPresupuestoMontos);
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
            Dictionary<Categoria, decimal> MontoCategorias = Manager.CargarCategoriasPresupuesto();
            Assert.AreEqual(MontoCategorias.ElementAt(1).Key.Id, Categoria2.Id);
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
            Dictionary<Categoria, decimal> MontoCategorias = Manager.CargarCategoriasPresupuesto();
            decimal unMonto = 1200.00M;
            Manager.ValidacionAgregarUnMonto(MontoCategorias, Categoria1, unMonto);
            Assert.AreEqual(MontoCategorias[Categoria1], unMonto);
        }

        [ExpectedException(typeof(ExceptionPresupuestoRepetido))]
        [TestMethod]
        public void PresupuestoRepetidoTest() 
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Presupuesto UnPresupuesto = new Presupuesto(2020, "Octubre", new Dictionary<Categoria, decimal>());
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
            Dictionary<Categoria, decimal> MontoCategorias = Manager.CargarCategoriasPresupuesto();
            int unAño = 2018;
            string unMes = "Julio";
            Presupuesto presupuestoNuevo = new Presupuesto(unAño, unMes, MontoCategorias);
            Manager.ValidacionAgregarPresupuesto(presupuestoNuevo);
            Assert.AreEqual(Repositorio.GetPresupuestos().GetAll()[0].Año, unAño);
        }

        [TestMethod]
        public void ValidacionModificacionPresupuestoTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio.AgregarCategoria(UnaCategoria);
            Dictionary<Categoria, decimal> MontoCategorias = Manager.CargarCategoriasPresupuesto();
            int unAño = 2018;
            string unMes = "Julio";
            Presupuesto presupuestoNuevo = new Presupuesto(unAño, unMes, MontoCategorias);
            Manager.ValidacionAgregarPresupuesto(presupuestoNuevo);
            decimal nuevoMontoDeC1 = 15000.00M;
            Manager.ValidacionModificarPresupuesto(Repositorio.GetPresupuestos().GetAll()[0], UnaCategoria, nuevoMontoDeC1);
            Assert.AreEqual(Repositorio.GetPresupuestos().GetAll()[0].getPresupuestosCategorias()[UnaCategoria], nuevoMontoDeC1);
        }

        [TestMethod]
        public void BuscarPresupuestosPorFechaTest() {
            Repositorio Repositorio = new Repositorio();
            ManagerPresupuesto Manager = new ManagerPresupuesto(Repositorio);
            Presupuesto UnPresupuesto = new Presupuesto(2020, "March", new Dictionary<Categoria, decimal>());
            Repositorio.AgregarPresupuesto(UnPresupuesto);
            string Periodo = "March 2020";
            Assert.AreEqual(UnPresupuesto.Id, Manager.BuscarPresupuestosPorFecha(Periodo).Id);
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

        [TestCleanup]
        public void CleanUp()
        {

            using (ContextoFinanzas db = new ContextoFinanzas())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM PRESUPUESTOES;");
                db.Database.ExecuteSqlCommand("DELETE FROM GASTOES;");
                db.Database.ExecuteSqlCommand("DELETE FROM PALABRACLAVES;");
                db.Database.ExecuteSqlCommand("DELETE FROM CATEGORIAS;");
                db.Database.ExecuteSqlCommand("DELETE FROM MONEDAS;");

            }
        }
    }
}

