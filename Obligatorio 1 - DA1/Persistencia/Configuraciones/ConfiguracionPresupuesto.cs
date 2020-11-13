using Obligatorio_1___DA1;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Configuraciones
{
    public class ConfiguracionPresupuesto : EntityTypeConfiguration<Presupuesto>
    {
        public ConfiguracionPresupuesto()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Mes).IsRequired();
            this.Property(x => x.Año).IsRequired();
        }
    }
}
