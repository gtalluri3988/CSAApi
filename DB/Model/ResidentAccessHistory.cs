
namespace DB.EFModel
{
    public class ResidentAccessHistory : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? VehicleNo { get; set; }
        public DateTime? EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }

        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int? ResidentId { get; set; }  // Primary Key
        public Resident? Resident { get; set; }
        public Boolean TemporaryAccess { get; set; }
        public int CommunityId { get; set; }
        public Community? Community { get; set; }

    }
}
