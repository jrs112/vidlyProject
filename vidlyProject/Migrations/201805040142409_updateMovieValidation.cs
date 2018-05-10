namespace vidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovieValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.String());
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String());
        }
    }
}
