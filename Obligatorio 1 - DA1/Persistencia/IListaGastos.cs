using Obligatorio_1___DA1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class IListaGastos : ILista<Gasto>
    {
        public void Add(Gasto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Gastos.Add(entidad);
                Contexto.SaveChanges();
            }
        }
        public void Remove(Gasto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Gastos.Remove(entidad);
                Contexto.SaveChanges();
            }
        }

        public Gasto Get(int id)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Gastos.FirstOrDefault(u => u.Id == id);
            }
        }

        public List<Gasto> GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Gastos.ToList();
            }
        }

        public bool Contains(Gasto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                List<Gasto> Lista = Contexto.Gastos.Where(x => x.Equals(entidad)).ToList();
                return Lista.Count() != 0;
            }
        }
    }
}
