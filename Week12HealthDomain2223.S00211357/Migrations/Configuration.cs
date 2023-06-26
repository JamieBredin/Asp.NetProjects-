namespace Week12HealthDomain2223.S00211357.Migrations
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
    using Week12HealthDomain2223.S00211357.models;
    using Week12HealthDomain2223.S00211357.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Week12HealthDomain2223.S00211357.models.HealthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week12HealthDomain2223.S00211357.models.HealthContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "Rad301 2223 Week 12 Lab", Task: "Seeding Health Data Model");

            //Creating Doctor List and adding it to the Database
            List<Doctor> doctors = new List<Doctor>();
            doctors = get_doctors();
            context.Doctor.AddOrUpdate(d => new { d.DSS }, doctors.ToArray());
            context.SaveChanges();

            //Creating Patient List and adding it to the Database
            List<Patient> patients = new List<Patient>();
            patients = get_patients();
            context.Patient.AddOrUpdate(p => new { p.ID }, patients.ToArray());
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


        private static List<Doctor> get_doctors()
        {
            // Get the list of DTO records from the resource
            List<DoctorDTO> ddto = Get<DoctorDTO>("Week12HealthDomain2223.S00211357.Doctor.csv");
            List<Doctor> Doctors = new List<Doctor>();
            // iterate over the course DTO records and create course records for each one making the course year an intiger in the process

            ddto.ForEach(rec => {
                Doctors.Add(
                  new Doctor
                  {
                      DSS = Int32.Parse(rec.DSS),
                      Name = rec.Name,
                      Specialization = rec.Specialization,
                      Email = rec.Email,
                  }
                  );
            });
            return Doctors;
        }

        private static List<Patient> get_patients()
        {
            // Get the list of DTO records from the resource
            List<PatientDTO> pdto = Get<PatientDTO>("Week12HealthDomain2223.S00211357.Patient.csv");
            List<Patient> Patients = new List<Patient>();
            // iterate over the course DTO records and create course records for each one making the course year an intiger in the process

            pdto.ForEach(rec => {
                Patients.Add(
                  new Patient
                  {
                      ID = Int32.Parse(rec.ID),
                      DoctorDSS=Int32.Parse(rec.DoctorDSS),
                      Name = rec.Name,
                      Insurance = rec.Insurance,
                      DateAdmitted = DateTime.Parse(rec.DateAdmitted),
                      DateCheckedOut = DateTime.Parse(rec.DateCheckedOut)
                  }
                  );
            });
            return Patients;
        }
    }
    
}
