using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.EFModel
{
    public class Card:BaseEntity
    {

        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public int? ResidentId { get; set; }  
        public string? CardNo { get; set; }
        public int? StatusId { get; set; }
        public DateTime AssignDatetime { get; set; }

        public Resident? Resident { get; set; }


    }
}
