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
<<<<<<< HEAD
                return Contexto.Montos.FirstOrDefault(u => u.Id == id);
=======
                return Contexto.PresupuestosCategorias.Include("Cat").FirstOrDefault(u => u.Id == id);
>>>>>>> feature/RefactorParaTrabajarConEF
            }
        }

        List<MontoCategoria> ILista<MontoCategoria>.GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
<<<<<<< HEAD
                return Contexto.Montos.ToList();
=======
                return Contexto.PresupuestosCategorias.Include("Cat").ToList();
>>>>>>> feature/RefactorParaTrabajarConEF
            }
        }

        public void Add(MontoCategoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
<<<<<<< HEAD
                Contexto.Montos.Add(entidad);
=======
                Contexto.PresupuestosCategorias.Add(entidad);
>>>>>>> feature/RefactorParaTrabajarConEF
                Contexto.SaveChanges();
            }
        }

        public void Remove(MontoCategoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
<<<<<<< HEAD
                Contexto.Montos.Remove(entidad);
=======
                Contexto.PresupuestosCategorias.Remove(entidad);
>>>>>>> feature/RefactorParaTrabajarConEF
                Contexto.SaveChanges();
            }
        }

        public bool Contains(MontoCategoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
<<<<<<< HEAD
                MontoCategoria unMonto = Contexto.Montos.FirstOrDefault(u => u.Id == entidad.Id);
=======
                MontoCategoria unMonto = Contexto.PresupuestosCategorias.FirstOrDefault(u => u.Id == entidad.Id);
>>>>>>> feature/RefactorParaTrabajarConEF
                return unMonto != null;
            }
        }

        public void Update(MontoCategoria entidad)
        {
            using (var Contexto = new ContextoFinanzas())
            {
<<<<<<< HEAD
                MontoCategoria unMonto = Contexto.Montos.FirstOrDefault(u => u.Id == entidad.Id);
=======
                MontoCategoria unMonto = Contexto.PresupuestosCategorias.FirstOrDefault(u => u.Id == entidad.Id);
>>>>>>> feature/RefactorParaTrabajarConEF
                unMonto.Monto = entidad.Monto;
                unMonto.Cat = entidad.Cat;
                Contexto.Entry(unMonto).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }
    }
}
