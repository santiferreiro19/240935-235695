using System;
namespace Obligatorio_1___DA1
{
    public class ExceptionNombreCategoria : Exception
    {
        public ExceptionNombreCategoria() : base() { }
        public ExceptionNombreCategoria(string message) : base(message) { }
        public ExceptionNombreCategoria(string message, System.Exception inner) : base(message, inner) { }

    }
}