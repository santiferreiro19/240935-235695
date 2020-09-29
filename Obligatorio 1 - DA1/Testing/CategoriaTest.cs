using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;

namespace Testing
{
    [TestClass]
    public class CategoriaTest
    {
        private Logica logica;
        [TestMethod]
        public void CreacionDeCategoriaValida()
        {
            List<string> lista = new List<string>
            {"Cine","Carreras","Teatro","Caballos"};
            Categoria c = new Categoria("Entretenimiento", lista);
            Assert.IsNotNull(c);
        }
        [TestMethod]
        public void CreacionDeCategoriaValidaSinPalabrasClave()
        {
            Categoria c = new Categoria("Entretenimiento");
            Assert.IsNotNull(c);
        }
        [TestMethod]
        public void ValidacionNombreTest()
        {
            Logica unaLogica = new Logica();
            String Nombre = "Entretenimientos para Niños";
            bool aux = false;
            if (unaLogica.ValidacionNombre(Nombre)){
                aux = true;
            }
            Assert.IsFalse(aux);
        }
    }
}
