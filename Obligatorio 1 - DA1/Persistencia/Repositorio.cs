using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio_1___DA1;

namespace Persistencia
{
    public class Repositorio
    {
        private List<Categoria> ListaCategorias { get; set; }
        public Repositorio()
        {
            this.ListaCategorias = new List<Categoria>();
        }

        public List<Categoria> GetCategorias()
        {
            return this.ListaCategorias;
        }

        public void AgregarCategoria(Categoria unacategoria)
        {
            this.ListaCategorias.Add(unacategoria);
        }

        public void ModificarNombreCategoria(Categoria unacategoria, String NuevoNombre)
        {
            foreach(Categoria buscada in this.ListaCategorias){
                if (buscada.Equals(unacategoria))
                {
                    buscada.Nombre = NuevoNombre;
                }
            }
        }

        public void AgregarPalabraClave(Categoria unacategoria, String NuevaPalabra) {
            foreach (Categoria buscada in this.ListaCategorias)
            {
                if (buscada.Equals(unacategoria))
                {
                    buscada.ListaPalabras.Add(NuevaPalabra);
                }
            }
        }

        public void ModificarPalabraClave(Categoria unacategoria, String NuevaPalabra, String PalabraAnterior) {
            foreach (Categoria buscada in this.ListaCategorias)
            {
                if (buscada.Equals(unacategoria))
                {
                    for (int i = 0; i < unacategoria.ListaPalabras.Count(); i++)
                    {
                        if (PalabraAnterior == unacategoria.ListaPalabras[i])
                        {
                            unacategoria.ListaPalabras.RemoveAt(i);
                            unacategoria.ListaPalabras.Add(NuevaPalabra);
                        }
                    }
                }
            }
        }
        
    }
}
