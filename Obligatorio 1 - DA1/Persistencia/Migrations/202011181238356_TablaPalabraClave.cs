namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaPalabraClave : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gastoes", "Moneda_Id", "dbo.Monedas");
            DropIndex("dbo.Gastoes", new[] { "Moneda_Id" });
            DropColumn("dbo.Gastoes", "Moneda_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gastoes", "Moneda_Id", c => c.Int());
            CreateIndex("dbo.Gastoes", "Moneda_Id");
            AddForeignKey("dbo.Gastoes", "Moneda_Id", "dbo.Monedas", "Id");
        }
    }
}
