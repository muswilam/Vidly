namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropReleationCustomerMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Customers", new[] { "Movie_Id" });
            DropColumn("dbo.Customers", "Movie_Id");
            DropColumn("dbo.Movies", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Movie_Id");
            AddForeignKey("dbo.Customers", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
