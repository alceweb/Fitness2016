namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schede1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Allenamentis", "Scheda_Id", "dbo.Schedes");
            DropIndex("dbo.Allenamentis", new[] { "Scheda_Id" });
            DropIndex("dbo.Schedes", new[] { "User_Id" });
            AlterColumn("dbo.Allenamentis", "Scheda_Id", c => c.String());
            AlterColumn("dbo.Schedes", "User_Id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedes", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Allenamentis", "Scheda_Id", c => c.Int());
            CreateIndex("dbo.Schedes", "User_Id");
            CreateIndex("dbo.Allenamentis", "Scheda_Id");
            AddForeignKey("dbo.Allenamentis", "Scheda_Id", "dbo.Schedes", "Id");
            AddForeignKey("dbo.Schedes", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
