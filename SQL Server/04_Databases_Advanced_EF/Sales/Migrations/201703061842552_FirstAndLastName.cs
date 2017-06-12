namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstAndLastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FistName", c => c.String());
            AddColumn("dbo.Customers", "LastName", c => c.String());
            DropColumn("dbo.Customers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "FistName");
        }
    }
}
