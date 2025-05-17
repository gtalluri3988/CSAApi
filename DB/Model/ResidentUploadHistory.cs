
namespace DB.EFModel
{
    public class ResidentUploadHistory : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? FileName { get; set; }
        public string? Attachment { get; set; }
        public int UploadedBy { get; set; }
        public DateTime? UploadDateTime { get; set; }
    }
}
