using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio_1___DA1
{

    public class Categoria
    {
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

        public void ModificarNombreCategoria(String NuevoNombre)
        {
            Logica unaLogica = new Logica();
            unaLogica.ValidacionNombreCategoria(NuevoNombre);
            this.Nombre = NuevoNombre;
        }

        public void AgregarUnaPalabraClave(String NuevaPalabra)
        {
            Logica unaLogica = new Logica();
            unaLogica.PalabraClaveRepetida(this.ListaPalabras, NuevaPalabra);
            unaLogica.ListaPalabrasClaveLLena(this.ListaPalabras);
            this.ListaPalabras.Add(NuevaPalabra);
        }

        public void ModificacionDePalabraClave(String PalabraBuscada, String NuevaPalabraClave)
        {
            Logica unaLogica = new Logica();
            unaLogica.PalabraClaveRepetida(this.ListaPalabras, NuevaPalabraClave);
            for (int i = 0; i < this.ListaPalabras.Count(); i++)
            {
                if (PalabraBuscada == this.ListaPalabras[i])
                {
                    this.ListaPalabras.RemoveAt(i);
                    this.ListaPalabras.Add(NuevaPalabraClave);
                }
            }
        }
    }
}
