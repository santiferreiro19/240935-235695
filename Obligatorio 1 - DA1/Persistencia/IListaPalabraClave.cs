using Obligatorio_1___DA1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    class IListaPalabraClave : ILista<PalabraClave>
    {
        public void Add(PalabraClave entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.PalabrasClave.Add(entidad);
                Contexto.SaveChanges();
            }
        }

        public bool Contains(PalabraClave entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                PalabraClave unaPalabraClave = Contexto.PalabrasClave.FirstOrDefault(u => u.Id == entidad.Id);
                return unaPalabraClave != null;
            }
        }

        public PalabraClave Get(int id)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                PalabraClave unaPalabraClave = Contexto.PalabrasClave.FirstOrDefault(u => u.Id == id);
                return unaPalabraClave;
            }
        }

        public List<PalabraClave> GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.PalabrasClave.ToList();
            }
        }

        public void Remove(PalabraClave entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                PalabraClave unaPalabraClave = Contexto.PalabrasClave.FirstOrDefault(u => u.Id == entidad.Id);
                Contexto.PalabrasClave.Remove(unaPalabraClave);
                Contexto.SaveChanges();
            }
        }

        public void Update(PalabraClave entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                PalabraClave unaPalabraClave = Contexto.PalabrasClave.FirstOrDefault(u => u.Id == entidad.Id); 
                unaPalabraClave.Palabra = entidad.Palabra;
                Contexto.Entry(unaPalabraClave).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }
    }
}
