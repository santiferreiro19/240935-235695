﻿using Obligatorio_1___DA1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                Gasto unGasto = Contexto.Gastos.FirstOrDefault(u => u.Id == entidad.Id);
                Contexto.Gastos.Remove(unGasto);
                Contexto.SaveChanges();
            }
        }

        public Gasto Get(int id)
        {
            using (var Contexto = new ContextoFinanzas())
            {
                Gasto unGasto = Contexto.Gastos.Include("Categoria").FirstOrDefault(u => u.Id == id);
                return unGasto;
            }
        }

        public List<Gasto> GetAll()
        {
            using (var Contexto = new ContextoFinanzas())
            {
                return Contexto.Gastos.Include("Categoria").ToList();
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
                Gasto unGasto = Contexto.Gastos.FirstOrDefault(u => u.Id == entidad.Id);
                unGasto.Descripcion = entidad.Descripcion;
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
