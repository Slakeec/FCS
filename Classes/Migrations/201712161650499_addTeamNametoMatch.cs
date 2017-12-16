namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTeamNametoMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "TeamName1", c => c.String());
            AddColumn("dbo.Matches", "TeamName2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "TeamName2");
            DropColumn("dbo.Matches", "TeamName1");
        }
    }
}
