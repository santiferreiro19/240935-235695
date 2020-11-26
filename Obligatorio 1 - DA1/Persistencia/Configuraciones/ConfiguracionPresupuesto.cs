using Obligatorio_1___DA1;
using System.Data.Entity.ModelConfiguration;

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
