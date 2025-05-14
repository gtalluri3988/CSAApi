using DB.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity
{
    public class EventDTO
    {
        public int Id { get; set; }  // Primary Key
        public string? EventDescription { get; set; }  // Primary Key
        public DateTime EventStart { get; set; }  // Primary Key
        public DateTime EventEnd { get; set; }
        public int? CommunityId { get; set; }
        public int? ResidentId { get; set; }
        public Community? Community { get; set; }
        public Resident? Resident { get; set; }
    }
}
