using Obligatorio_1___DA1;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
