using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionFechaGasto : Exception
    {
        public ExceptionFechaGasto() : base() { }
        public ExceptionFechaGasto(string message) : base(message) { }
        public ExceptionFechaGasto(string message, System.Exception inner) : base(message, inner) { }
    }
}
