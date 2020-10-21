using System;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionNombreCategoriaRepetido : Exception
    {
        public ExceptionNombreCategoriaRepetido() : base() { }
        public ExceptionNombreCategoriaRepetido(string message) : base(message) { }
        public ExceptionNombreCategoriaRepetido(string message, System.Exception inner) : base(message, inner) { }
    }
}
