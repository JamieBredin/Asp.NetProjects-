using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD3012223Week.ClubDomain.DataLayer
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public int Year { get; set; }
        public string CourseName { get; set; }  
        public virtual ICollection<Student> CourseStudents { get; set; }    
    }
}
