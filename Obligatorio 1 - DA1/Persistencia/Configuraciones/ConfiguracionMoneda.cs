using Obligatorio_1___DA1;
using System.Data.Entity.ModelConfiguration;

namespace Persistencia.Configuraciones
{
    public class ConfiguracionMoneda : EntityTypeConfiguration<Moneda>
    {
        public ConfiguracionMoneda()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Nombre).HasMaxLength(20);
            this.Property(x => x.Simbolo).HasMaxLength(3);
            this.Property(x => x.Nombre).IsRequired();
            this.Property(x => x.Simbolo).IsRequired();
            this.Property(x => x.Cotizacion).IsRequired();
        }
    }
}
