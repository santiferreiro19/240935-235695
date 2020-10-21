using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;

namespace Managers
{
    public class ManagerCategoria
    {
        private Repositorio Repo;
        public ManagerCategoria(Repositorio unRepo)
        {
            this.Repo = unRepo;
        }

        public void ValidacionAgregarCategoria(Categoria unacategoria)
        {
            this.ValidarNombreCategoria(unacategoria.Nombre);
            Repo.AgregarCategoria(unacategoria);
        }

         public void ValidacionModificarNombreCategoria(Categoria unacategoria,String NuevoNombre)
        {
            this.ValidarNombreCategoria(NuevoNombre);
            Repo.ModificarNombreCategoria(unacategoria, NuevoNombre);
        }

        public void ValidacionAgregarUnaPalabraClave(Categoria unacategoria,String NuevaPalabra)
        {
            this.ListaPalabrasClaveLLena(unacategoria);
            this.ValidarPalabraClaveRepetida(NuevaPalabra);
            Repo.AgregarPalabraClave(unacategoria,NuevaPalabra);
        }

        public void ValidacionModificacionDePalabraClave(Categoria unacategoria,String PalabraBuscada, String NuevaPalabraClave)
        {
            this.ValidarPalabraClaveRepetida(NuevaPalabraClave);
            Repo.ModificarPalabraClave(unacategoria, NuevaPalabraClave, PalabraBuscada);
        }

        public void ValidarNombreCategoria(String nombreCategoria)
        {
            List<Categoria> categorias = Repo.GetCategorias();
            if (categorias.Any(categoria => categoria.Nombre.Equals(nombreCategoria)))
            {
                throw new ExceptionNombreCategoriaRepetido("El nombre de la categoria tiene que ser unico");
            }
            int cantidad = nombreCategoria.Length;
            if (cantidad > 15 || cantidad < 3)
            {
                throw new ExceptionNombreCategoria("El nombre debe tener entre 3 y 15 caracteres");
            }
        }

        public void ValidarPalabraClaveRepetida(String PalabraBuscar)
        {
            List<Categoria> categorias = Repo.GetCategorias();
            if (categorias.Any(categoria => categoria.ListaPalabras.Contains(PalabraBuscar)))
            {
                throw new ExceptionPalabraClaveRepetida("El nombre de la palabra clave debe de ser unico");
            }
        }
          public void ListaPalabrasClaveLLena(Categoria unacategoria)
          {
            if (unacategoria.ListaPalabras.Count() >= 10)
            {
                throw new ExceptionListaPalabrasClaveLlena("Lista de palabras clave llena");
            }
          }
    }
}
