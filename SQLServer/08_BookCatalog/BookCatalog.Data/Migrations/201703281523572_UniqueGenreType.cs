namespace BookCatalog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueGenreType : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Genres", "Type", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Genres", new[] { "Type" });
        }
    }
}
