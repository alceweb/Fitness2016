namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class esercizi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Esercizis",
                c => new
                    {
                        Esercizio_Id = c.Int(nullable: false, identity: true),
                        Descrizione = c.String(),
                    })
                .PrimaryKey(t => t.Esercizio_Id);
            
            AddColumn("dbo.Allenamentis", "Esercizio_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Allenamentis", "Esercizio_Id");
            AddForeignKey("dbo.Allenamentis", "Esercizio_Id", "dbo.Esercizis", "Esercizio_Id", cascadeDelete: true);
            DropColumn("dbo.Allenamentis", "Esercizio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Allenamentis", "Esercizio", c => c.String());
            DropForeignKey("dbo.Allenamentis", "Esercizio_Id", "dbo.Esercizis");
            DropIndex("dbo.Allenamentis", new[] { "Esercizio_Id" });
            DropColumn("dbo.Allenamentis", "Esercizio_Id");
            DropTable("dbo.Esercizis");
        }
    }
}
