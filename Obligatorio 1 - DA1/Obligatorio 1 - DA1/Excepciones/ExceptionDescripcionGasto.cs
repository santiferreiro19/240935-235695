using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionDescripcionGasto : Exception
    {
        public ExceptionDescripcionGasto(string message) : base(message) { }
    }
}
