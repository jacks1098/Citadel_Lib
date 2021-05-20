namespace Citadel_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CageIModelBook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CategoryType_Id", "dbo.CategoryTypes");
            DropIndex("dbo.Books", new[] { "CategoryType_Id" });
            RenameColumn(table: "dbo.Books", name: "CategoryType_Id", newName: "CategoryTypeId");
            AlterColumn("dbo.Books", "CategoryTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "CategoryTypeId");
            AddForeignKey("dbo.Books", "CategoryTypeId", "dbo.CategoryTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Books", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Books", "CategoryTypeId", "dbo.CategoryTypes");
            DropIndex("dbo.Books", new[] { "CategoryTypeId" });
            AlterColumn("dbo.Books", "CategoryTypeId", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "CategoryTypeId", newName: "CategoryType_Id");
            CreateIndex("dbo.Books", "CategoryType_Id");
            AddForeignKey("dbo.Books", "CategoryType_Id", "dbo.CategoryTypes", "Id");
        }
    }
}
