namespace Week10ClassLibrarys00211357.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "DateRegistered", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "DateRegistered", c => c.DateTime(nullable: false));
        }
    }
}
