using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12HealthDomain2223.S00211357.models
{
    public class Doctor
    {

        [Key]
        [Display(Name = "DSS")]
        public int DSS { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Specialization")]
        public string Specialization { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public virtual ICollection<Patient> myPatients { get; set; }

    }
}
