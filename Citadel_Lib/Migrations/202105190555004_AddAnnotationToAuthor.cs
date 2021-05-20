namespace Citadel_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToAuthor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.CategoryTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CategoryTypes", "Name", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
        }
    }
}
