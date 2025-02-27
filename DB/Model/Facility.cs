
namespace DB.EFModel
{
    public class Facility : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? FacilityName { get; set; }
        public string? FacilityLocation { get; set; }

        public string? FacilityDetails { get; set; }
        public Community? Community { get; set; }
        public FacilityType? FacilityType { get; set; }

    }
}
