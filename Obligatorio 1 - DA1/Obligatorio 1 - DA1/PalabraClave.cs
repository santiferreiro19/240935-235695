using System;

namespace Obligatorio_1___DA1
{
    public class PalabraClave
    {
        public int Id { get; set; }
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
