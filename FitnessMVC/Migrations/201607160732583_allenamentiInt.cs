namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allenamentiInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Allenamentis", "Scheda_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Allenamentis", "Scheda_Id", c => c.String());
        }
    }
}
