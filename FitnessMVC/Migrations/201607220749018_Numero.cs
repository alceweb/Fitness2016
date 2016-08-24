namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Numero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Allenamentis", "Numero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Allenamentis", "Numero");
        }
    }
}
