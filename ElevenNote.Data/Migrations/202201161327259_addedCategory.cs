namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        CatLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            AddColumn("dbo.Note", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "CategoryID");
            AddForeignKey("dbo.Note", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "CategoryID", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryID" });
            DropColumn("dbo.Note", "CategoryID");
            DropTable("dbo.Category");
        }
    }
}
