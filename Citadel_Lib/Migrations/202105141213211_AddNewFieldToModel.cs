namespace Citadel_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldToModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PublishedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "PurchaseDate", c => c.DateTime());
            AddColumn("dbo.Books", "NumberofTimeIssued", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rentals", "RentedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rentals", "ReturnedDate", c => c.DateTime());
            AddColumn("dbo.Users", "JoinedDate", c => c.DateTime());
            AddColumn("dbo.Users", "LeaveDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LeaveDate");
            DropColumn("dbo.Users", "JoinedDate");
            DropColumn("dbo.Rentals", "ReturnedDate");
            DropColumn("dbo.Rentals", "RentedDate");
            DropColumn("dbo.Books", "IsAvailable");
            DropColumn("dbo.Books", "NumberofTimeIssued");
            DropColumn("dbo.Books", "PurchaseDate");
            DropColumn("dbo.Books", "PublishedDate");
        }
    }
}
