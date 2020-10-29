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
            Assert.IsTrue(Repo.GetCategorias().Contains(UnaCategoria));
        }

        [TestMethod]
        public void ModificarNombreCategoriaTest()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio Repo = new Repositorio();
            Repo.AgregarCategoria(UnaCategoria);
            Repo.ModificarNombreCategoria(UnaCategoria, "Futbol");
            Assert.AreEqual(UnaCategoria.Nombre, "Futbol");
        }

        [TestMethod]
        public void AgregarPalabraClaveTest()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio Repo = new Repositorio();
            Repo.AgregarCategoria(UnaCategoria);
            Repo.AgregarPalabraClave(UnaCategoria, "Cine");
            Assert.IsTrue(UnaCategoria.ListaPalabras.Contains("Cine"));
        }

        [TestMethod]
        public void ModificarPalabraClaveTest()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Repositorio Repo = new Repositorio();
            Repo.AgregarCategoria(UnaCategoria);
            Repo.AgregarPalabraClave(UnaCategoria, "Cine");
            Repo.ModificarPalabraClave(UnaCategoria, "Carreras", "Cine");
            Assert.AreEqual(UnaCategoria.ListaPalabras[0], "Carreras");
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
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom);
            Repositorio Repo = new Repositorio();
            Repo.AgregarGasto(UnGasto);
            Assert.IsTrue(Repo.GetGastos().Contains(UnGasto));
        }

        [TestMethod]
        public void EliminarGastoTest()
        {
            Categoria UnaCategoria = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom);
            Repositorio Repo = new Repositorio();
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
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom);
            String nuevaDescripcion = "Hola";
            Repo.AgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Hola", DecimalRandom, UnaCategoria, FechaRandom);
            Repo.ModificarGasto(UnGasto, GastoModificado);
            Assert.AreEqual(nuevaDescripcion, UnGasto.Descripcion);
        }

        [TestMethod]
        public void ModificarMontoGastoTest()
        {
            Repositorio Repo = new Repositorio();
            Categoria UnaCategoria = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaRandom);
            decimal nuevoMonto = 102.22M;
            Repo.AgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Entradas al cine", nuevoMonto, UnaCategoria, FechaRandom);
            Repo.ModificarGasto(UnGasto, GastoModificado);
            Assert.AreEqual(nuevoMonto, UnGasto.Monto);
        }

        [TestMethod]
        public void ModificarFechaGastoTest()
        {
            Repositorio Repo = new Repositorio();
            Categoria UnaCategoria = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaAnterior = new DateTime(2018, 02, 01);
            Gasto UnGasto = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, FechaAnterior);
            DateTime nuevaFecha = new DateTime(2019, 1, 1);
            Repo.AgregarGasto(UnGasto);
            Gasto GastoModificado = new Gasto("Entradas al cine", DecimalRandom, UnaCategoria, nuevaFecha);
            Repo.ModificarGasto(UnGasto, GastoModificado);
            Assert.AreEqual(nuevaFecha, UnGasto.Fecha);
        }

        [TestMethod]
        public void BusquedaCategoriasTest()
        {
            Repositorio Repo = new Repositorio();
            String[] array = { "Cine" };
            List<string> Lista = new List<string> { "Cine", "Carreras", "Teatro", "Caballos" };
            Categoria UnaCategoria = new Categoria("Entretenimiento", Lista);
            Repo.AgregarCategoria(UnaCategoria);
            Assert.AreEqual(UnaCategoria, Repo.BusquedaCategorias(array));
        }

        [TestMethod]
        public void ModificacionCategoriaGastoTest()
        {
            Repositorio Repo = new Repositorio();
            DateTime FechaRandom = new DateTime(2020, 1, 1);
            Categoria categoria = new Categoria("Entretenimiento");
            Gasto gasto = new Gasto("Entradas al cine", 10.00M, categoria, FechaRandom);
            Repo.AgregarGasto(gasto);
            Categoria categorianueva = new Categoria("Formula 1");
            Repo.ModificacionCategoriaGasto(gasto, categorianueva);
            Assert.AreEqual("Formula 1", Repo.GetGastos()[0].Categoria.Nombre);
        }

        [TestMethod]
        public void AgregarPresupuestoTest()
        {
            Presupuesto Unpresupuesto = new Presupuesto(2018, "Octubre", new Dictionary<Categoria, decimal>());
            Repositorio Repo = new Repositorio();
            Repo.AgregarPresupuesto(Unpresupuesto);
            Assert.IsTrue(Repo.GetPresupuestos().Contains(Unpresupuesto));
        }

        [TestMethod]
        public void ModificarMontoPresupuestoTest()
        {
            Dictionary<Categoria, decimal> Diccionario = new Dictionary<Categoria, decimal>();
            Categoria UnaCategoria = new Categoria();
            Diccionario.Add(UnaCategoria, 100.00M);
            Presupuesto Unpresupuesto = new Presupuesto(2018, "Octubre", Diccionario);
            Repositorio Repo = new Repositorio();
            Repo.AgregarPresupuesto(Unpresupuesto);
            Repo.ModificarMontoPresupuesto(Unpresupuesto, UnaCategoria, 120.00M);
            Assert.AreEqual(Repo.GetPresupuestos()[0].getPresupuestosCategorias()[UnaCategoria], 120.00M);
        }

        [TestMethod]
        public void ActualizarCategoriasEnPresupuestosTest()
        {
            Dictionary<Categoria, decimal> Diccionario = new Dictionary<Categoria, decimal>();
            Categoria Categoria1 = new Categoria();
            Diccionario.Add(Categoria1, 100.00M);
            Presupuesto Unpresupuesto = new Presupuesto(2018, "Octubre", Diccionario);
            Repositorio Repo = new Repositorio();
            Repo.AgregarPresupuesto(Unpresupuesto);
            Categoria Categoria2 = new Categoria("Categoria2");
            Repo.AgregarCategoria(Categoria2);
            Assert.IsTrue(Repo.GetPresupuestos()[0].getPresupuestosCategorias().ContainsKey(Categoria1));
        }
    }
}
