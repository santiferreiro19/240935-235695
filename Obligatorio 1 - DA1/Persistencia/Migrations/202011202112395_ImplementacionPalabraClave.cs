namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImplementacionPalabraClave : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PalabraClaves", "Palabra", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PalabraClaves", "Palabra", c => c.String());
        }
    }
}
