using Obligatorio_1___DA1;
using System.Collections.Generic;
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
                return Contexto.Categorias.FirstOrDefault(u => u.Id == id);
            }
        }

        public List<Categoria> GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Categorias.ToList();
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
    }
}
