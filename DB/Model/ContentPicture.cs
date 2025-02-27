
namespace DB.EFModel
{
    public class ContentPicture : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? PhotoPath { get; set; }
        public ContentManagement? ContentManagement { get; set; }
    }
}
