namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreValues : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id , GenreName) values (1 , 'Action')");
            Sql("Insert into Genres (Id , GenreName) values (2 , 'Drama')");
            Sql("Insert into Genres (Id , GenreName) values (3 , 'Comedy')");
            Sql("Insert into Genres (Id , GenreName) values (4 , 'Fantasy')");
            Sql("Insert into Genres (Id , GenreName) values (5 , 'History')");

        }
        
        public override void Down()
        {
        }
    }
}
