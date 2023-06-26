using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9ClubDomain22
{
    [Table("ClubEvent")]
    public class ClubEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        public string Venue { get; set; }
        public string Location { get; set; }
        [ForeignKey("associatedClub")]
        public int ClubId { get; set; }
        public virtual Club associatedClub { get; set; }
        [Column(TypeName ="datetime")]
        [DataType(DataType.Date)]//Implements HTML 5 Datetime Picker
        public DateTime StartDateTime { get; set; }
        [Column(TypeName = "datetime")]
        [DataType(DataType.Date)]//Implements HTML 5 Datetime Picker
        public DateTime EndDateTime { get; set; }
    }
}