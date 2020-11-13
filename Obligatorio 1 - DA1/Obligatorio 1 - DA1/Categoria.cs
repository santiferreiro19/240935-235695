using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio_1___DA1
{

    public class Categoria
    {
        public int Id { get; set; }
        public String Nombre { set; get; }
        public List<String> ListaPalabras;

        public Categoria()
        {
            this.Nombre = "";
            this.ListaPalabras = new List<string>();
        }
        public Categoria(String unNombre, List<String> unasPalabras)
        {
            this.Nombre = unNombre;
            this.ListaPalabras = unasPalabras;
        }
        public Categoria(String unNombre)
        {
            this.Nombre = unNombre;
            this.ListaPalabras = new List<string>();
        }
       
        override
        public string ToString()
        {
            return Nombre;
        }
    }
}
