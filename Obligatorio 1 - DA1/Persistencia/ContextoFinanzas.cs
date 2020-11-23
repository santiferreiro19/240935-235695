using Obligatorio_1___DA1;
using Persistencia.Configuraciones;
using System.Data.Entity;

namespace Persistencia
{
    public class ContextoFinanzas : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<PalabraClave> PalabrasClave { get; set; }
        public DbSet<MontoCategoria> Montos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConfiguracionCategoria());
            modelBuilder.Configurations.Add(new ConfiguracionGasto());
            modelBuilder.Configurations.Add(new ConfiguracionPresupuesto());
            modelBuilder.Configurations.Add(new ConfiguracionMoneda());
            modelBuilder.Configurations.Add(new ConfiguracionPalabraClave());
            modelBuilder.Configurations.Add(new ConfiguracionMontoCategoria());

        }
    }
}
