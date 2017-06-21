namespace KursachV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Responsible = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiverId = c.Int(),
                        ScrapId = c.Int(),
                        ArravingDate = c.DateTime(),
                        Cost = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        StoreId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receivers", t => t.ReceiverId)
                .ForeignKey("dbo.Scraps", t => t.ScrapId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.ReceiverId)
                .Index(t => t.ScrapId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirmTitle = c.String(),
                        CompanyCode = c.String(),
                        Address = c.String(),
                        Telephone = c.String(),
                        Account = c.String(),
                        ContactPerson = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scraps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Amount = c.Double(nullable: false),
                        Density = c.Int(nullable: false),
                        Description = c.String(),
                        StoreId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Arraivings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(),
                        ScrapId = c.Int(),
                        ArravingDate = c.DateTime(),
                        Cost = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        StoreId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .ForeignKey("dbo.Scraps", t => t.ScrapId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.ProviderId)
                .Index(t => t.ScrapId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PassportCode = c.String(),
                        Address = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Arraivings", new[] { "StoreId" });
            DropIndex("dbo.Arraivings", new[] { "ScrapId" });
            DropIndex("dbo.Arraivings", new[] { "ProviderId" });
            DropIndex("dbo.Scraps", new[] { "StoreId" });
            DropIndex("dbo.Consumptions", new[] { "StoreId" });
            DropIndex("dbo.Consumptions", new[] { "ScrapId" });
            DropIndex("dbo.Consumptions", new[] { "ReceiverId" });
            DropForeignKey("dbo.Arraivings", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Arraivings", "ScrapId", "dbo.Scraps");
            DropForeignKey("dbo.Arraivings", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.Scraps", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Consumptions", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Consumptions", "ScrapId", "dbo.Scraps");
            DropForeignKey("dbo.Consumptions", "ReceiverId", "dbo.Receivers");
            DropTable("dbo.Providers");
            DropTable("dbo.Arraivings");
            DropTable("dbo.Scraps");
            DropTable("dbo.Receivers");
            DropTable("dbo.Consumptions");
            DropTable("dbo.Stores");
        }
    }
}
