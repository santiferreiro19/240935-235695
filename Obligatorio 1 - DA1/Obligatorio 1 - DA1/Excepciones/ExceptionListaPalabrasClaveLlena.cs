using System;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionListaPalabrasClaveLlena : Exception
    {
        public ExceptionListaPalabrasClaveLlena() : base() { }
        public ExceptionListaPalabrasClaveLlena(string message) : base(message) { }
        public ExceptionListaPalabrasClaveLlena(string message, System.Exception inner) : base(message, inner) { }
    }
}
