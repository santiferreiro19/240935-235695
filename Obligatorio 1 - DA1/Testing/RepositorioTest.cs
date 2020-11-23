using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
using Persistencia;

namespace Testing
{
    [TestClass]
    public class RepositorioTest
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
        public void ConstructorTest()
        {
            Repositorio Repo = new Repositorio();
            Assert.IsNotNull(Repo);
        }

        [TestMethod]
        public void AgregarCategoriaTest()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio Repo = new Repositorio();
            Repo.AgregarCategoria(UnaCategoria);
            Assert.AreEqual(UnaCategoria.Id, Repo.GetCategorias().GetAll()[0].Id);
        }

        [TestMethod]
        public void ModificarNombreCategoriaTest()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio Repo = new Repositorio();
            Repo.AgregarCategoria(UnaCategoria);
            Repo.ModificarNombreCategoria(UnaCategoria, "Futbol");
            Categoria categoriaModificadaBD = Repo.GetCategorias().Get(UnaCategoria.Id);
            Assert.AreEqual(categoriaModificadaBD.Nombre, "Futbol");
        }

        [TestMethod]
        public void AgregarPalabraClaveTest()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio Repo = new Repositorio();
            Repo.AgregarCategoria(UnaCategoria);
            Repo.AgregarPalabraClave(UnaCategoria, "Cine");
            PalabraClave palabra = new PalabraClave("Cine");
            bool ok = false;
            Categoria CategoriaEnDB = Repo.GetCategorias().Get(UnaCategoria.Id);
            foreach (PalabraClave palabras in CategoriaEnDB.ListaPalabras)
            {
                if (palabras.Palabra == palabra.Palabra)
                {
                    ok = true;
                }
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void ModificarPalabraClaveTest()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio Repo = new Repositorio();
            Repo.AgregarCategoria(UnaCategoria);
            Repo.AgregarPalabraClave(UnaCategoria, "Cine");
            Repo.ModificarPalabraClave(UnaCategoria, "Carreras", "Cine");
            Categoria CategoriaEnDB = Repo.GetCategorias().Get(UnaCategoria.Id);
            Assert.AreEqual(CategoriaEnDB.ListaPalabras[0].Palabra, "Carreras");
        }

        [TestMethod]
        public void BorrarPalabraClaveTest()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio Repo = new Repositorio();
            Repo.AgregarCategoria(UnaCategoria);
            Repo.AgregarPalabraClave(UnaCategoria, "Cine");
            Repo.EliminarPalabraClave("Cine");
            Assert.AreEqual(UnaCategoria.ListaPalabras.Count, 0);
        }

        [TestMethod]
        public void AgregarGastoTest()
        {
            Categoria UnaCategoria = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom, NuevaMoneda);
            Repositorio Repo = new Repositorio();
            Repo.AgregarMoneda(NuevaMoneda);
            Repo.AgregarCategoria(UnaCategoria);
            Repo.AgregarGasto(UnGasto);
            Assert.IsTrue(Repo.GetGastos().Contains(UnGasto));
        }

        [TestMethod]
        public void EliminarGastoTest()
        {
            Categoria UnaCategoria = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom, NuevaMoneda);
            Repositorio Repo = new Repositorio();
            Repo.AgregarMoneda(NuevaMoneda);
            Repo.AgregarCategoria(UnaCategoria);
            Repo.AgregarGasto(UnGasto);
            Repo.EliminarGasto(UnGasto);
            Assert.IsFalse(Repo.GetGastos().Contains(UnGasto));
        }

        [TestMethod]
        public void ModificarDescripcionGastoTest()
        {
            Repositorio Repo = new Repositorio();
            Categoria UnaCategoria = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom, NuevaMoneda);
            String nuevaDescripcion = "Hola";
            Repo.AgregarMoneda(NuevaMoneda);
            Repo.AgregarCategoria(UnaCategoria);
            Repo.AgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Hola", DecimalRandom, UnaCategoria, FechaRandom, NuevaMoneda);
            Repo.ModificarGasto(UnGasto, GastoModificado);
            Gasto GastoModificadaBD = Repo.GetGastos().Get(UnGasto.Id);
            Assert.AreEqual(nuevaDescripcion, GastoModificadaBD.Descripcion);
        }

        [TestMethod]
        public void ModificarMontoGastoTest()
        {
            Repositorio Repo = new Repositorio();
            Categoria UnaCategoria = new Categoria("Cine");
            Repo.AgregarCategoria(UnaCategoria);
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repo.AgregarMoneda(NuevaMoneda);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom, NuevaMoneda);
            decimal nuevoMonto = 102.22M;
            Repo.AgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Entradas al cine", nuevoMonto, UnaCategoria, FechaRandom, NuevaMoneda);
            Repo.ModificarGasto(UnGasto, GastoModificado);
            Gasto GastoModificadaBD = Repo.GetGastos().Get(UnGasto.Id);
            Assert.AreEqual(nuevoMonto, GastoModificadaBD.Monto);
        }

        [TestMethod]
        public void ModificarFechaGastoTest()
        {
            Repositorio Repo = new Repositorio();
            Categoria UnaCategoria = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaAnterior = new DateTime(2018, 02, 01);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repo.AgregarMoneda(NuevaMoneda);
            Repo.AgregarCategoria(UnaCategoria);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaAnterior, NuevaMoneda);
            DateTime nuevaFecha = new DateTime(2019, 1, 1);
            Repo.AgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, nuevaFecha, NuevaMoneda);
            Repo.ModificarGasto(UnGasto, GastoModificado);
            Gasto GastoModificadaBD = Repo.GetGastos().Get(UnGasto.Id);
            Assert.AreEqual(nuevaFecha, GastoModificadaBD.Fecha);
        }

        [TestMethod]
        public void BusquedaCategoriasTest()
        {
            Repositorio Repo = new Repositorio();
            String[] array = { "Cine" };
            PalabraClave palabra1 = new PalabraClave("Cine");
            PalabraClave palabra2 = new PalabraClave("Carreras");
            PalabraClave palabra3 = new PalabraClave("Teatro");
            PalabraClave palabra4 = new PalabraClave("Caballos");
            List<PalabraClave> Lista = new List<PalabraClave> { palabra1, palabra2, palabra3, palabra4 };
            Categoria UnaCategoria = new Categoria("Entretenimiento", Lista);
            Repo.AgregarCategoria(UnaCategoria);
            Assert.IsTrue(UnaCategoria.Nombre == Repo.BusquedaCategorias(array).Nombre);
        }

        [TestMethod]
        public void ModificacionCategoriaGastoTest()
        {
            Repositorio Repo = new Repositorio();
            DateTime FechaRandom = new DateTime(2020, 1, 1);
            Categoria categoria = new Categoria("Entretenimiento");
            Repo.AgregarCategoria(categoria);
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repo.AgregarMoneda(NuevaMoneda);
            Gasto gasto = new Gasto("Entradas al cine", 10.00M, categoria, FechaRandom, NuevaMoneda);
            Repo.AgregarGasto(gasto);
            Categoria categorianueva = new Categoria("Formula 1");
            Repo.AgregarCategoria(categorianueva);
            Repo.ModificacionCategoriaGasto(gasto, categorianueva);
            Assert.AreEqual("Formula 1", Repo.GetGastos().GetAll()[0].Categoria.Nombre);
        }

        [TestMethod]
        public void AgregarPresupuestoTest()
        {
            Presupuesto Unpresupuesto = new Presupuesto(2018, "Octubre", new List<MontoCategoria>());
            Repositorio Repo = new Repositorio();
            Repo.AgregarPresupuesto(Unpresupuesto);
            Assert.AreEqual(Unpresupuesto.Id, Repo.GetPresupuestos().GetAll()[0].Id);
        }

        [TestMethod]
        public void ModificarMontoPresupuestoTest()
        {
            List<MontoCategoria> montos = new List<MontoCategoria>();
            Categoria UnaCategoria = new Categoria();
            MontoCategoria unMonto = new MontoCategoria(UnaCategoria, 100.00M);
            montos.Add(unMonto);
            Presupuesto Unpresupuesto = new Presupuesto(2018, "Octubre", montos);
            Repositorio Repo = new Repositorio();
            Repo.AgregarPresupuesto(Unpresupuesto);
            Repo.ModificarMontoPresupuesto(Unpresupuesto, UnaCategoria, 120.00M);
            Assert.AreEqual(Repo.GetPresupuestos().GetAll()[0].getPresupuestosCategorias()[0].Monto, 120.00M);
        }

        [TestMethod]
        public void ActualizarCategoriasEnPresupuestosTest()
        {
            Categoria Categoria1 = new Categoria();
            List <MontoCategoria> montos = new List<MontoCategoria>();
            MontoCategoria unMonto = new MontoCategoria(Categoria1, 100.00M);
            montos.Add(unMonto);
            Presupuesto Unpresupuesto = new Presupuesto(2018, "Octubre", montos);
            Repositorio Repo = new Repositorio();
            Repo.AgregarPresupuesto(Unpresupuesto);
            Categoria Categoria2 = new Categoria("Categoria2");
            Repo.AgregarCategoria(Categoria2);
            Assert.AreEqual(Repo.GetPresupuestos().GetAll()[0].getPresupuestosCategorias()[1].Cat.Id,Categoria2.Id);
        }

        [TestMethod]
        public void AgregarMonedaTest()
        {
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repositorio Repo = new Repositorio();
            Repo.AgregarMoneda(NuevaMoneda);
            Assert.IsTrue(Repo.GetMonedas().Contains(NuevaMoneda));
        }

        [TestMethod]
        public void EliminarMonedaTest()
        {
            Moneda NuevaMoneda = new Moneda("Dolar", "USD", 43.00M);
            Repositorio Repo = new Repositorio();
            Repo.AgregarMoneda(NuevaMoneda);
            Repo.EliminarMoneda(NuevaMoneda);
            Assert.IsFalse(Repo.GetMonedas().Contains(NuevaMoneda));
        }

        [TestMethod]
        public void ModificarMonedaTest()
        {
            Repositorio unRepositorio = new Repositorio();
            Moneda MonedaVieja = new Moneda("Dolar", "USD", 43.00M);
            Moneda MonedaModificada = new Moneda("Pesos", "UUS", 66.00M);
            unRepositorio.AgregarMoneda(MonedaVieja);
            unRepositorio.ModificarMoneda(MonedaVieja, MonedaModificada);
            Moneda GastoModificadaBD = unRepositorio.GetMonedas().Get(MonedaVieja.Id);
            Assert.AreEqual(66.00M, GastoModificadaBD.Cotizacion);
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
