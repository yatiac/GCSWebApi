namespace GCSApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mechanics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plate = c.String(),
                        Maker = c.String(),
                        Model = c.String(),
                        Color = c.String(),
                        VIN = c.String(),
                        Year = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TypeId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        MechanicId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        Symptoms = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mechanics", t => t.MechanicId, cascadeDelete: true)
                .ForeignKey("dbo.WorkOrderStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.WorkOrderTypes", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.StatusId)
                .Index(t => t.MechanicId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.WorkOrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkOrderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        WorkOrderId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrderId, cascadeDelete: true)
                .Index(t => t.WorkOrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.WorkOrders", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.WorkOrders", "TypeId", "dbo.WorkOrderTypes");
            DropForeignKey("dbo.WorkOrders", "StatusId", "dbo.WorkOrderStatus");
            DropForeignKey("dbo.WorkOrders", "MechanicId", "dbo.Mechanics");
            DropForeignKey("dbo.Vehicles", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Works", new[] { "WorkOrderId" });
            DropIndex("dbo.WorkOrders", new[] { "VehicleId" });
            DropIndex("dbo.WorkOrders", new[] { "MechanicId" });
            DropIndex("dbo.WorkOrders", new[] { "StatusId" });
            DropIndex("dbo.WorkOrders", new[] { "TypeId" });
            DropIndex("dbo.Vehicles", new[] { "OwnerId" });
            DropTable("dbo.Works");
            DropTable("dbo.WorkOrderTypes");
            DropTable("dbo.WorkOrderStatus");
            DropTable("dbo.WorkOrders");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Owners");
            DropTable("dbo.Mechanics");
        }
    }
}
