namespace Citadel_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInBookModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "IBSN", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "IBSN", c => c.Int());
        }
    }
}
