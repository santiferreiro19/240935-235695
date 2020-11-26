using Obligatorio_1___DA1;
using System.Data.Entity.ModelConfiguration;

namespace Persistencia.Configuraciones
{
    class ConfiguracionPalabraClave : EntityTypeConfiguration<PalabraClave>
    {
        public ConfiguracionPalabraClave()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Palabra).IsRequired();
        }
    }
}
