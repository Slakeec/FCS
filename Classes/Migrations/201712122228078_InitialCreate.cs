namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamOne_Id)
                .ForeignKey("dbo.Teams", t => t.TeamTwo_Id)
                .Index(t => t.TeamOne_Id)
                .Index(t => t.TeamTwo_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Count = c.Int(nullable: false),
                        Games = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        MyTeam = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nationlity = c.String(),
                        MarketPrice = c.String(),
                        Number = c.Int(nullable: false),
                        Position = c.String(),
                        Goals = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "TeamTwo_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "TeamOne_Id", "dbo.Teams");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Matches", new[] { "TeamTwo_Id" });
            DropIndex("dbo.Matches", new[] { "TeamOne_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
        }
    }
}
