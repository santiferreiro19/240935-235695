using Obligatorio_1___DA1;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class CategoriaDataAccess : IDataAccess<Categoria>
    {
        public void Agregar(Categoria entity)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Categorias.Add(entity);
                Contexto.SaveChanges();
            }
        }

        public void Eliminar(Categoria entity)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Categorias.Remove(entity);
                Contexto.SaveChanges();
            }
        }

        public Categoria Obtener(int id)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Categorias.FirstOrDefault(u => u.Id == id);
            }
        }

        public IEnumerable<Categoria> ObtenerTodos()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Categorias.ToList();
            }
        }
        public void ModificarNombreCategoria(Categoria unaCategoria, string NuevoNombre)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Categoria Entidad = Contexto.Categorias.FirstOrDefault(u => u.Id == unaCategoria.Id);
                Entidad.Nombre = NuevoNombre;
                Contexto.SaveChanges();
            }
        }

        public void ModificarPalabraClave(Categoria unaCategoria, string NuevaPalabra, string PalabraAnterior)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Categoria Entidad = Contexto.Categorias.FirstOrDefault(u => u.Id == unaCategoria.Id);
                foreach (var Palabra in Entidad.ListaPalabras)
                {
                    if (PalabraAnterior == Palabra)
                    {
                        Entidad.ListaPalabras.Remove(Palabra);
                        Entidad.ListaPalabras.Add(NuevaPalabra);
                    }
                }
                Contexto.SaveChanges();
            }
        }

        public void AgregarPalabraClave(Categoria unaCategoria, string NuevaPalabra)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Categoria Entidad = Contexto.Categorias.FirstOrDefault(u => u.Id == unaCategoria.Id);
                Entidad.ListaPalabras.Add(NuevaPalabra);
                Contexto.SaveChanges();
            }
        }

        public void EliminarPalabraClave(Categoria unaCategoria, string PalabraBorrar)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Categoria Entidad = Contexto.Categorias.FirstOrDefault(u => u.Id == unaCategoria.Id);
                foreach (var Palabra in Entidad.ListaPalabras)
                {
                    if (PalabraBorrar == Palabra)
                    {
                        Entidad.ListaPalabras.Remove(Palabra);
                    }
                }
                Contexto.SaveChanges();
            }
        }
    }
}
