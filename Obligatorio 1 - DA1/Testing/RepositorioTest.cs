using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
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
        public void AgregarCategoriaTest() {
            Categoria c = new Categoria("Entretenimiento");
            Repositorio repo = new Repositorio();
            repo.AgregarCategoria(c);
            Assert.IsTrue(repo.GetCategorias().Contains(c));
        }

        [TestMethod]
        public void ModificarNombreCategoriaTest() {
            Categoria c = new Categoria("Entretenimiento");
            Repositorio repo = new Repositorio();
            repo.AgregarCategoria(c);
            repo.ModificarNombreCategoria(c, "Futbol");
            Assert.AreEqual(c.Nombre, "Futbol");
        }

        [TestMethod]
        public void AgregarPalabraClaveTest() {
            Categoria c = new Categoria("Entretenimiento");
            Repositorio repo = new Repositorio();
            repo.AgregarCategoria(c);
            repo.AgregarPalabraClave(c,"Cine");
            Assert.IsTrue(c.ListaPalabras.Contains("Cine"));
        }

        [TestMethod]
        public void ModificarPalabraClaveTest() {
            Categoria c = new Categoria("Entretenimiento");
            Repositorio repo = new Repositorio();
            repo.AgregarCategoria(c);
            repo.AgregarPalabraClave(c, "Cine");
            repo.ModificarPalabraClave(c, "Carreras", "Cine");
            Assert.AreEqual(c.ListaPalabras[0], "Carreras");
        }
    }
}
