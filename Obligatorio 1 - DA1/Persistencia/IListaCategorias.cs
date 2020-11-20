using Obligatorio_1___DA1;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    public class IListaCategorias : ILista<Categoria>
    {
        public void Add(Categoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Categorias.Add(entidad);
                Contexto.SaveChanges();
            }
        }
        public Categoria Get(int id)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Categorias.Include("ListaPalabras").FirstOrDefault(u => u.Id == id);
            }
        }

        public List<Categoria> GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Categorias.Include("ListaPalabras").ToList();
            }
        }

        public void Remove(Categoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Categorias.Remove(entidad);
                Contexto.SaveChanges();
            }
        }

        public bool Contains(Categoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                List<Categoria> Lista = Contexto.Categorias.Where(x => x.Equals(entidad)).ToList();
                return Lista.Count() != 0;
            }
        }
        public void Update(Categoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Categoria unaCategoria = Contexto.Categorias.Include("ListaPalabras").FirstOrDefault(u => u.Id == entidad.Id);
                for(int i=0;i < entidad.ListaPalabras.Count; i++) {
                    if (i < unaCategoria.ListaPalabras.Count)
                    {
                        unaCategoria.ListaPalabras[i].Palabra = entidad.ListaPalabras[i].Palabra;
                    }
                    else {
                        unaCategoria.ListaPalabras.Add(entidad.ListaPalabras[i]);
                    }
                }
                unaCategoria.Nombre = entidad.Nombre;
                Contexto.Entry(unaCategoria).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }
    }
}
