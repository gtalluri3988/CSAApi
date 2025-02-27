
namespace DB.EFModel
{
    public class FacilityType : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? Name { get; set; }

    }
}
