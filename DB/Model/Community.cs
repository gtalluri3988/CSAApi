namespace DB.EFModel
{
    public class Community:BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public int? StateId { get; set; }  // Primary Key
        public Nullable<int> CityId { get; set; }
        public string? CommunityId { get; set; }
        public string? CommunityName { get; set; }
        public string? CityName { get; set; }
        public string? Address { get; set; }
        public int NoOfUnits { get; set; }
        public string? PICName { get; set; }
        public string? PICMobile { get; set; }
        public string? PICEmail { get; set; }
        public int NoOfParkingLot { get; set; }
        public int CommunityTypeId { get; set; }
        public int FeesMonthly { get; set; }
        public int GracePeriod { get; set; }

        public Guid CardGuid { get; set; }
        public State? State { get; set; }
        public City? City { get; set; }
        public CommunityType? CommunityType { get; set; }
        public List<VisitorParkingCharge> VisitorParkingCharges { get; set; } = new List<VisitorParkingCharge>();
        public List<Resident> Residents { get; set; } = new List<Resident>();
        public List<Users> Users { get; set; } = new List<Users>();


    }
}
