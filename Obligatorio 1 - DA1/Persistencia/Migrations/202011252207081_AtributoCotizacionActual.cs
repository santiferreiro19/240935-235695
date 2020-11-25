namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtributoCotizacionActual : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gastoes", "CotizacionActual", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gastoes", "CotizacionActual");
        }
    }
}
