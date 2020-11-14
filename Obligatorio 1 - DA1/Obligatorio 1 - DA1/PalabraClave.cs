using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1
{
    public class PalabraClave
    {
        public String Palabra { set; get; }

        public PalabraClave()
        {
            this.Palabra = ""; ;
        }
        public PalabraClave(String unaPalabra)
        {
            this.Palabra = unaPalabra;
        }
        
        override
         public string ToString()
        {
            return Palabra;
        }
    }
}
