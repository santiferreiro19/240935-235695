namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregoMontoCategoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PalabraClaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Palabra = c.String(nullable: false),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.Gastoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 20),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        Categoria_Id = c.Int(),
                        Moneda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .ForeignKey("dbo.Monedas", t => t.Moneda_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Moneda_Id);
            
            CreateTable(
                "dbo.Monedas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Simbolo = c.String(nullable: false, maxLength: 3),
                        Cotizacion = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MontoCategorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cat_Id = c.Int(),
                        Presupuesto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Cat_Id)
                .ForeignKey("dbo.Presupuestoes", t => t.Presupuesto_Id)
                .Index(t => t.Cat_Id)
                .Index(t => t.Presupuesto_Id);
            
            CreateTable(
                "dbo.Presupuestoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Año = c.Int(nullable: false),
                        Mes = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MontoCategorias", "Presupuesto_Id", "dbo.Presupuestoes");
            DropForeignKey("dbo.MontoCategorias", "Cat_Id", "dbo.Categorias");
            DropForeignKey("dbo.Gastoes", "Moneda_Id", "dbo.Monedas");
            DropForeignKey("dbo.Gastoes", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.PalabraClaves", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.MontoCategorias", new[] { "Presupuesto_Id" });
            DropIndex("dbo.MontoCategorias", new[] { "Cat_Id" });
            DropIndex("dbo.Gastoes", new[] { "Moneda_Id" });
            DropIndex("dbo.Gastoes", new[] { "Categoria_Id" });
            DropIndex("dbo.PalabraClaves", new[] { "Categoria_Id" });
            DropTable("dbo.Presupuestoes");
            DropTable("dbo.MontoCategorias");
            DropTable("dbo.Monedas");
            DropTable("dbo.Gastoes");
            DropTable("dbo.PalabraClaves");
            DropTable("dbo.Categorias");
        }
    }
}
