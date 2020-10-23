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
    public class CategoriaTest
    {
   
        [TestMethod]
        public void ConstructorSinParametrosTest()
        {
            Categoria c = new Categoria();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            String Nombre1 = "Entretenimiento";
            String Nombre2 = "Entretenimiento";
            List<string> Lista = new List<string> { "Cine", "Carreras", "Teatro", "Caballos" };
            Categoria c1 = new Categoria(Nombre1, Lista);
            Categoria c2 = new Categoria(Nombre2);
            Assert.IsNotNull(c1);
            Assert.IsNotNull(c2);
        }

        [TestMethod]
        public void CreacionDeCategoriaValida()
        {
            List<string> Lista = new List<string>
            {"Cine","Carreras","Teatro","Caballos"};
            Categoria c = new Categoria("Entretenimiento", Lista);
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void CreacionDeCategoriaValidaSinPalabrasClave()
        {
            Categoria c = new Categoria("Entretenimiento");
            Assert.IsNotNull(c);
        }

        [ExpectedException(typeof(ExceptionNombreCategoria))]
        [TestMethod]
        public void ValidacionNombreConMasDe15CaracteresTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String Nombre = "Entretenimientos para Niños";
            Manager.ValidarNombreCategoria(Nombre);
        }

        [ExpectedException(typeof(ExceptionNombreCategoria))]
        [TestMethod]
        public void ValidacionNombreConMenosDe3CaracteresTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String Nombre = "EP";
            Manager.ValidarNombreCategoria(Nombre);
        }

        [TestMethod]
        public void ValidacionAgregarCategoriaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            Categoria c = new Categoria("Cine");
            Manager.ValidacionAgregarCategoria(c);
            Assert.AreEqual(c.Nombre, Repositorio.GetCategorias()[0].Nombre);
        }
        [TestMethod]
        public void ModificacionDeNombreCategoriaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String NuevoNombre = "Cine";
            String NombreAnterior = "Entretenimiento";
            Categoria c = new Categoria(NombreAnterior);
            Manager.ValidacionAgregarCategoria(c);
            Manager.ValidacionModificarNombreCategoria(c, NuevoNombre);
            Assert.AreEqual(c.Nombre, NuevoNombre);
        }

        [ExpectedException(typeof(ExceptionNombreCategoria))]
        [TestMethod]
        public void ModificacionDeNombreConMasDe15CaracteresTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String NombreAnterior = "Cine";
            String NuevoNombre = "Entretenimientos";
            Categoria c = new Categoria(NombreAnterior);
            Manager.ValidacionAgregarCategoria(c);
            Manager.ValidacionModificarNombreCategoria(c, NuevoNombre);

        }

        [ExpectedException(typeof(ExceptionNombreCategoria))]
        [TestMethod]
        public void ModificacionDeNombreConMenosDe3CaracteresTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String NuevoNombre = "PE";
            String NombreAnterior = "Entretenimiento";
            Categoria c = new Categoria(NombreAnterior);
            Manager.ValidacionAgregarCategoria(c);
            Manager.ValidacionModificarNombreCategoria(c, NuevoNombre);
        }
       
        [TestMethod]
        public void AgregarUnaPalabraClaveCuandoHayLugarTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String nuevaPalabra = "Cine Mudo";
            List<string> Lista = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            Categoria c = new Categoria("Cine", Lista);
            Manager.ValidacionAgregarCategoria(c);
            Manager.ValidacionAgregarUnaPalabraClave(c, nuevaPalabra);
            Assert.AreEqual(c.ListaPalabras[5], nuevaPalabra);
        }

        [ExpectedException(typeof(ExceptionPalabraClaveRepetida))]
        [TestMethod]
        public void AgregarPalabraClaveRepetidaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String Repetida = "Cine";
            List<string> Lista = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            Categoria c = new Categoria("Cine", Lista);
            Manager.ValidacionAgregarCategoria(c);
            Manager.ValidacionAgregarUnaPalabraClave(c, Repetida);
        }


        [ExpectedException(typeof(ExceptionListaPalabrasClaveLlena))]
        [TestMethod]
        public void AgregarUnaPalabraClaveCuandoNoHayLugarTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String nuevaPalabra = "Cine Mudo";
            List<string> Lista = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6",
                "Palabra7","Palabra8","Palabra9","Palabra10"};
            Categoria c = new Categoria("Cine", Lista);
            Manager.ValidacionAgregarCategoria(c);
            Manager.ValidacionAgregarUnaPalabraClave(c, nuevaPalabra);
        }

        [TestMethod]
        public void ModificacionDeUnaPalabraClaveTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            List<string> Lista = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            Categoria c = new Categoria("Cine", Lista);
            Manager.ValidacionAgregarCategoria(c);
            Manager.ValidacionModificacionDePalabraClave(c, "Futbol", "Bar");
            Assert.AreEqual(Lista[4], "Bar");
        }

        [ExpectedException(typeof(ExceptionListaPalabrasClaveLlena))]
        [TestMethod]
        public void ValidacionListaPalabrasLlenaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            List<string> Lista = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6", "Palabra7","Palabra8","Palabra9","Palabra10"};
            Categoria c = new Categoria("Cine", Lista);
            Manager.ListaPalabrasClaveLLena(c);
        }

        [ExpectedException(typeof(ExceptionPalabraClaveRepetida))]
        [TestMethod]
        public void ValidacionPalabraClaveRepetidaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            List<string> Lista = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6", "Palabra7","Palabra8"};
            Categoria c = new Categoria("Entretenimiento", Lista);
            String Repetida = "Palabra3";
            Manager.ValidacionAgregarCategoria(c);
            Manager.ValidarPalabraClaveRepetida(Repetida);
        }
    }
}
