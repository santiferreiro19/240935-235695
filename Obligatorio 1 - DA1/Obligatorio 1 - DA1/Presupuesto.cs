using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public string Mes { get; set; }
        public List<MontoCategoria> Montos { get; set; }
        private Dictionary<Categoria, decimal> PresupuestosCategorias { get; set; }

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
        public Dictionary<Categoria, decimal> getPresupuestosCategorias() {
            return this.PresupuestosCategorias;

        }
        public void setPresupuestosCategorias(Dictionary<Categoria, decimal> unDiccionario)
        {
             this.PresupuestosCategorias = unDiccionario;

        }
        override
             public string ToString()
        {
            return this.Mes + " " + this.Año;
        }
    }
}
