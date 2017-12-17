namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinqToImageAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Picture");
        }
    }
}
