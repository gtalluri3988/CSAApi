using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.EFModel
{
    public class CommunityVisitorCharges:BaseEntity
    {
        public int Id { get; set; }

        public int VisitorParkingChargeId { get; set; }
        public int CommunityId { get; set; }
        public  VisitorParkingCharge? VisitorParkingCharge { get; set; }
        public Community? Community { get; set; }
    }
}
