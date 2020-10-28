using System;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionNombreCategoriaRepetido : Exception
    {
        public ExceptionNombreCategoriaRepetido(string message) : base(message) { }
    }
}
