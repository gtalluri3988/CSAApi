
using Microsoft.AspNetCore.Http;

namespace DB.EFModel
{
    public class FacilityPhoto : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? Name { get; set; }
        public int FacilityId { get; set; }
        //public string? File { get; set; }
        //[NotMapped]
        //public IFormFile? File { get; set; }
        public string? ImageGuid { get; set; } // 
        public string? Preview { get; set; }
        
    }
}
