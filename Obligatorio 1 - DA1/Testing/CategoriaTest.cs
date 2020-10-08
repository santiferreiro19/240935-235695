using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;

namespace Testing
{
    [TestClass]
    public class CategoriaTest
    {
        private Logica unaLogica;

        [TestInitialize]
        public void Setup()
        {
            unaLogica = new Logica();
        }

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

        [ExpectedException(typeof(ExcepcionNombreCategoria))]
        [TestMethod]
        public void ValidacionNombreConMasDe15CaracteresTest()
        {
            String Nombre = "Entretenimientos para Niños";
            unaLogica.ValidacionNombreCategoria(Nombre);
        }

        [ExpectedException(typeof(ExcepcionNombreCategoria))]
        [TestMethod]
        public void ValidacionNombreConMenosDe3CaracteresTest()
        {
            String Nombre = "EP";
            unaLogica.ValidacionNombreCategoria(Nombre);
        }

        [TestMethod]
        public void ModificacionDeNombreCategoriaTest()
        {
            String NuevoNombre = "Cine";
            String NombreAnterior = "Entretenimiento";
            Categoria c = new Categoria(NombreAnterior);
            c.ModificarNombreCategoria(NuevoNombre);
            Assert.AreEqual(c.Nombre, NuevoNombre);
        }

        [ExpectedException(typeof(ExcepcionNombreCategoria))]
        [TestMethod]
        public void ModificacionDeNombreConMasDe15CaracteresTest()
        {
            String NuevoNombre = "Entretenimiento para niños";
            Categoria c = new Categoria("Entretenimiento");
            c.ModificarNombreCategoria(NuevoNombre);
        }

        [ExpectedException(typeof(ExcepcionNombreCategoria))]
        [TestMethod]
        public void ModificacionDeNombreConMenosDe3CaracteresTest()
        {
            String NuevoNombre = "EP";
            String NombreAnterior = "Entretenimiento";
            Categoria c = new Categoria(NombreAnterior);
            c.ModificarNombreCategoria(NuevoNombre);
        }

        [ExpectedException(typeof(ExceptionPalabraClaveRepetida))]
        [TestMethod]
        public void AgregarPalabraClaveRepetidaTest()
        {
            String Repetida = "Cine";
            List<string> Lista = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            Categoria c = new Categoria("Cine", Lista);
            c.AgregarUnaPalabraClave(Repetida);
        }

        [TestMethod]
        public void ModificacionDeUnaPalabraClaveTest()
        {
            List<string> Lista = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            Categoria c = new Categoria("Cine", Lista);
            c.ModificacionDePalabraClave("Futbol", "Bar");
            Assert.AreEqual(Lista[4], "Bar");
        }


        [TestMethod]
        public void AgregarUnaPalabraClaveCuandoHayLugarTest()
        {
            String nuevaPalabra = "Cine Mudo";
            List<string> Lista = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            Categoria c = new Categoria("Cine", Lista);
            c.AgregarUnaPalabraClave(nuevaPalabra);
            Assert.AreEqual(Lista[5], nuevaPalabra);
        }

        [ExpectedException(typeof(ExceptionListaPalabrasClaveLlena))]
        [TestMethod]
        public void AgregarUnaPalabraClaveCuandoNoHayLugarTest()
        {
            String nuevaPalabra = "Cine Mudo";
            List<string> Lista = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6",
                "Palabra7","Palabra8","Palabra9","Palabra10"};
            Categoria c = new Categoria("Cine", Lista);
            c.AgregarUnaPalabraClave(nuevaPalabra);
        }

        [ExpectedException(typeof(ExceptionListaPalabrasClaveLlena))]
        [TestMethod]
        public void ValidacionListaPalabrasLlena()
        {
            List<string> Lista = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6", "Palabra7","Palabra8","Palabra9","Palabra10"};
            unaLogica.ListaPalabrasClaveLLena(Lista);
        }

        [ExpectedException(typeof(ExceptionPalabraClaveRepetida))]
        [TestMethod]
        public void ValidacionPalabraClaveRepetida()
        {
            List<string> Lista = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6", "Palabra7","Palabra8","Palabra9","Palabra10"};
            Categoria c = new Categoria("Entretenimiento", Lista);
            String Repetida = "Palabra3";
            unaLogica.PalabraClaveRepetida(Lista, Repetida);
        }
    }
}
