
namespace DB.EFModel
{
    public class VehicleDetails : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? VehicleNo { get; set; }  // Primary Key
        public int ResidentId { get; set; }  // Primary Key
        public Resident? resident { get; set; }
        public VehicleType? type { get; set; }


    }
}
