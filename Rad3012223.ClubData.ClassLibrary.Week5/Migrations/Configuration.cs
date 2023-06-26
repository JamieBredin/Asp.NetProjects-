namespace Rad3012223.ClubData.ClassLibrary.Week5.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Tracker.WebAPIClient;
    using CsvHelper.Configuration;
    using CsvHelper;
    using System.Globalization;
    using RAD3012223Week5;

    internal sealed class Configuration : DbMigrationsConfiguration<Week5ClubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week5ClubContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "RAD301 Week5Lab 2223", Task: "Seeding Clubs and Member Data");

            //Getting Students from StudentList1.csv File and adding to database
            List<Student> students = get_students();
            context.Student.AddOrUpdate(s => new { s.StudentID }, students.ToArray());
            context.SaveChanges();

            //creating new club and seeding members to it
            context.Clubs.AddOrUpdate(club => club.ClubName, new Club[] {
               new Club
               {
                   ClubName = "Chess Club",
                   CreationDate = new DateTime(day:25, month:01, year:2021),
                   clubMembers = SeedMembers(context),// End of new club members
                   
                   

        }, // End of First club added other clubs added next

                new Club
               {
                   ClubName = "Table Tennis Club",
                   CreationDate = new DateTime(day:10, month:02, year:2021),
                   clubMembers = SeedMembers(context),// End of new club members
        }, 
                  new Club
               {
                   ClubName = "GDSC Club",
                   CreationDate = new DateTime(day:10, month:02, year:2021),
                   clubMembers = SeedMembers(context),// End of new club members
        }, 
            } // End of Clubs array
              );// End of Add or Update
            context.SaveChanges();
            List<Club> clubs = context.Clubs.ToList();
            foreach (Club club in clubs)
            {
                club.adminID = club.clubMembers.First().MemberID;//getting first club's first member and making its member ID an AdminID

            }
            context.SaveChanges();
            //saving changes
        }

        private static List<Student> get_students()
        {//Getting all Students from csv file and then adding them to Student DTO which adds them to the Database
            // Get the list of DTO records from the resource
            List<StudentDTO> sdto = Get<StudentDTO>("Rad3012223.ClubData.ClassLibrary.Week5.StudentList1.csv");

            List<Student> Students = new List<Student>();

            sdto.ForEach(rec => {
                Students.Add(
                  new Student
                  {
                      StudentID = rec.StudentID,
                      FirstName = rec.FirstName,
                      SecondName = rec.LastName
                  }
                  );
            });
            
            return Students;

        }
        
        //Csv reader
        public static List<T> Get<T>(string resourceName)
        {
            // Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {   // create a stream reader
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                    { HasHeaderRecord = false };
                    // create a csv reader dor the stream
                    CsvReader csvReader = new CsvReader(reader, configuration);
                    return csvReader.GetRecords<T>().ToList();
                }
            }
        }

        private List<Member> SeedMembers(Week5ClubContext context)
        {//This method will get 10 students and make them members while making the first member approved as true
            int counter = 0;
            List<Student> studentMembers = getStudents(context, 10);
            List<Member> members = new List<Member>();
            foreach (var students in studentMembers)
            {
                if(counter ==0)
                {
                    members.Add(new Member { StudentID = students.StudentID, approved = true });

                    counter++;
                }
                else
                {
                    members.Add(new Member { StudentID = students.StudentID, approved = false });
                }
            }
            return members;
        }

        private List<Student> getStudents(Week5ClubContext context, int count)
        {//This methid is getting the first 10 students 
            var student = context.Student.Select(s => new { s.StudentID});

            List<string> subset = student.Select(s => s.StudentID.ToString()).Take(count).ToList();

            return context.Student.Where(s => subset.Contains(s.StudentID)).ToList();
        }

    }
}
