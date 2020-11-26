using System;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionPresupuestoRepetido : Exception
    {
        public ExceptionPresupuestoRepetido(string message) : base(message) { }
    }
}
