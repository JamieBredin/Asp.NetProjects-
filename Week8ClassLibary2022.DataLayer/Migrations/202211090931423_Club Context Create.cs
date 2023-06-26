namespace Week8ClassLibary2022.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClubContextCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClubEvent",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Venue = c.String(),
                        Location = c.String(),
                        ClubId = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Club", t => t.ClubId)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        ClubName = c.String(),
                        CreationDate = c.DateTime(nullable: false, storeType: "date"),
                        adminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClubId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClubEvent", "ClubId", "dbo.Club");
            DropIndex("dbo.ClubEvent", new[] { "ClubId" });
            DropTable("dbo.Club");
            DropTable("dbo.ClubEvent");
        }
    }
}
