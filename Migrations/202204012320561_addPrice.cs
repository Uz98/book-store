namespace Bookly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Price");
        }
    }
}
