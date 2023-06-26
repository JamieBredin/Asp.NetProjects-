using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12HealthDomain2223.S00211357.Models
{
    public class PatientDTO
    {
        public string ID { get; set; }
        public string DoctorDSS { get; set; }
        public string Name { get; set; }
        public string Insurance { get; set; }
        public string DateAdmitted { get; set; }
        public string DateCheckedOut { get; set; }


    }
}
