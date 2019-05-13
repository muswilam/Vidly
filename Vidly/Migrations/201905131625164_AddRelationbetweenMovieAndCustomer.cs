namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationbetweenMovieAndCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MovieId", c => c.Int());
            CreateIndex("dbo.Customers", "MovieId");
            AddForeignKey("dbo.Customers", "MovieId", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MovieId", "dbo.Movies");
            DropIndex("dbo.Customers", new[] { "MovieId" });
            DropColumn("dbo.Customers", "MovieId");
        }
    }
}
