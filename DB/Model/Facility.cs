
namespace DB.EFModel
{
    public class Facility : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? FacilityName { get; set; }
        public string? FacilityLocation { get; set; }
        public int CommunityId { get; set; }
        public string? FacilityDetails { get; set; }
        public int FacilityTypeId { get; set; }
        public string? Rate { get; set; }
        public Community? Community { get; set; }
        public FacilityType? FacilityType { get; set; }

        public List<FacilityPhoto> FacilityPhotos { get; set; } = new List<FacilityPhoto>();

    }
}
