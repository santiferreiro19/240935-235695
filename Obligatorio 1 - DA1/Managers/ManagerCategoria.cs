using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void ValidacionModificarNombreCategoria(Categoria unacategoria, String NuevoNombre)
        {
            this.ValidarNombreCategoria(NuevoNombre);
            Repo.ModificarNombreCategoria(unacategoria, NuevoNombre);
        }

        public void ValidacionAgregarUnaPalabraClave(Categoria unacategoria, string NuevaPalabra)
        {
            this.ListaPalabrasClaveLLena(unacategoria);
            this.ValidarPalabraClaveRepetida(NuevaPalabra);
            Repo.AgregarPalabraClave(unacategoria, NuevaPalabra);
        }

        public void ValidacionModificacionDePalabraClave(Categoria unacategoria, String PalabraBuscada, String NuevaPalabraClave)
        {
            this.ValidarPalabraClaveRepetida(NuevaPalabraClave);
            Repo.ModificarPalabraClave(unacategoria, NuevaPalabraClave, PalabraBuscada);
        }

        public void ValidarNombreCategoria(String nombreCategoria)
        {
            List<Categoria> categorias = Repo.GetCategorias().GetAll();
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
            List<Categoria> categorias = Repo.GetCategorias().GetAll();
            PalabraClave palabra = new PalabraClave(PalabraBuscar);
            foreach (Categoria cadaCategoria in categorias)
            {
                if (cadaCategoria.ListaPalabras.Any(x => x.Palabra == PalabraBuscar))
                {
                    throw new ExceptionPalabraClaveRepetida("El nombre de la palabra clave debe de ser unico");
                }
            }
        }
        public void ListaPalabrasClaveLLena(Categoria Unacategoria)
        {
            if (Unacategoria.ListaPalabras.Count() >= 10)
            {
                throw new ExceptionListaPalabrasClaveLlena("Lista de palabras clave llena");
            }
        }
        public void EliminarPalabraClave(String PalabraEliminar)
        {
            List<Categoria> categorias = Repo.GetCategorias().GetAll();
            PalabraClave palabra = new PalabraClave(PalabraEliminar);
            foreach (Categoria cadaCategoria in categorias)
            {
                if (cadaCategoria.ListaPalabras.Any(x => x.Palabra == PalabraEliminar))
                {
                    Repo.EliminarPalabraClave(PalabraEliminar);
                }
            }
        }
    }
}
