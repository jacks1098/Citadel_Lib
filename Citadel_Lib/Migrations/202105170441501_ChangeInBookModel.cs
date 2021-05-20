namespace Citadel_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInBookModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "IBSN", c => c.Int());
            AlterColumn("dbo.Books", "Price", c => c.Single());
            AlterColumn("dbo.Books", "PublishedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "PublishedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Books", "IBSN", c => c.Int(nullable: false));
        }
    }
}
