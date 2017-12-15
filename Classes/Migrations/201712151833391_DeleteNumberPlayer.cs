namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteNumberPlayer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Number", c => c.Int(nullable: false));
        }
    }
}
