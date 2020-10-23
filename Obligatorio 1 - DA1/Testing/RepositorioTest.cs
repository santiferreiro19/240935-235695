using System;
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
            Repositorio repo = new Repositorio();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void AgregarCategoriaTest()
        {
            Categoria c = new Categoria("Entretenimiento");
            Repositorio repo = new Repositorio();
            repo.AgregarCategoria(c);
            Assert.IsTrue(repo.GetCategorias().Contains(c));
        }

        [TestMethod]
        public void ModificarNombreCategoriaTest()
        {
            Categoria c = new Categoria("Entretenimiento");
            Repositorio repo = new Repositorio();
            repo.AgregarCategoria(c);
            repo.ModificarNombreCategoria(c, "Futbol");
            Assert.AreEqual(c.Nombre, "Futbol");
        }

        [TestMethod]
        public void AgregarPalabraClaveTest()
        {
            Categoria c = new Categoria("Entretenimiento");
            Repositorio repo = new Repositorio();
            repo.AgregarCategoria(c);
            repo.AgregarPalabraClave(c, "Cine");
            Assert.IsTrue(c.ListaPalabras.Contains("Cine"));
        }

        [TestMethod]
        public void ModificarPalabraClaveTest()
        {
            Categoria c = new Categoria("Entretenimiento");
            Repositorio repo = new Repositorio();
            repo.AgregarCategoria(c);
            repo.AgregarPalabraClave(c, "Cine");
            repo.ModificarPalabraClave(c, "Carreras", "Cine");
            Assert.AreEqual(c.ListaPalabras[0], "Carreras");
        }

        [TestMethod]
        public void BorrarPalabraClaveTest()
        {
            Categoria c = new Categoria("Entretenimiento");
            Repositorio repo = new Repositorio();
            repo.AgregarCategoria(c);
            repo.AgregarPalabraClave(c, "Cine");
            repo.EliminarPalabraClave("Cine");
            Assert.AreEqual(c.ListaPalabras.Count, 0);
        }

        [TestMethod]
        public void AgregarGastoTest()
        {
            Categoria c = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Gasto g = new Gasto("Entradas al cine", DecimalRandom, c, FechaRandom);
            Repositorio repo = new Repositorio();
            repo.AgregarGasto(g);
            Assert.IsTrue(repo.GetGastos().Contains(g));
        }

        [TestMethod]
        public void EliminarGastoTest()
        {
            Categoria c = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Gasto g = new Gasto("Entradas al cine", DecimalRandom, c, FechaRandom);
            Repositorio repo = new Repositorio();
            repo.AgregarGasto(g);
            repo.EliminarGasto(g);
            Assert.IsFalse(repo.GetGastos().Contains(g));
        }

        [TestMethod]
        public void ModificarDescripcionGastoTest() {
            Repositorio repo = new Repositorio();
            Categoria c = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Gasto g = new Gasto("Entradas al cine", DecimalRandom, c, FechaRandom);
            String nuevaDescripcion = "Hola";
            repo.AgregarGasto(g);
            repo.ModificarDescripcion(nuevaDescripcion, g);
            Assert.AreEqual(nuevaDescripcion, g.Descripcion);
        }

        [TestMethod]
        public void ModificarMontoGastoTest() {
            Repositorio repo = new Repositorio();
            Categoria c = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaRandom = new DateTime(2018, 02, 01);
            Gasto g = new Gasto("Entradas al cine", DecimalRandom, c, FechaRandom);
            decimal nuevoMonto = 102.22M;
            repo.AgregarGasto(g);
            repo.ModificarMontoGasto(g, nuevoMonto);
            Assert.AreEqual(nuevoMonto, g.Monto);
        }

        [TestMethod]
        public void ModificarFechaGastoTest()
        {
            Repositorio repo = new Repositorio();
            Categoria c = new Categoria("Cine");
            decimal DecimalRandom = 1.22M;
            DateTime FechaAnterior = new DateTime(2018, 02, 01);
            Gasto g = new Gasto("Entradas al cine", DecimalRandom, c, FechaAnterior);
            DateTime nuevaFecha = new DateTime(2019, 1, 1);
            repo.AgregarGasto(g);
            repo.ModificarFechaGasto(g, nuevaFecha);
            Assert.AreEqual(nuevaFecha, g.Fecha);
        }
    }
}
