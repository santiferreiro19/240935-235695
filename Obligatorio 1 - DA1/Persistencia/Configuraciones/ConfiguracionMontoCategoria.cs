using Obligatorio_1___DA1;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
