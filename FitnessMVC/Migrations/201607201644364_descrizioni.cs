namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class descrizioni : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Allenamentis", "Descrizione", c => c.String());
            AddColumn("dbo.Schedes", "Descrizione", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedes", "Descrizione");
            DropColumn("dbo.Allenamentis", "Descrizione");
        }
    }
}
