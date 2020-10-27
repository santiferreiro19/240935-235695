using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionPresupuestoRepetido : Exception
    {
        public ExceptionPresupuestoRepetido() : base() { }
        public ExceptionPresupuestoRepetido(string message) : base(message) { }
        public ExceptionPresupuestoRepetido(string message, System.Exception inner) : base(message, inner) { }
    }
}
