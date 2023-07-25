namespace JWTAuthenticationManager.Models
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string JwtToken { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
    }
}
