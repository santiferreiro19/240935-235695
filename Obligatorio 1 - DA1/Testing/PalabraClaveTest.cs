using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_1___DA1;
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
    }
}
