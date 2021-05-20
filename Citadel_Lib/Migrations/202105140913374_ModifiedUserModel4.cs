namespace Citadel_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedUserModel4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsExistUser", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsExistUser");
        }
    }
}
