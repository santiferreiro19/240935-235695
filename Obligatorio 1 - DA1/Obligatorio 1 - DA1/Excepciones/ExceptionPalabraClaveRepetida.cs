using System;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionPalabraClaveRepetida : Exception
    {
        public ExceptionPalabraClaveRepetida(string message) : base(message) { }
    }
}
