using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionMonto : Exception
    {
        public ExceptionMonto() : base() { }
        public ExceptionMonto(string message) : base(message) { }
        public ExceptionMonto(string message, System.Exception inner) : base(message, inner) { }
    }
}
