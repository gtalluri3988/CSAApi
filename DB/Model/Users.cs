
namespace DB.EFModel
{
    public class Users:BaseEntity
    {
        [Key]  // Marks as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Status { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> CommunityId { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public string? UserName { get; set; }
        public string? PicturePath { get; set; }
        public Nullable<System.DateTime> PasswordExpiryDate { get; set; }
        public Nullable<int> BadLoginAttempt { get; set; }

        public Roles? Role { get; set; }
        public Community? Community { get; set; }



    }
}
