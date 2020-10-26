using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionMontoPresupuesto : Exception
    {
        public ExceptionMontoPresupuesto() : base() { }
        public ExceptionMontoPresupuesto(string message) : base(message) { }
        public ExceptionMontoPresupuesto(string message, System.Exception inner) : base(message, inner) { }
    }
}
