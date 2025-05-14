using DB.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity
{
    public class ResidentAccessHistoryDTO
    {
        public int Id { get; set; }  // Primary Key
        public string? VehicleNo { get; set; }
        public DateTime? EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public int? ResidentId { get; set; }  // Primary Key
        public Resident? Resident { get; set; }
        public Boolean TemporaryAccess { get; set; }
        public int CommunityId { get; set; }
    }
}
