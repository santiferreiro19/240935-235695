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
        Repositorio Repo;

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
            Categoria UnaCategoria = new Categoria();
            Assert.IsNotNull(UnaCategoria);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            String Nombre1 = "Entretenimiento";
            String Nombre2 = "Entretenimiento";
            PalabraClave palabra1 = new PalabraClave("Cine");
            PalabraClave palabra2 = new PalabraClave("Carreras");
            PalabraClave palabra3 = new PalabraClave("Teatro");
            PalabraClave palabra4 = new PalabraClave("Caballos");
            List<PalabraClave> ListaPalabras = new List<PalabraClave> { palabra1, palabra2, palabra3, palabra4 };
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
            PalabraClave palabra1 = new PalabraClave("Cine");
            PalabraClave palabra2 = new PalabraClave("Carreras");
            PalabraClave palabra3 = new PalabraClave("Teatro");
            PalabraClave palabra4 = new PalabraClave("Caballos");
            List<PalabraClave> ListaPalabras = new List<PalabraClave> { palabra1, palabra2, palabra3, palabra4 };
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
            Assert.AreEqual(UnaCategoria.Nombre, Repositorio.GetCategorias().GetAll()[0].Nombre);
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
            Categoria palabraDB = Repositorio.GetCategorias().Get(UnaCategoria.Id);
            Assert.AreEqual(palabraDB.Nombre, NuevoNombre);
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
            PalabraClave palabra1 = new PalabraClave("Cine");
            PalabraClave palabra2 = new PalabraClave("Carreras");
            PalabraClave palabra3 = new PalabraClave("Futbol");
            PalabraClave palabra4 = new PalabraClave("Teatro");
            PalabraClave palabra5 = new PalabraClave("Parque");
            List<PalabraClave> ListaPalabras = new List<PalabraClave> { palabra1, palabra2, palabra3, palabra4, palabra5 };
            Categoria UnaCategoria = new Categoria("Mudo", ListaPalabras);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionAgregarUnaPalabraClave(UnaCategoria, nuevaPalabra);
            Categoria palabraDB = Repositorio.GetCategorias().Get(UnaCategoria.Id);
            Assert.IsNotNull(palabraDB.ListaPalabras.Find(x => x.Palabra == nuevaPalabra));
        }

        [ExpectedException(typeof(ExceptionPalabraClaveRepetida))]
        [TestMethod]
        public void AgregarPalabraClaveRepetidaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            String Repetida = "Cine";
            PalabraClave palabra1 = new PalabraClave("Cine");
            PalabraClave palabra2 = new PalabraClave("Carreras");
            PalabraClave palabra3 = new PalabraClave("Futbol");
            PalabraClave palabra4 = new PalabraClave("Teatro");
            PalabraClave palabra5 = new PalabraClave("Parque");
            List<PalabraClave> ListaPalabras = new List<PalabraClave> { palabra1, palabra2, palabra3, palabra4, palabra5 };
            Categoria UnaCategoria = new Categoria("Balet", ListaPalabras);
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
            PalabraClave palabra1 = new PalabraClave("palabra1");
            PalabraClave palabra2 = new PalabraClave("palabra2");
            PalabraClave palabra3 = new PalabraClave("palabra3");
            PalabraClave palabra4 = new PalabraClave("palabra4");
            PalabraClave palabra5 = new PalabraClave("palabra5");
            PalabraClave palabra6 = new PalabraClave("palabra6");
            PalabraClave palabra7 = new PalabraClave("palabra7");
            PalabraClave palabra8 = new PalabraClave("palabra8");
            PalabraClave palabra9 = new PalabraClave("palabra9");
            PalabraClave palabra10 = new PalabraClave("palabra10");
            List<PalabraClave> ListaPalabras = new List<PalabraClave>
            {palabra1,palabra2,palabra3,palabra4,palabra5,palabra6,
                palabra7,palabra8,palabra9,palabra10};
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionAgregarUnaPalabraClave(UnaCategoria, nuevaPalabra);
        }

        [TestMethod]
        public void ModificacionDeUnaPalabraClaveTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            PalabraClave palabra1 = new PalabraClave("Cine");
            PalabraClave palabra2 = new PalabraClave("Carreras");
            PalabraClave palabra3 = new PalabraClave("Futbol");
            PalabraClave palabra4 = new PalabraClave("Teatro");
            PalabraClave palabra5 = new PalabraClave("Parque");
            List<PalabraClave> ListaPalabras = new List<PalabraClave> { palabra1, palabra2, palabra3, palabra4, palabra5 };
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Manager.ValidacionAgregarCategoria(UnaCategoria);
            Manager.ValidacionModificacionDePalabraClave(UnaCategoria, "Parque", "Bar");
            Categoria categoriaValidar = Repositorio.GetCategorias().Get(UnaCategoria.Id);
            Assert.AreEqual(categoriaValidar.ListaPalabras[4].Palabra, "Bar");
        }

        [ExpectedException(typeof(ExceptionListaPalabrasClaveLlena))]
        [TestMethod]
        public void ValidacionListaPalabrasLlenaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            PalabraClave palabra1 = new PalabraClave("palabra1");
            PalabraClave palabra2 = new PalabraClave("palabra2");
            PalabraClave palabra3 = new PalabraClave("palabra3");
            PalabraClave palabra4 = new PalabraClave("palabra4");
            PalabraClave palabra5 = new PalabraClave("palabra5");
            PalabraClave palabra6 = new PalabraClave("palabra6");
            PalabraClave palabra7 = new PalabraClave("palabra7");
            PalabraClave palabra8 = new PalabraClave("palabra8");
            PalabraClave palabra9 = new PalabraClave("palabra9");
            PalabraClave palabra10 = new PalabraClave("palabra10");
            List<PalabraClave> ListaPalabras = new List<PalabraClave>
            {palabra1,palabra2,palabra3,palabra4,palabra5,palabra6,
                palabra7,palabra8,palabra9,palabra10};
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Manager.ListaPalabrasClaveLLena(UnaCategoria);
        }

        [ExpectedException(typeof(ExceptionPalabraClaveRepetida))]
        [TestMethod]
        public void ValidacionPalabraClaveRepetidaTest()
        {
            Repositorio Repositorio = new Repositorio();
            ManagerCategoria Manager = new ManagerCategoria(Repositorio);
            PalabraClave palabra1 = new PalabraClave("palabra1");
            PalabraClave palabra2 = new PalabraClave("palabra2");
            PalabraClave palabra3 = new PalabraClave("Palabra3");
            PalabraClave palabra4 = new PalabraClave("palabra4");
            PalabraClave palabra5 = new PalabraClave("palabra5");
            PalabraClave palabra6 = new PalabraClave("palabra6");
            PalabraClave palabra7 = new PalabraClave("palabra7");
            PalabraClave palabra8 = new PalabraClave("palabra8");
            List<PalabraClave> ListaPalabras = new List<PalabraClave>
            {palabra1,palabra2,palabra3,palabra4,palabra5,palabra6,
                palabra7,palabra8};
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
            String PalabraElminar = "palabra10";
            PalabraClave palabra1 = new PalabraClave("palabra1");
            PalabraClave palabra2 = new PalabraClave("palabra2");
            PalabraClave palabra3 = new PalabraClave("palabra3");
            PalabraClave palabra4 = new PalabraClave("palabra4");
            PalabraClave palabra5 = new PalabraClave("palabra5");
            PalabraClave palabra6 = new PalabraClave("palabra6");
            PalabraClave palabra7 = new PalabraClave("palabra7");
            PalabraClave palabra8 = new PalabraClave("palabra8");
            PalabraClave palabra9 = new PalabraClave("palabra9");
            PalabraClave palabra10 = new PalabraClave("palabra10");
            List<PalabraClave> ListaPalabras = new List<PalabraClave>
            {palabra1,palabra2,palabra3,palabra4,palabra5,palabra6,
                palabra7,palabra8,palabra9,palabra10};
            Categoria UnaCategoria = new Categoria("Cine", ListaPalabras);
            Repositorio.AgregarCategoria(UnaCategoria);
            Manager.EliminarPalabraClave(PalabraElminar);
            Categoria categoriaValidar = Repositorio.GetCategorias().Get(UnaCategoria.Id);
            Assert.AreEqual(9, categoriaValidar.ListaPalabras.Count);
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
