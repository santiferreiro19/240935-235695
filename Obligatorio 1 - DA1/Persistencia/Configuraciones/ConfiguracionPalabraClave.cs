using Obligatorio_1___DA1;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
