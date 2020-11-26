using Obligatorio_1___DA1;
using System.Data.Entity.ModelConfiguration;

namespace Persistencia.Configuraciones
{
    public class ConfiguracionGasto : EntityTypeConfiguration<Gasto>
    {
        public ConfiguracionGasto()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Descripcion).HasMaxLength(20);
            this.Property(x => x.Descripcion).IsRequired();
            this.Property(x => x.Fecha).IsRequired();
            this.Property(x => x.Monto).IsRequired();
        }
    }
}
