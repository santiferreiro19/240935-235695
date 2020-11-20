using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestClass]
    public class PalabraClaveTest
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
        public void ConstructorSinParametrosTest() 
        {
            PalabraClave p = new PalabraClave();
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            PalabraClave p = new PalabraClave("Entretenimiento");
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void toStringTest()
        {
            PalabraClave p = new PalabraClave("Entretenimiento");
            Assert.AreEqual(p.ToString(), "Entretenimiento");
        }

        [TestCleanup]
        public void CleanUp()
        {

            using (ContextoFinanzas db = new ContextoFinanzas())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM PRESUPUESTOES;");
                db.Database.ExecuteSqlCommand("DELETE FROM GASTOES;");
                db.Database.ExecuteSqlCommand("DELETE FROM PALABRACLAVES;");
                db.Database.ExecuteSqlCommand("DELETE FROM CATEGORIAS;");
                db.Database.ExecuteSqlCommand("DELETE FROM MONEDAS;");

            }
        }
    }
}
