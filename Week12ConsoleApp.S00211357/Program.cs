using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.WebAPIClient;
using Week12HealthDomain2223.S00211357.models;
namespace Week12ConsoleApp.S00211357
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "Rad301 2223 Week 12 Lab", Task: "RunningConsole App Queries");

            //Using the Health Data Context defined in the class library create LINQ queries to do the following
            //Return a list of all the Patients with VHI insurance
            HealthContext _healthContext = new HealthContext();
            //Linking HealthContext Model to the Main Program

            Console.WriteLine("Starting Queries");

            //getting all categories from Health Context model
            var _patientDetails = _healthContext.Patient
                .Where(s => s.Insurance == "VHI")
                .Select(p => new
                {
                    allPatientVHIInfo = String.Concat("\nPatientID: ", p.ID, " \nDoctorDSS: ", p.DoctorDSS, "\nName: ", p.Name, "\nInsurance: ", p.Insurance, "\nDate Admitted: ", p.DateAdmitted, "\nDate Checked Out: ", p.DateCheckedOut)
                });
            //Looping through all the Patient data that is with VHI and printing it
            foreach (var pPatient in _patientDetails)
                Console.WriteLine("--------------------------\n Patient Information {0}",
                    String.Concat(pPatient.allPatientVHIInfo, " "));
            Console.WriteLine("\n-------------------------Next Query---------------------------------------");

            //Return all the Doctor Name and a list of all the Patients for that doctor
            List<Doctor> doctorList = _healthContext.Doctor.ToList();
            foreach (var pDoctor in doctorList)
            {
                Console.WriteLine("--------------------------\nDoctor Information {0} ", pDoctor.Name);
                Console.WriteLine("\nPatientID \tDoctorDSS \tName \t\t\tInsurance \t\tDate Admitted \t\tDate Checked Out");
                foreach(Patient p in pDoctor.myPatients)
                {
                    //Console.WriteLine("\nPatientID: ", p.ID, " \nDoctorDSS: ", p.DoctorDSS, "\nName: ", p.Name, "\nInsurance: ", p.Insurance, "\nDate Admitted: ", p.DateAdmitted, "\nDate Checked Out: ", p.DateCheckedOut);
                    Console.WriteLine("\n{0} \t\t{1} \t\t{2} \t\t{3} \t\t\t{4} \t\t{5}", p.ID,p.DoctorDSS,p.Name,p.Insurance,p.DateAdmitted,p.DateCheckedOut);
                }
            }
          
            Console.WriteLine("\n-------------------------Next Query---------------------------------------");

            //Return all the patients whose hospital stay is over 7 days
            List<Patient> patientsList = _healthContext.Patient.ToList();
            var patients = from p in patientsList
                           where (p.DateCheckedOut - p.DateAdmitted).TotalDays > 7
                           select p;

            foreach (var p in patients)
            {
                Console.WriteLine("\nPatientID: {0}  \nDoctorDSS: {1}  \nName: {2}  \nInsurance: {3}  \nDate Admitted: {4}  \nDate Checked Out: {5}", p.ID, p.DoctorDSS, p.Name, p.Insurance, p.DateAdmitted, p.DateCheckedOut);

            }


        }
    }
}
