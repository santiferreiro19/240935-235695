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
    public class MontoCategoriaTest
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
            MontoCategoria unMonto = new MontoCategoria();
            Assert.IsNotNull(unMonto);
        }

        [TestMethod]
        public void ConstructorConParametrosTest()
        {
            Categoria unaCategoria = new Categoria();
            MontoCategoria unMonto = new MontoCategoria(unaCategoria, 0.00M);
            Assert.IsNotNull(unMonto);
        }

        [TestMethod]
        public void toStringTest()
        {
            Categoria unaCategoria = new Categoria("unaCategoria");
            MontoCategoria unMonto = new MontoCategoria(unaCategoria, 0.00M);
            Assert.AreEqual(unMonto.ToString(), "unaCategoria");
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
