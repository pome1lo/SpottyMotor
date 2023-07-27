using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuthenticationManager.Models
{
    [Table("user_roles", Schema = "dbo")]
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("role_id")]
        public int Id { get; set; }

        [Column("role_name")]
        public string RoleName { get; set; } = string.Empty;
    }
}
