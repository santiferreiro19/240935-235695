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
            Categoria UnaCategoria = new Categoria();
            Assert.IsNotNull(UnaCategoria);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            String Nombre1 = "Entretenimiento";
            String Nombre2 = "Entretenimiento";
            List<string> ListaPalabras = new List<string> { "Cine", "Carreras", "Teatro", "Caballos" };
            Categoria Categoria1 = new Categoria(Nombre1, ListaPalabras);
            Categoria Categoria2 = new Categoria(Nombre2);
            Assert.IsNotNull(Categoria1);
            Assert.IsNotNull(Categoria2);
        }

        [TestMethod]
        public void toStringTest()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Assert.AreEqual("Entretenimiento", UnaCategoria.ToString()) ;
        }

        [TestMethod]
        public void CreacionDeCategoriaValida()
        {
            List<string> ListaPalabras = new List<string>
            {"Cine","Carreras","Teatro","Caballos"};
            Categoria UnaCategoria = new Categoria("Entretenimiento", ListaPalabras);
            Assert.IsNotNull(UnaCategoria);
        }

        [TestMethod]
        public void CreacionDeCategoriaValidaSinPalabrasClave()
        {
            Categoria UnaCategoria = new Categoria("Entretenimiento");
            Assert.IsNotNull(UnaCategoria);
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

        [ExpectedException(typeof(ExceptionNombreCategoriaRepetido))]
        [TestMethod]
        public void ValidacionNombreCategoriaRepetido() 
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String Nombre = "EP";
            Repositorio.AgregarCategoria(new Categoria(Nombre));
            Manager.ValidarNombreCategoria(Nombre);
        }

        [TestMethod]
        public void ValidacionAgregarCategoriaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            Categoria UnaCategoria = new Categoria("Cine");
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Assert.AreEqual(UnaCategoria.Nombre, Repositorio.GetCategorias()[0].Nombre);
        }

        [TestMethod]
        public void ModificacionDeNombreCategoriaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String NuevoNombre = "Cine";
            String NombreAnterior = "Entretenimiento";
            Categoria UnaCategoria = new Categoria(NombreAnterior);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionModificarNombreCategoria(UnaCategoria, NuevoNombre);
            Assert.AreEqual(UnaCategoria.Nombre, NuevoNombre);
        }

        [ExpectedException(typeof(ExceptionNombreCategoria))]
        [TestMethod]
        public void ModificacionDeNombreConMasDe15CaracteresTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String NombreAnterior = "Cine";
            String NuevoNombre = "Entretenimientos";
            Categoria UnaCategoria = new Categoria(NombreAnterior);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionModificarNombreCategoria(UnaCategoria, NuevoNombre);

        }

        [ExpectedException(typeof(ExceptionNombreCategoria))]
        [TestMethod]
        public void ModificacionDeNombreConMenosDe3CaracteresTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String NuevoNombre = "PE";
            String NombreAnterior = "Entretenimiento";
            Categoria UnaCategoria = new Categoria(NombreAnterior);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionModificarNombreCategoria(UnaCategoria, NuevoNombre);
        }
       
        [TestMethod]
        public void AgregarUnaPalabraClaveCuandoHayLugarTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String nuevaPalabra = "Cine Mudo";
            List<string> ListaPalabras = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionAgregarUnaPalabraClave(UnaCategoria, nuevaPalabra);
            Assert.AreEqual(UnaCategoria.ListaPalabras[5], nuevaPalabra);
        }

        [ExpectedException(typeof(ExceptionPalabraClaveRepetida))]
        [TestMethod]
        public void AgregarPalabraClaveRepetidaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String Repetida = "Cine";
            List<string> ListaPalabras = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionAgregarUnaPalabraClave(UnaCategoria, Repetida);
        }


        [ExpectedException(typeof(ExceptionListaPalabrasClaveLlena))]
        [TestMethod]
        public void AgregarUnaPalabraClaveCuandoNoHayLugarTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String nuevaPalabra = "Cine Mudo";
            List<string> ListaPalabras = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6",
                "Palabra7","Palabra8","Palabra9","Palabra10"};
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionAgregarUnaPalabraClave(UnaCategoria, nuevaPalabra);
        }

        [TestMethod]
        public void ModificacionDeUnaPalabraClaveTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            List<string> ListaPalabras = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionModificacionDePalabraClave(UnaCategoria, "Futbol", "Bar");
            Assert.AreEqual(ListaPalabras[4], "Bar");
        }

        [ExpectedException(typeof(ExceptionListaPalabrasClaveLlena))]
        [TestMethod]
        public void ValidacionListaPalabrasLlenaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            List<string> ListaPalabras = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6", "Palabra7","Palabra8","Palabra9","Palabra10"};
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Manager.ListaPalabrasClaveLLena(UnaCategoria);
        }

        [ExpectedException(typeof(ExceptionPalabraClaveRepetida))]
        [TestMethod]
        public void ValidacionPalabraClaveRepetidaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            List<string> ListaPalabras = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6", "Palabra7","Palabra8"};
            Categoria UnaCategoria = new Categoria("Entretenimiento", ListaPalabras);
            String Repetida = "Palabra3";
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidarPalabraClaveRepetida(Repetida);
        }

        [TestMethod]
        public void EliminarPalabraClaveTest() 
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String PalabraElminar = "Palabra10";
            List<string> ListaPalabras = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6",
                "Palabra7","Palabra8","Palabra9","Palabra10"};
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Repositorio.AgregarCategoria(UnaCategoria);
            Manager.EliminarPalabraClave(PalabraElminar);
            Assert.AreEqual(9, UnaCategoria.ListaPalabras.Count);
        }
    }
}
