namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionTeam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "Position", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Position");
            DropColumn("dbo.Teams", "Number");
        }
    }
}
