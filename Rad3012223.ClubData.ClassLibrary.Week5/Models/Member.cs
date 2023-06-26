﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RAD3012223Week5
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }
        public int AssociatedClub { get; set; }
        public string StudentID { get; set; }
        public bool approved { get; set; }
        [ForeignKey("AssociatedClub")]
        public virtual Club myClub { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student studentMember { get; set; }
     }
}
