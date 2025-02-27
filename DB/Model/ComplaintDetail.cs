
namespace DB.EFModel
{
    public class ComplaintDetail : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? ComplainRefNo { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime? ComplaintDate { get; set; }
        public string? SecurityRemarks { get; set; }
        public int ComplaintStatusId { get; set; }
        public ComplaintStatus? ComplaintStatus { get; set; }
    }

}
