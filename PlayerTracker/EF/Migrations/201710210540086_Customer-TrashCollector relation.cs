namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTrashCollectorrelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrashCollection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CollectorId = c.Int(nullable: false),
                        CustomerStatus = c.String(maxLength: 100),
                        CustomerStatusModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CollectorStatus = c.String(maxLength: 100),
                        CollectorStatusModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrashCollector", t => t.CollectorId, cascadeDelete: false)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.CollectorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrashCollection", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.TrashCollection", "CollectorId", "dbo.TrashCollector");
            DropIndex("dbo.TrashCollection", new[] { "CollectorId" });
            DropIndex("dbo.TrashCollection", new[] { "CustomerId" });
            DropTable("dbo.TrashCollection");
        }
    }
}
