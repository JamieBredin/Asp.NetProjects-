using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10ClubDomain22
{
    public class Student
    {
        [Key]
        [Display(Name = "Student ID")]
        public string StudentID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; }

    }
}
