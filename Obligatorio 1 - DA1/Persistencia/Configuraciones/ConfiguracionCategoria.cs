using Obligatorio_1___DA1;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Configuraciones
{
    public class ConfiguracionCategoria : EntityTypeConfiguration<Categoria>
    {
        public ConfiguracionCategoria()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Nombre).HasMaxLength(15);
            this.Property(x => x.Nombre).IsRequired();
        }
    }
}
