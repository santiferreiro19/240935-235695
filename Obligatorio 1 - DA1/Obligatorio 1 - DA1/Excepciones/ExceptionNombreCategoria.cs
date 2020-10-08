using System;
namespace Obligatorio_1___DA1
{
    public class ExcepcionNombreCategoria : Exception
    {
        public ExcepcionNombreCategoria() : base() { }
        public ExcepcionNombreCategoria(string message) : base(message) { }
        public ExcepcionNombreCategoria(string message, System.Exception inner) : base(message, inner) { }

    }
}