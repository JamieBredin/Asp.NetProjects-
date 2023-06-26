namespace Week12HealthDomain2223.S00211357.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        DSS = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Specialization = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.DSS);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoctorDSS = c.Int(nullable: false),
                        Name = c.String(),
                        Insurance = c.String(),
                        DateAdmitted = c.DateTime(nullable: false, storeType: "date"),
                        DateCheckedOut = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctor", t => t.DoctorDSS)
                .Index(t => t.DoctorDSS);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient", "DoctorDSS", "dbo.Doctor");
            DropIndex("dbo.Patient", new[] { "DoctorDSS" });
            DropTable("dbo.Patient");
            DropTable("dbo.Doctor");
        }
    }
}
