namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchClassChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.Players", "Match_Id1", "dbo.Matches");
            DropForeignKey("dbo.Matches", "TeamOne_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "TeamTwo_Id", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "TeamOne_Id" });
            DropIndex("dbo.Matches", new[] { "TeamTwo_Id" });
            DropIndex("dbo.Players", new[] { "Match_Id" });
            DropIndex("dbo.Players", new[] { "Match_Id1" });
            AddColumn("dbo.Matches", "TeamOne", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "TeamTwo", c => c.Int(nullable: false));
            DropColumn("dbo.Matches", "TeamOne_Id");
            DropColumn("dbo.Matches", "TeamTwo_Id");
            DropColumn("dbo.Players", "Match_Id");
            DropColumn("dbo.Players", "Match_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Match_Id1", c => c.Int());
            AddColumn("dbo.Players", "Match_Id", c => c.Int());
            AddColumn("dbo.Matches", "TeamTwo_Id", c => c.Int());
            AddColumn("dbo.Matches", "TeamOne_Id", c => c.Int());
            DropColumn("dbo.Matches", "TeamTwo");
            DropColumn("dbo.Matches", "TeamOne");
            CreateIndex("dbo.Players", "Match_Id1");
            CreateIndex("dbo.Players", "Match_Id");
            CreateIndex("dbo.Matches", "TeamTwo_Id");
            CreateIndex("dbo.Matches", "TeamOne_Id");
            AddForeignKey("dbo.Matches", "TeamTwo_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Matches", "TeamOne_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Players", "Match_Id1", "dbo.Matches", "Id");
            AddForeignKey("dbo.Players", "Match_Id", "dbo.Matches", "Id");
        }
    }
}
