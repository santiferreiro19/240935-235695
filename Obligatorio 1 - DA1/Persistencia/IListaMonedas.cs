using Obligatorio_1___DA1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class IListaMonedas : ILista<Moneda>
    {
        public void Add(Moneda entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Monedas.Add(entidad);
                Contexto.SaveChanges();
            }
        }
        public void Remove(Moneda entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Monedas.Remove(entidad);
                Contexto.SaveChanges();
            }
        }
        public Moneda Get(int id)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Monedas.FirstOrDefault(u => u.Id == id);
            }
        }

        public List<Moneda> GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Monedas.ToList();
            }
        }

        public bool Contains(Moneda entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                List<Moneda> Lista = Contexto.Monedas.Where(x => x.Equals(entidad)).ToList();
                return Lista.Count() != 0;
            }
        }
    }
}
