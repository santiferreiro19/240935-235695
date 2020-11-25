using Obligatorio_1___DA1;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    public class DataAccessMonedas : IDataAccess<Moneda>
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
                Moneda unaMoneda = Contexto.Monedas.FirstOrDefault(u => u.Id == entidad.Id);
                Contexto.Monedas.Remove(unaMoneda);
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
                Moneda unaMoneda = Contexto.Monedas.FirstOrDefault(u => u.Id == entidad.Id);
                return unaMoneda != null;
            }
        }
        public void Update(Moneda unaMoneda)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Moneda monedaEnBd = Contexto.Monedas.FirstOrDefault(u => u.Id == unaMoneda.Id);
                monedaEnBd.Cotizacion = unaMoneda.Cotizacion;
                monedaEnBd.Nombre = unaMoneda.Nombre;
                monedaEnBd.Simbolo = unaMoneda.Simbolo;
                Contexto.Entry(monedaEnBd).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }
    }
}
