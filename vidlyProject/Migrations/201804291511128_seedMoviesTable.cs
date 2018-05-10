namespace vidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, Stock) VALUES('Die Hard', 'Action', '1/1/15', '2/2/16', 4)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, Stock) VALUES('Dr. Doolittle', 'Comedy', '1/1/17', '2/2/18', 3)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, Stock) VALUES('Jumanji', 'Action', '1/20/15', '2/16/16', 8)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, Stock) VALUES('Remember the Titans', 'Drama', '5/1/15', '8/2/16', 2)");
        }
        
        public override void Down()
        {
        }
    }
}
