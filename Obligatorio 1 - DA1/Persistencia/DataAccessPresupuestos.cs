using Obligatorio_1___DA1;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    public class DataAccessPresupuestos : IDataAccess<Presupuesto>
    {
        public void Add(Presupuesto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                foreach (MontoCategoria monto in entidad.PresupuestosCategorias)
                {
                    Contexto.Entry(monto.Cat).State = EntityState.Unchanged;

                }
                Contexto.Presupuestos.Add(entidad);
                Contexto.SaveChanges();
            }
        }
        public void Remove(Presupuesto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.Presupuestos.Remove(entidad);
                Contexto.SaveChanges();
            }
        }

        public Presupuesto Get(int id)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Presupuestos.Include("PresupuestosCategorias.Cat").FirstOrDefault(u => u.Id == id);
            }
        }

        public List<Presupuesto> GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Presupuestos.Include("PresupuestosCategorias.Cat").ToList();
            }
        }

        public bool Contains(Presupuesto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                List<Presupuesto> Lista = Contexto.Presupuestos.Where(x => x.Equals(entidad)).ToList();
                return Lista.Count() != 0;
            }
        }
        public void Update(Presupuesto entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Presupuesto unPresupuesto = Contexto.Presupuestos.Include("PresupuestosCategorias").FirstOrDefault(u => u.Id == entidad.Id);
                unPresupuesto.Año = entidad.Año;
                unPresupuesto.Mes = entidad.Mes;
                for (int i = 0; i < entidad.PresupuestosCategorias.Count; i++)
                {
                    if (i < unPresupuesto.PresupuestosCategorias.Count)
                    {
                        unPresupuesto.PresupuestosCategorias[i].Monto = entidad.PresupuestosCategorias[i].Monto;
                    }
                    else
                    {
                        Contexto.Entry(entidad.PresupuestosCategorias[i].Cat).State = EntityState.Unchanged;
                        unPresupuesto.PresupuestosCategorias.Add(entidad.PresupuestosCategorias[i]);
                    }
                }
                Contexto.Entry(unPresupuesto).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }
    }
}
