namespace CA2___CodeFirst_EF__Shop_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        Building = c.Int(nullable: false),
                        Manufacture_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufactures", t => t.Manufacture_Id)
                .Index(t => t.Manufacture_Id);
            
            CreateTable(
                "dbo.Manufactures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Category_Id = c.Int(),
                        Manufacture_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Manufactures", t => t.Manufacture_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Manufacture_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Adress_Id = c.Int(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresses", t => t.Adress_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Adress_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Orders", "Adress_Id", "dbo.Adresses");
            DropForeignKey("dbo.Products", "Manufacture_Id", "dbo.Manufactures");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Adresses", "Manufacture_Id", "dbo.Manufactures");
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropIndex("dbo.Orders", new[] { "Adress_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Manufacture_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Adresses", new[] { "Manufacture_Id" });
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Manufactures");
            DropTable("dbo.Adresses");
        }
    }
}
