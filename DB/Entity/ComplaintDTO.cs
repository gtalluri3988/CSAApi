using DB.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity
{
    public class ComplaintDTO
    {
        public int Id { get; set; }  // Primary Key
        public string? ComplainRefNo { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime? ComplaintDate { get; set; }
        public string? SecurityRemarks { get; set; }
        public int ComplaintStatusId { get; set; }
        public int ComplaintTypeId { get; set; }
        public int ResidentId { get; set; }
        public ComplaintStatus? ComplaintStatus { get; set; }
        public ComplaintType? ComplaintType { get; set; }

        public ResidentDTO? Resident { get; set; }
        public List<ComplaintPhotos>? ComplaintPhotos { get; set; }

    }
}
