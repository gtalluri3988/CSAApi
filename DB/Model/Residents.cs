
namespace DB.EFModel
{
    public class Resident : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public int? StateId { get; set; }  // Primary Key
        public string? HouseNo { get; set; }
        public string? LotNo { get; set; }
        public int Level { get; set; }
        public string? BlockNo { get; set; }
        public string? RoadNo { get; set; }
        public string? NRIC { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public int CommunityId { get; set; }
        public int ParkingLotQty { get; set; }
        public int ParkingLotNos { get; set; }
        public int MaintenenceFeesCost { get; set; }
        public Community? Community { get; set; }
        public State? State { get; set; }
    }


}
