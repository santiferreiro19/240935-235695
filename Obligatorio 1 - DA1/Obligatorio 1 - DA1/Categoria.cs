using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1
{
    public class Categoria
    {
        public String Nombre { set; get; }
        List<String> ListaPalabras;

        public Categoria(String unNombre,  List<String> unasPalabras) {
            this.Nombre = unNombre;
            this.ListaPalabras = unasPalabras;
        }
        public Categoria(String unNombre)
        {
            this.Nombre = unNombre;
            this.ListaPalabras = new List<string>();
        }

    }
}
