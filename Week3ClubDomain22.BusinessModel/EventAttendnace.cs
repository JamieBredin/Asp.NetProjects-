using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3ClubDomain22.BusinessModel
{
    public class EventAttendnace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("associatedEvent")]
        public int EventID { get; set; }
        [ForeignKey("memberAttending")]
        // Set Nullable to avoid cascading deletes 
        // which would lead to indirect circular deletes
        public int? AttendeeMember { get; set; }
        public virtual Member memberAttending { get; set; }
        public virtual ClubEvent associatedEvent { get; set; }
    }
}
