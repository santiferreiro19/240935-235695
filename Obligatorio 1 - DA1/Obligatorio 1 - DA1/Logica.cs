using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio_1___DA1.Excepciones;


namespace Obligatorio_1___DA1
{
    public class Logica
    {
        public void ValidacionNombreCategoria(String unNombre) 
        {
            int cantidad = unNombre.Length;
            if (cantidad > 15 || cantidad < 3)
            {
                throw new ExcepcionNombreCategoria("El nombre debe tener entre 3 y 15 caracteres");
            }
        }
     
        
        // ERROR, HAY QUE VALIDARLO PARA TODAS LAS PALABRAS CLAVE DEL SISTEMA //
        public void PalabraClaveRepetida(List<string> unaLista, String PalabraBuscar) {
            for (int i = 0; i < unaLista.Count(); i++) {
                if (unaLista[i] == PalabraBuscar) {
                    throw new ExceptionPalabraClaveRepetida("Palabra clave repetida");
                }
            }
        }

        public void ListaPalabrasClaveLLena(List<string> unaLista) {
            if (unaLista.Count() >= 10) {
                throw new ExceptionListaPalabrasClaveLlena("Lista de palabras clave llena");
            }
        }
    }
}
