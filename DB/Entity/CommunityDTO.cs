using DB.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity
{
    public class CommunityDTO
    {
        public int Id { get; set; }  // Primary Key
        public int? StateId { get; set; }  // Primary Key
        public string? CommunityId { get; set; }
        public string? CommunityName { get; set; }
        public string? CityName { get; set; }
        public string? Address { get; set; }
        public int NoOfUnits { get; set; }
        public string? PICName { get; set; }
        public int FeesMonthly { get; set; }

        public int GracePeriod { get; set; }
        public string? PICMobile { get; set; }
        public string? PICEmail { get; set; }
        public int NoOfParkingLot { get; set; }
        public int CommunityTypeId { get; set; }
        public List<VisitorParkingCharge>? VisitorParkingCharges { get; set; }
        public State? State { get; set; }
        public IEnumerable<CommunityDTO>? CommunityResult { get; set; }
    }

    public class TableData
    {
        public long Id { get; set; }
        public int NoOfVistorParkingLot { get; set; }
        public int Amount { get; set; }
        public int Status { get; set; }
        public int ChargeType { get; set; }
    }
}
