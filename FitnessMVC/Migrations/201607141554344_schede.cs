namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schede : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allenamentis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GruppoMuscolare = c.String(),
                        Esercizio = c.String(),
                        Serie = c.String(),
                        Ripetizioni = c.String(),
                        Scheda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedes", t => t.Scheda_Id)
                .Index(t => t.Scheda_Id);
            
            CreateTable(
                "dbo.Schedes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Allenamentis", "Scheda_Id", "dbo.Schedes");
            DropForeignKey("dbo.Schedes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Schedes", new[] { "User_Id" });
            DropIndex("dbo.Allenamentis", new[] { "Scheda_Id" });
            DropTable("dbo.Schedes");
            DropTable("dbo.Allenamentis");
        }
    }
}
