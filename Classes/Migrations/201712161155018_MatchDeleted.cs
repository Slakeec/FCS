namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "TeamOne_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "TeamTwo_Id", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "TeamOne_Id" });
            DropIndex("dbo.Matches", new[] { "TeamTwo_Id" });
            AddColumn("dbo.Teams", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "Games", c => c.Int(nullable: false));
            DropTable("dbo.Matches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.String(),
                        GoalTeamOne = c.Int(nullable: false),
                        GoalTeamTwo = c.Int(nullable: false),
                        TeamOne_Id = c.Int(),
                        TeamTwo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Players", "Games");
            DropColumn("dbo.Teams", "Rating");
            CreateIndex("dbo.Matches", "TeamTwo_Id");
            CreateIndex("dbo.Matches", "TeamOne_Id");
            AddForeignKey("dbo.Matches", "TeamTwo_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Matches", "TeamOne_Id", "dbo.Teams", "Id");
        }
    }
}
