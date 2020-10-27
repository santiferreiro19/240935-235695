using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1
{
    public class Gasto
    {
        public String Descripcion { get; set; }
        public decimal Monto { get; set; }
        public Categoria unaCategoria { get; set; }
        public DateTime Fecha { get; set; }
        public Gasto()
        {
            this.Descripcion = "";
            this.Monto = 0;
            this.unaCategoria = new Categoria();
            this.Fecha = new DateTime();
        }

        public Gasto(String unaDescripcion, decimal unMonto, Categoria unaCategoria, DateTime unaFecha)
        {
            this.Descripcion = unaDescripcion;
            this.Monto = unMonto;
            this.unaCategoria = unaCategoria;
            this.Fecha = unaFecha;
        }
      override
      public string ToString()
        {
            return this.Descripcion;
        }
    }
}
