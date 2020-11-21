using Obligatorio_1___DA1;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    public class DataAccesMontoCategoria : ILista<MontoCategoria>
    {
      
        MontoCategoria ILista<MontoCategoria>.Get(int id)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.PresupuestosCategorias.FirstOrDefault(u => u.Id == id);
            }
        }

        List<MontoCategoria> ILista<MontoCategoria>.GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.PresupuestosCategorias.ToList();
            }
        }

        public void Add(MontoCategoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.PresupuestosCategorias.Add(entidad);
                Contexto.SaveChanges();
            }
        }

        public void Remove(MontoCategoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Contexto.PresupuestosCategorias.Remove(entidad);
                Contexto.SaveChanges();
            }
        }

        public bool Contains(MontoCategoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                MontoCategoria unMonto = Contexto.PresupuestosCategorias.FirstOrDefault(u => u.Id == entidad.Id);
                return unMonto != null;
            }
        }

        public void Update(MontoCategoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                MontoCategoria unMonto = Contexto.PresupuestosCategorias.FirstOrDefault(u => u.Id == entidad.Id);
                unMonto.Monto = entidad.Monto;
                unMonto.Cat = entidad.Cat;
                Contexto.Entry(unMonto).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }
    }
}
