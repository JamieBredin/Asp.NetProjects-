using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubModels
{
    [Table("Club")]
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }
        public int adminID { get; set; }
        public virtual ICollection<ClubEvent> clubEvents { get; set; }
        
        
    }
}
