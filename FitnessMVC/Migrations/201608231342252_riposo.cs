namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class riposo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Allenamentis", "Riposo", c => c.Int(nullable: false));
            AddColumn("dbo.Allenamentis", "RiposoUt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Allenamentis", "RiposoUt");
            DropColumn("dbo.Allenamentis", "Riposo");
        }
    }
}
