﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1
{
    public class Gasto
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public decimal Monto { get; set; }
        public Moneda Moneda { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime Fecha { get; set; }
        public Gasto()
        {
            this.Descripcion = "";
            this.Monto = 0;
            this.Categoria = new Categoria();
            this.Fecha = new DateTime();
            this.Moneda = new Moneda();
        }

        public Gasto(String unaDescripcion, decimal unMonto, Categoria unaCategoria, DateTime unaFecha, Moneda unaMoneda)
        {
            this.Descripcion = unaDescripcion;
            this.Monto = unMonto;
            this.Categoria = unaCategoria;
            this.Fecha = unaFecha;
            this.Moneda = unaMoneda;
        }
      override
      public string ToString()
        {
            return "Descripcion: "+this.Descripcion +" Monto: "+ this.Monto +" Categoria: "+ this.Categoria +" Fecha: " + this.Fecha.ToShortDateString() + " Moneda: "+ this.Moneda;
        }
    }
}
