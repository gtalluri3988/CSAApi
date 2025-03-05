using DB.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity
{
    public  class VisitorAccessDetailsDTO
    {
        public int Id { get; set; }  // Primary Key
        public string? VisitorName { get; set; }
        public string? VisitPurpose { get; set; }
        public string? Status { get; set; }
        public DateTime? EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public string? VehicleNo { get; set; }
        public string? HouseNo { get; set; }
        public int LevelNo { get; set; }
        public string? BlockNo { get; set; }
        public string? RoadNo { get; set; }
        public string? ContactPerson1 { get; set; }
        public string? ContactPerson2 { get; set; }
        public int VisitorAccessTypeId { get; set; }
        public VisitorAccessType? VisitorAccessType { get; set; }
    }
}
