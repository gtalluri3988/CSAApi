using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.EFModel
{
    public class VisitorParkingCharge:BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NoOfVistorParkingLot { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }
        public ChargesType? ChargeType { get; set; }
        public Community? Community { get; set; }
    }
}
