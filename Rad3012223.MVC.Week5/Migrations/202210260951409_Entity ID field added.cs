namespace Rad3012223.MVC.Week5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityIDfieldadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EntityID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EntityID");
        }
    }
}
