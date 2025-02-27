
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
        public string? HouseNo { get; set; }
        public int LevelNo { get; set; }
        public string? BlockNo { get; set; }
        public string? RoadNo { get; set; }
        public Boolean TemporaryAccess { get; set; }
        public int CommunityId { get; set; }
        public Community? Community { get; set; }

    }
}
