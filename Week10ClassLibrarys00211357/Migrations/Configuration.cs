namespace Week10ClassLibrarys00211357.Migrations
{
    using CsvHelper;
    using CsvHelper.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Tracker.WebAPIClient;
    using Week10ClubDomain22;

    internal sealed class Configuration : DbMigrationsConfiguration<Week10ClubDomain22.ClubsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week10ClubDomain22.ClubsContext context)
        {
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "RAD301Week 10Lab2021", Task: "AddingStudentswithRegistrationDates");

            //Get Students and add them to the database
            List<Student> students = new List<Student>();
            students = get_students();
            context.Student.AddOrUpdate(s => new { s.StudentID }, students.ToArray());
            context.SaveChanges();
           

            //getting random students
            List<Student> randomStudents = new List<Student>();
            randomStudents = GetStudents(context, 6);

            //adding clubs, club events and random members to the clubs
           
            //save context
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

       

        private static List<Student> get_students()
        {
            int dayNumber = helper.random.Next(1, 28);
            int monthNumber = helper.random.Next(1, 13);
            int yearNumber = helper.random.Next(2023, 2026);

            // Get the list of DTO records from the resource
            List<StudentDTO> sdto = Get<StudentDTO>("Week10ClassLibrarys00211357.StudentList1.csv");
            List<Student> Students = new List<Student>();
            // iterate over the course DTO records and create course records for each one making the course year an intiger in the process

            //Creating Each Student fpr each one in the Excel sheet
            sdto.ForEach(rec => {
                Students.Add(
                  new Student
                  {
                      StudentID = rec.StudentID,
                      FirstName = rec.FirstName,
                      SecondName = rec.LastName,
                      DateRegistered = new DateTime(day: DateTime.Now.Day, month: DateTime.Now.Month-helper.random.Next(11), year: DateTime.Now.Year-helper.random.Next(3))
                  }
                  );
            });

            //returning Students
            return Students;

        }
    }
    }

