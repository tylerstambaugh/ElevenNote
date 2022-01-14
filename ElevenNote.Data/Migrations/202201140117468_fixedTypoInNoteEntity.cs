namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedTypoInNoteEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Note", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Note", "OwenrId");
            DropColumn("dbo.Note", "MedifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "MedifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Note", "OwenrId", c => c.Guid(nullable: false));
            DropColumn("dbo.Note", "ModifiedUtc");
            DropColumn("dbo.Note", "OwnerId");
        }
    }
}
