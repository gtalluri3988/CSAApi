

namespace DB.EFModel
{
    public class EventDetails:BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
