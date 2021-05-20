namespace Citadel_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCopiesCountInBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "CopiesAvailable", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "CopiesAvailable");
        }
    }
}
