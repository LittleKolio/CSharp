namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddDefaultAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Age", a => a.Int(nullable: false, defaultValue: 20));
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "Age");
        }
    }
}
