namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intriperizioniseriepesi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Allenamentis", "Serie", c => c.Int(nullable: false));
            AlterColumn("dbo.Allenamentis", "SerieUt", c => c.Int(nullable: false));
            AlterColumn("dbo.Allenamentis", "Ripetizioni", c => c.Int(nullable: false));
            AlterColumn("dbo.Allenamentis", "RipetizioniUt", c => c.Int(nullable: false));
            AlterColumn("dbo.Allenamentis", "Peso", c => c.Int(nullable: false));
            AlterColumn("dbo.Allenamentis", "PesoUt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Allenamentis", "PesoUt", c => c.String());
            AlterColumn("dbo.Allenamentis", "Peso", c => c.String());
            AlterColumn("dbo.Allenamentis", "RipetizioniUt", c => c.String());
            AlterColumn("dbo.Allenamentis", "Ripetizioni", c => c.String());
            AlterColumn("dbo.Allenamentis", "SerieUt", c => c.String());
            AlterColumn("dbo.Allenamentis", "Serie", c => c.String());
        }
    }
}
