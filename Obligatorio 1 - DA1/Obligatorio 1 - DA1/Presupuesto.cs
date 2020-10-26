using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1
{
    public class Presupuesto
    {
        public int Año { get; set; }
        public string Mes { get; set; }
        public Dictionary<Categoria, decimal> PresupuestosCategorias { get; set; }

        public Presupuesto()
        {
            this.Año = 0;
            this.Mes = "";
            this.PresupuestosCategorias = new Dictionary<Categoria, decimal>();
        }

        public Presupuesto(int unAño, string unMes, Dictionary<Categoria, decimal> unPresupuestoCategorias)
        {
            this.Año = unAño;
            this.Mes = unMes;
            this.PresupuestosCategorias = unPresupuestoCategorias;
        }
    }
}
