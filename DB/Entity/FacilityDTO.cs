using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity
{
    public class FacilityDTO
    {
        public int Id { get; set; }  // Primary Key
        public string? FacilityName { get; set; }
        public string? FacilityLocation { get; set; }

        public string? FacilityDetails { get; set; }
    }
}
