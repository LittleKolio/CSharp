namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeToClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Age");
        }
    }
}
