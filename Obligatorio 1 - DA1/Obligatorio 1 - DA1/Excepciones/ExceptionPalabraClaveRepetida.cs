using System;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionPalabraClaveRepetida : Exception
    {
        public ExceptionPalabraClaveRepetida() : base() { }
        public ExceptionPalabraClaveRepetida(string message) : base(message) { }
        public ExceptionPalabraClaveRepetida(string message, System.Exception inner) : base(message, inner) { }
    }
}
