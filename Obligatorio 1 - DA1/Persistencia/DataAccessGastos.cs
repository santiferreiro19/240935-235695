using Obligatorio_1___DA1;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    public class DataAccessGastos : IDataAccess<Gasto>
    {
        public void Add(Gasto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Entry(entidad.Categoria).State = EntityState.Unchanged;
                Contexto.Entry(entidad.Moneda).State = EntityState.Unchanged;
                Contexto.Gastos.Add(entidad);
                Contexto.SaveChanges();
            }
        }
        public void Remove(Gasto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Gasto unGasto = Contexto.Gastos.Include("Categoria").Include("Moneda").FirstOrDefault(u => u.Id == entidad.Id);
                Contexto.Entry(unGasto.Categoria).State = EntityState.Unchanged;
                Contexto.Entry(unGasto.Moneda).State = EntityState.Unchanged;
                Contexto.Gastos.Remove(unGasto);
                Contexto.SaveChanges();
            }
        }

        public Gasto Get(int id)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Gasto unGasto = Contexto.Gastos.Include("Categoria").Include("Moneda").FirstOrDefault(u => u.Id == id);
                return unGasto;
            }
        }

        public List<Gasto> GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Gastos.Include("Categoria").Include("Moneda").ToList();
            }
        }

        public bool Contains(Gasto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Gasto unGasto = Contexto.Gastos.FirstOrDefault(u => u.Id == entidad.Id);
                return unGasto != null;
            }
        }
        public void Update(Gasto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Gasto unGasto = Contexto.Gastos.SingleOrDefault(u => u.Id == entidad.Id);
                unGasto.Descripcion = entidad.Descripcion;
                Contexto.Entry(entidad.Categoria).State = EntityState.Unchanged;
                Contexto.Entry(entidad.Moneda).State = EntityState.Unchanged;
                unGasto.Categoria = entidad.Categoria;
                unGasto.Fecha = entidad.Fecha;
                unGasto.Moneda = entidad.Moneda;
                unGasto.Monto = entidad.Monto;
                Contexto.Entry(unGasto).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }
    }
}
