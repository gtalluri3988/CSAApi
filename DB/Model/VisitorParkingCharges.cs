using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.EFModel
{
    public class VisitorParkingCharge:BaseEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public int NoOfVistorParkingLot { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }
        public int ChargeTypeId { get; set; }
        public ChargesType? ChargeType { get; set; }
        public int? CommunityId { get; set; }
        
    }
}
