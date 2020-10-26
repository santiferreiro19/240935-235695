using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;


namespace Managers
{
     public class ManagerPresupuesto
    {
        private Repositorio Repo;
        public ManagerPresupuesto(Repositorio unRepo)
        {
            this.Repo = unRepo;
        }
        public void ValidacionAgregarPresupuesto(Presupuesto unPresupuesto)
        {
           /* this.CargarDiccionarioPresupuesto(unPresupuesto.PresupuestosCategorias);
            Repo.AgregarPresupuesto(unPresupuesto);*/
        }
        public void CargarDiccionarioPresupuesto(Presupuesto unPresupuesto) {
            unPresupuesto.PresupuestosCategorias = Repo.GetCategorias().ToDictionary(x=>x.Nombre,x=>0M);

        }
    }
}
