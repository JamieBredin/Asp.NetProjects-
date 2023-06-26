namespace RAD3012223Week.ClubDomain.DataLayer.Migrations
{
    using CsvHelper.Configuration;
    using CsvHelper;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Week4ClubDomain22.BusinessModel;

    internal sealed class Configuration : DbMigrationsConfiguration<Week4ClubDomain22.BusinessModel.ClubsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week4ClubDomain22.BusinessModel.ClubsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //get_students instead of students

            //Getting students and courses from the csv files and adding them to database
            List<Student> students = new List<Student>();
            students = get_students();
            context.Student.AddOrUpdate(s => new { s.StudentID }, students.ToArray());
            context.SaveChanges();
            List<Course> courses = new List<Course>();
            courses = get_courses();
            context.Course.AddOrUpdate(c => new { c.CourseCode, c.Year }, courses.ToArray());
            context.SaveChanges();

            //getting random students
            List<Student> randomStudents = new List<Student>();
            randomStudents =GetStudents(context, 6);

            //adding clubs, club events and random members to the clubs
            context.Clubs.AddOrUpdate(club => club.ClubName, new Club[] {
               new Club
               {

                   ClubName = "Club1",
                   CreationDate = new DateTime(day:25, month:01, year:2021),
                   clubMembers = getMembers(context),
                   
                   clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:25, month:02, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:02, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Sligo", Venue="Arena"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:25, month:02, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:02, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="Main Canteen"
                        },
                   }// End of new CLub events
               }, // End of First club added other clubs can be added next

               new Club
               {

                   ClubName = "Club2",
                   CreationDate = new DateTime(day:15, month:02, year:2021),
                   clubMembers = getMembers(context),
                   clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:20, month:03, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:20, month:03, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Sligo", Venue="Knocknarea"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:05, month:06, year:2021).Add(new TimeSpan(1,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:08, month:06, year:2021).Add(new TimeSpan(2,15,0,0,0)),
                            Location = "Cavan", Venue="Bus Station"
                        },
                   }// End of new CLub events
               }, // End of Second club added other clubs can be added next

               new Club
               {

                   ClubName = "Club3",
                   CreationDate = new DateTime(day:01, month:02, year:2021),
                   clubMembers = getMembers(context),
                   clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:10, month:03, year:2021).Add(new TimeSpan(5,8,0,0,0)),
                                        EndDateTime =  new DateTime(day:10, month:03, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        Location = "Dublin", Venue="Arena"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:16, month:10, year:2021).Add(new TimeSpan(2,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:16, month:10, year:2021).Add(new TimeSpan(2,18,0,0,0)),
                            Location = "Sligo", Venue="Main Campus"
                        },
                   }// End of new CLub events
               }, // End of Third club added other clubs can be added next
            } // End of Clubs array
               );// End of Add or Update
            context.SaveChanges();

            List<Club> clubs = context.Clubs.ToList();

            //adding member attendending club events
            List<EventAttendnace> attendances = new List<EventAttendnace>();
            foreach (var club in clubs)
            {
                foreach (var e in club.clubEvents)
                {
                    foreach (var member in club.clubMembers)
                    {
                        attendances.Add(new EventAttendnace
                        {
                            associatedEvent = e,
                            memberAttending = member
                        });
                    }
                   ;
                }

            }
            //adding to database
            context.EventAttendances.AddOrUpdate(
                a => new { a.EventID, a.AttendeeMember },
                attendances.ToArray());
            context.SaveChanges();

        }

        //csv reader
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

        private List<Student> GetStudents(ClubsContext context, int count)
        {
            // Create a random list of student ids
            var randomSetStudent = context.Student.Select(s => new { s.StudentID, r = Guid.NewGuid() });
            // sort them and take 10
            List<string> subset = randomSetStudent.OrderBy(s => s.r)
                .Select(s => s.StudentID.ToString()).Take(count).ToList();
            // return the selected students as a relaized list
            return context.Student.Where(s => subset.Contains(s.StudentID)).ToList();
        }

        private List<Member> getMembers(ClubsContext context)
        {//getting 3 random students and adding them as members
            List<Student> studentMembers = GetStudents(context,3);
            List<Member> members = new List<Member>();
            foreach ( var students in studentMembers)
            {
                members.Add(new Member { StudentID = students.StudentID, approved = false});
            }
            return members;
        }

        private static List<Course> get_courses()
        {
            // Get the list of DTO records from the resource
            List<CourseDTO> cdto = Get<CourseDTO>("RAD3012223Week.ClubDomain.DataLayer.Courses.csv");
            List<Course> Courses = new List<Course>();
            // iterate over the course DTO records and create course records for each one making the course year an intiger in the process
            // Dummy val
            int val;
            cdto.ForEach(rec => {
                Courses.Add(
                  new Course
                  {
                      CourseCode = rec.CourseCode,
                      CourseName = rec.Title,
                      Year = Int32.TryParse(rec.Year.Trim('Y'), out val) ? val : (Int32.TryParse(rec.Year.Trim('A'), out val) ? val : 0)
                  }
                  );
            });

            return Courses;

        }

        private static List<Student> get_students()
        {
            // Get the list of DTO records from the resource
            List<StudentDTO> sdto = Get<StudentDTO>("RAD3012223Week.ClubDomain.DataLayer.StudentList1.csv");
            List<Student> Students = new List<Student>();
            // iterate over the course DTO records and create course records for each one making the course year an intiger in the process
           
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
    }
}
