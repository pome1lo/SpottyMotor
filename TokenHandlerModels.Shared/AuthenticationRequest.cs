using System.ComponentModel.DataAnnotations;

namespace TokenHandlerModels.Shared
{
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "error")]
        [MinLength(11)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "error")]
        [MinLength(5)]
        public string Password { get; set; } = string.Empty;
        public int EmailConfirmationCode { get; set; } 

        public bool IsNotEmpty()
        {
            return !(string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password));
        }
    }
}