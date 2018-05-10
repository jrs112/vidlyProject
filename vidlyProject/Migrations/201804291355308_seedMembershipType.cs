namespace vidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Type = 'Ongoing' WHERE Id=1");
            Sql("Update MembershipTypes SET Type = 'Weekly' WHERE Id=2");
            Sql("Update MembershipTypes SET Type = 'Monthly' WHERE Id=3");
            Sql("Update MembershipTypes SET Type = 'Yearly' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
