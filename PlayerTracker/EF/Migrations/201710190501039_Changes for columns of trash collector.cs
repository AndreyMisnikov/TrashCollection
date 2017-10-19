namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changesforcolumnsoftrashcollector : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TrashCollector", "StartTime");
            AddColumn("dbo.TrashCollector", "StartTime", c => c.Long(nullable: false));
            DropColumn("dbo.TrashCollector", "EndTime");
            AddColumn("dbo.TrashCollector", "EndTime", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollector", "StartTime");
            AddColumn("dbo.TrashCollector", "StartTime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.TrashCollector", "EndTime");
            AddColumn("dbo.TrashCollector", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
