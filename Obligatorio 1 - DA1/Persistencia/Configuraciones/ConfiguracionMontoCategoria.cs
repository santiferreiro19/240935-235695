using Obligatorio_1___DA1;
using System.Data.Entity.ModelConfiguration;

namespace Persistencia.Configuraciones
{
    public class ConfiguracionMontoCategoria : EntityTypeConfiguration<MontoCategoria>
    {
        public ConfiguracionMontoCategoria()
        {
            this.HasKey(x => x.Id);
        }
    }
}
