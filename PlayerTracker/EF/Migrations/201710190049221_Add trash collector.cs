namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtrashcollector : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrashCollector",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekDays = c.String(maxLength: 100),
                        ZipCodes = c.String(nullable: false, maxLength: 100),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        MonthlyPayment = c.Double(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrashCollector", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.TrashCollector", new[] { "UserId" });
            DropTable("dbo.TrashCollector");
        }
    }
}
