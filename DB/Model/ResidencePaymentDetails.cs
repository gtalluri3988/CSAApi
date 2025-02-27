
namespace DB.EFModel
{
    public class ResidencePaymentDetails : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public int ResidentId { get; set; }  // Primary Key
        public int PaymentTypeId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Resident? resident { get; set; }
        public PaymentType? PaymentType { get; set; }
    }
}
