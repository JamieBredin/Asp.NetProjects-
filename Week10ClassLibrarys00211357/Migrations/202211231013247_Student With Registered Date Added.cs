namespace Week10ClassLibrarys00211357.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentWithRegisteredDateAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        DateRegistered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
        }
    }
}
