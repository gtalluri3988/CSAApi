
using System.Text.Json.Serialization;

namespace DB.EFModel
{
    public class ResidencePaymentDetails : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public int ResidentId { get; set; }  // Primary Key
        public int PaymentTypeId { get; set; }

        public int PaymentStatusId { get; set; }

        public double Amount { get; set; }
        public string? PaymentRef { get; set; }
        public DateTime? PaymentDate { get; set; }
        [JsonIgnore]
        public Resident? resident { get; set; }
        public PaymentType? PaymentType { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }



    }
}
