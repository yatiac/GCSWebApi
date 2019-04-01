namespace GCSApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mechanics",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Plate = c.String(),
                        Maker = c.String(),
                        Model = c.String(),
                        Color = c.String(),
                        VIN = c.String(),
                        Year = c.Int(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Mechanic_Id = c.String(maxLength: 128),
                        Status_Id = c.String(maxLength: 128),
                        Type_Id = c.String(maxLength: 128),
                        Vehicle_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mechanics", t => t.Mechanic_Id)
                .ForeignKey("dbo.WorkOrderStatus", t => t.Status_Id)
                .ForeignKey("dbo.WorkOrderTypes", t => t.Type_Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Mechanic_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Type_Id)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.WorkOrderStatus",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkOrderTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Comments = c.String(),
                        WorkOrder_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrder_Id)
                .Index(t => t.WorkOrder_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "WorkOrder_Id", "dbo.WorkOrders");
            DropForeignKey("dbo.WorkOrders", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.WorkOrders", "Type_Id", "dbo.WorkOrderTypes");
            DropForeignKey("dbo.WorkOrders", "Status_Id", "dbo.WorkOrderStatus");
            DropForeignKey("dbo.WorkOrders", "Mechanic_Id", "dbo.Mechanics");
            DropForeignKey("dbo.Vehicles", "Owner_Id", "dbo.Owners");
            DropIndex("dbo.Works", new[] { "WorkOrder_Id" });
            DropIndex("dbo.WorkOrders", new[] { "Vehicle_Id" });
            DropIndex("dbo.WorkOrders", new[] { "Type_Id" });
            DropIndex("dbo.WorkOrders", new[] { "Status_Id" });
            DropIndex("dbo.WorkOrders", new[] { "Mechanic_Id" });
            DropIndex("dbo.Vehicles", new[] { "Owner_Id" });
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
