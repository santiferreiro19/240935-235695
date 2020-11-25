using System;
using System.Collections.Generic;

namespace Obligatorio_1___DA1
{

    public class Categoria
    {
        public int Id { get; set; }
        public String Nombre { set; get; }
        public List<PalabraClave> ListaPalabras { get; set; }

        public Categoria()
        {
            this.Nombre = "";
            this.ListaPalabras = new List<PalabraClave>();
        }
        public Categoria(String unNombre, List<PalabraClave> unasPalabras)
        {
            this.Nombre = unNombre;
            this.ListaPalabras = unasPalabras;
        }
        public Categoria(String unNombre)
        {
            this.Nombre = unNombre;
            this.ListaPalabras = new List<PalabraClave>();
        }

        override
        public string ToString()
        {
            return Nombre;
        }
    }
}
