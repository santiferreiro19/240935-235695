using System.Collections.Generic;

namespace Obligatorio_1___DA1
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public string Mes { get; set; }
        public List<MontoCategoria> PresupuestosCategorias { get; set; }
        public Presupuesto()
        {
            this.Año = 0;
            this.Mes = "";
            this.PresupuestosCategorias = new List<MontoCategoria>();
        }

        public Presupuesto(int unAño, string unMes, List<MontoCategoria> unPresupuestoCategorias)
        {
            this.Año = unAño;
            this.Mes = unMes;
            this.PresupuestosCategorias = unPresupuestoCategorias;
        }
        public List<MontoCategoria> getPresupuestosCategorias()
        {
            return this.PresupuestosCategorias;

        }
        public void setPresupuestosCategorias(List<MontoCategoria> ListaMontos)
        {
            this.PresupuestosCategorias = ListaMontos;

        }
        override
             public string ToString()
        {
            return this.Mes + " " + this.Año;
        }
    }
}
