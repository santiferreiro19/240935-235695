using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1
{
    public class Presupuesto
    {
        public int Anio { set; get; }
        public String Mes { set; get; }
        public Dictionary<string, decimal> PresupuestosCategorias;
        public Presupuesto()
        {
            this.Anio = 0;
            this.Mes = "";
            Dictionary<string, decimal> PresupuestosCategorias = new Dictionary<string, decimal>();
        }
        public Presupuesto(int UnAnio, String UnMes, Dictionary<string, decimal> UnPresupuestoCategoria )
        {
            this.Anio = UnAnio;
            this.Mes = UnMes;
            this.PresupuestosCategorias = UnPresupuestoCategoria;
        }
    }

}
