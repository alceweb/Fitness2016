namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAllenamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Allenamentis", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Allenamentis", "Data");
        }
    }
}
