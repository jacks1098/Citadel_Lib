namespace Citadel_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInRentalModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "BookId", "dbo.Books");
            DropIndex("dbo.Rentals", new[] { "BookId" });
            RenameColumn(table: "dbo.Rentals", name: "BookId", newName: "Book_Id");
            AlterColumn("dbo.Rentals", "Book_Id", c => c.Int());
            CreateIndex("dbo.Rentals", "Book_Id");
            AddForeignKey("dbo.Rentals", "Book_Id", "dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Book_Id", "dbo.Books");
            DropIndex("dbo.Rentals", new[] { "Book_Id" });
            AlterColumn("dbo.Rentals", "Book_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Rentals", name: "Book_Id", newName: "BookId");
            CreateIndex("dbo.Rentals", "BookId");
            AddForeignKey("dbo.Rentals", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
