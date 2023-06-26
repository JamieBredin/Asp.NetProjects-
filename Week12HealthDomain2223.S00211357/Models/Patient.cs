using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12HealthDomain2223.S00211357.models
{
    public class Patient
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [ForeignKey("associcatedDoctor")]
        [Display(Name = "DoctorDSS")]
        public int DoctorDSS { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Insurance")]
        public string Insurance { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Admitted")]
        public DateTime DateAdmitted { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Checked Out")]
        public DateTime DateCheckedOut { get; set; }
        public virtual Doctor associcatedDoctor { get; set; }
    }
}
