namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schedeUt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Allenamentis", "SerieUt", c => c.String());
            AddColumn("dbo.Allenamentis", "RipetizioniUt", c => c.String());
            AddColumn("dbo.Allenamentis", "Peso", c => c.String());
            AddColumn("dbo.Allenamentis", "PesoUt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Allenamentis", "PesoUt");
            DropColumn("dbo.Allenamentis", "Peso");
            DropColumn("dbo.Allenamentis", "RipetizioniUt");
            DropColumn("dbo.Allenamentis", "SerieUt");
        }
    }
}
