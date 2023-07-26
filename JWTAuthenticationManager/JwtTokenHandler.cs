using JWTAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenHandlerModels.Shared;

namespace JWTAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "ksdjfosjf8sufjhsf8sd7fsdhfsdhiof";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _userAccountList;

        public JwtTokenHandler()
        {
            _userAccountList = new List<UserAccount>()
            {
                new UserAccount { UserName = "admin", Password = "123", Role = "Administrator"},
                new UserAccount { UserName = "user", Password = "123", Role = "User"}
            };
        }

        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                return null;  

            //validation

            var userAccount = _userAccountList.Where(x => x.UserName == request.UserName && x.Password == request.Password).FirstOrDefault();
            if (userAccount is null)
                return null; 

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenkey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentify = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, request.UserName),
                new Claim("Role", userAccount.Role),
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenkey),
                SecurityAlgorithms.HmacSha256Signature
            );

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentify,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = userAccount.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                Role = userAccount.Role,
                Token = token
            };
        }
    }
}
