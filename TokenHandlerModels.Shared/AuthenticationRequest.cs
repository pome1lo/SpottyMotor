using System.ComponentModel.DataAnnotations;

namespace TokenHandlerModels.Shared
{
    public class AuthenticationRequest
    {
        [Required]
        [MinLength(11)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        public string Password { get; set; } = string.Empty;
        public bool IsAuthentication { get; set; } = true;

        public bool IsNotEmpty()
        {
            return !(string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password));
        }
    }
}