using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuthenticationManager.Models
{
    [Table("user_accounts", Schema = "dbo")]
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_account_id")]
        public int Id { get; set; } = default;
        [Column("user_account_email")]
        public string Email { get; set; } = string.Empty;
        [Column("user_account_password")]
        public string Password { get; set; } = string.Empty;
        [Column("user_role_id")]
        public int RoleId { get; set; }
        [Column("user_role")]
        public UserRole Role { get; set; } = null!;
    }
}
