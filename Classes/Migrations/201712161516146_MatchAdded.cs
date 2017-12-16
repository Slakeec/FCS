namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GoalTeamOne = c.Int(nullable: false),
                        FormOne = c.Int(nullable: false),
                        GoalTeamTwo = c.Int(nullable: false),
                        FormTwo = c.Int(nullable: false),
                        Round = c.Int(nullable: false),
                        TeamOne_Id = c.Int(),
                        TeamTwo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamOne_Id)
                .ForeignKey("dbo.Teams", t => t.TeamTwo_Id)
                .Index(t => t.TeamOne_Id)
                .Index(t => t.TeamTwo_Id);
            
            AddColumn("dbo.Players", "Match_Id", c => c.Int());
            AddColumn("dbo.Players", "Match_Id1", c => c.Int());
            CreateIndex("dbo.Players", "Match_Id");
            CreateIndex("dbo.Players", "Match_Id1");
            AddForeignKey("dbo.Players", "Match_Id", "dbo.Matches", "Id");
            AddForeignKey("dbo.Players", "Match_Id1", "dbo.Matches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "TeamTwo_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "TeamOne_Id", "dbo.Teams");
            DropForeignKey("dbo.Players", "Match_Id1", "dbo.Matches");
            DropForeignKey("dbo.Players", "Match_Id", "dbo.Matches");
            DropIndex("dbo.Players", new[] { "Match_Id1" });
            DropIndex("dbo.Players", new[] { "Match_Id" });
            DropIndex("dbo.Matches", new[] { "TeamTwo_Id" });
            DropIndex("dbo.Matches", new[] { "TeamOne_Id" });
            DropColumn("dbo.Players", "Match_Id1");
            DropColumn("dbo.Players", "Match_Id");
            DropTable("dbo.Matches");
        }
    }
}
