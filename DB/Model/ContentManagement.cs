

namespace DB.EFModel
{
    public class ContentManagement : BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool StatusId { get; set; }
        public Community? Community { get; set; }
    }
}
