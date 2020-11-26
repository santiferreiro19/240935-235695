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
        private const int Largo_Maximo_Nombre_Categoria = 15;
        private const int Largo_Minimo_Nombre_Categoria = 3;
        private const int Cantidad_Maxima_De_Palabras_Clave = 10;


        public ManagerCategoria(Repositorio unRepo)
        {
            this.Repo = unRepo;
        }

        public void ValidacionAgregarCategoria(Categoria unacategoria)
        {
            this.ValidarNombreCategoria(unacategoria.Nombre);
            Repo.AgregarCategoria(unacategoria);
        }

        public void ValidacionModificarNombreCategoria(Categoria unacategoria, String nuevoNombre)
        {
            this.ValidarNombreCategoria(nuevoNombre);
            Repo.ModificarNombreCategoria(unacategoria, nuevoNombre);
        }

        public void ValidacionAgregarUnaPalabraClave(Categoria unacategoria, string nuevaPalabra)
        {
            this.ListaPalabrasClaveLLena(unacategoria);
            this.ValidarPalabraClaveRepetida(nuevaPalabra);
            Repo.AgregarPalabraClave(unacategoria, nuevaPalabra);
        }

        public void ValidacionModificacionDePalabraClave(Categoria unacategoria, String palabraBuscada, String nuevaPalabraClave)
        {
            this.ValidarPalabraClaveRepetida(nuevaPalabraClave);
            Repo.ModificarPalabraClave(unacategoria, nuevaPalabraClave, palabraBuscada);
        }

        public void ValidarNombreCategoria(String nombreCategoria)
        {
            List<Categoria> categorias = Repo.GetCategorias().GetAll();
            if (categorias.Any(categoria => categoria.Nombre.Equals(nombreCategoria)))
            {
                throw new ExceptionNombreCategoriaRepetido("El nombre de la categoria tiene que ser unico");
            }
            int cantidad = nombreCategoria.Length;
            
            if (cantidad > Largo_Maximo_Nombre_Categoria || cantidad < Largo_Minimo_Nombre_Categoria)
            {
                throw new ExceptionNombreCategoria("El nombre debe tener entre 3 y 15 caracteres");
            }
        }

        public void ValidarPalabraClaveRepetida(String palabraBuscar)
        {
            List<Categoria> categorias = Repo.GetCategorias().GetAll();
            PalabraClave palabra = new PalabraClave(palabraBuscar);
            foreach (Categoria cadaCategoria in categorias)
            {
                if (cadaCategoria.ListaPalabras.Any(x => x.Palabra == palabraBuscar))
                {
                    throw new ExceptionPalabraClaveRepetida("El nombre de la palabra clave debe de ser unico");
                }
            }
        }
        public void ListaPalabrasClaveLLena(Categoria unacategoria)
        {
            if (unacategoria.ListaPalabras.Count() >= Cantidad_Maxima_De_Palabras_Clave)
            {
                throw new ExceptionListaPalabrasClaveLlena("Lista de palabras clave llena");
            }
        }
        public void EliminarPalabraClave(String palabraEliminar)
        {
            List<Categoria> categorias = Repo.GetCategorias().GetAll();
            PalabraClave palabra = new PalabraClave(palabraEliminar);
            foreach (Categoria cadaCategoria in categorias)
            {
                if (cadaCategoria.ListaPalabras.Any(x => x.Palabra == palabraEliminar))
                {
                    Repo.EliminarPalabraClave(palabraEliminar);
                }
            }
        }
    }
}
