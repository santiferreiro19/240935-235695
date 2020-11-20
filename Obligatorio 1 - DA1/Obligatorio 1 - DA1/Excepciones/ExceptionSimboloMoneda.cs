using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1.Excepciones
{
    public class ExceptionSimboloMoneda : Exception
    {
        public ExceptionSimboloMoneda(string message) : base(message) { }
    }
}
