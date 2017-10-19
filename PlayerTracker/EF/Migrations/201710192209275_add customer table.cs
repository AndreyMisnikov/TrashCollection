namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcustomertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 100),
                        ZipCode = c.Int(nullable: false),
                        WeekDays = c.String(maxLength: 100),
                        NotCollectFrom = c.DateTime(),
                        NotCollectTo = c.DateTime(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.TrashCollector", "MonthlyPayment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Customer", new[] { "UserId" });
            AlterColumn("dbo.TrashCollector", "MonthlyPayment", c => c.Double(nullable: false));
            DropTable("dbo.Customer");
        }
    }
}
