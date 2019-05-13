namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerIdPropertyToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "CustomerId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "CustomerId");
        }
    }
}
