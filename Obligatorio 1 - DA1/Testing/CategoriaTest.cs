using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;

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
        public void ConstructorSinParametrosTest() {
            Categoria c = new Categoria();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            String Nombre1 = "Entretenimiento";
            String Nombre2 = "Entretenimiento";
            List<string> Lista = new List<string>{"Cine","Carreras","Teatro","Caballos"};
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

        [TestMethod]
        public void ValidacionNombreConMasDe15CaracteresTest() 
        {
            String Nombre = "Entretenimientos para Niños";
            bool Aux = false;
            if (unaLogica.ValidacionNombre(Nombre)){
                Aux = true;
            }
            Assert.IsFalse(Aux);
        }

        [TestMethod]
        public void ValidacionNombreConMenosDe3CaracteresTest() 
        {
            String Nombre = "EP";
            bool Aux = false;
            if (unaLogica.ValidacionNombre(Nombre))
            {
                Aux = true;
            }
            Assert.IsFalse(Aux);
        }

        [TestMethod]
        public void ValidacionListaPalabrasTest()
        {
            List<string> Lista = new List<string> 
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6","Palabra7","Palabra8","Palabra9","Palabra10","Palabra11" };
            Assert.IsFalse(unaLogica.ValidacionListaPalabras(Lista));
        }

        // RESOLVER CREACION DE CATEGORIA VACIA //

        [TestMethod]
        public void ModificacionDeNombreTest() {
            String NuevoNombre = "Cine";
            String NombreAnterior = "Entretenimiento";
            Categoria c = new Categoria(NombreAnterior);
            if (unaLogica.ValidacionNombre(NuevoNombre))
            {
                c.Nombre = NuevoNombre;
            }
            Assert.AreEqual(c.Nombre, NuevoNombre);
        }

        [TestMethod]
        public void ModificacionDeNombreConMasDe15CaracteresTest()
        {
            String NuevoNombre = "Entretenimiento para niños";
            String NombreAnterior = "Entretenimiento";
            Categoria c = new Categoria(NombreAnterior);
            if (unaLogica.ValidacionNombre(NuevoNombre))
            {
                c.Nombre = NuevoNombre;
            }
            Assert.AreEqual(c.Nombre, NombreAnterior);
        }

        [TestMethod]
        public void ModificacionDeNombreConMenosDe3CaracteresTest()
        {
            String NuevoNombre = "EP";
            String NombreAnterior = "Entretenimiento";
            Categoria c = new Categoria(NombreAnterior);
            if (unaLogica.ValidacionNombre(NuevoNombre))
            {
                c.Nombre = NuevoNombre;
            }
            Assert.AreEqual(c.Nombre, NombreAnterior);
        }

        [TestMethod]
        public void ModificacionDeUnaPalabraClaveTest() {
            List<string> Lista = new List<string> {"Cine","Carreras","Futbol","Teatro", "Parque"};
            unaLogica.ModificacionDePalabraClave(Lista, "Futbol", "Bar");
            Assert.AreEqual(Lista[4], "Bar");
        }

        [TestMethod]
        public void AgregarUnaPalabraClaveCuandoHayLugarTest()
        {
            String nuevaPalabra = "Cine Mudo";
            List<string> Lista = new List<string> { "Cine", "Carreras", "Futbol", "Teatro", "Parque" };
            unaLogica.AgregarUnaPalabraClave(Lista, nuevaPalabra);
            Assert.AreEqual(Lista[5], nuevaPalabra);
        }

        [TestMethod]
        public void AgregarUnaPalabraClaveCuandoNoHayLugarTest()
        {
            String nuevaPalabra = "Cine Mudo";
            List<string> Lista = new List<string>
            {"Palabra1","Palabra2","Palabra3","Palabra4", "Palabra5","Palabra6","Palabra7","Palabra8","Palabra9","Palabra10"};
            unaLogica.AgregarUnaPalabraClave(Lista, nuevaPalabra);
            Assert.AreNotEqual(Lista[9], nuevaPalabra);
        }

    }
}
