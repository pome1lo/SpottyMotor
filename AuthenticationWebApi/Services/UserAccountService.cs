using AuthenticationWebApi.Database;
using JWTAuthenticationManager.Models;
using TokenHandlerModels.Shared;

namespace AuthenticationWebApi.Services
{
    internal class UserAccountService
    {
        private readonly UserAccountDbContext _context;
        public UserAccountService(UserAccountDbContext context)
        {
            _context = context;
        }

        internal bool GetUserOrDefault(AuthenticationRequest request, out UserAccount? user)
        {

            user = _context.Users.Where(x => x.Email == request.Email && x.Password == request.Password).FirstOrDefault();

            if (user is null)
            {
                return false;
            } 
            return true;
        }

        internal bool IsThereSuchUser(AuthenticationRequest request, out UserAccount? user)
        {
            user = _context.Users.Where(x => x.Email == request.Email).FirstOrDefault();
            var userRole = _context.UserRoles.Where(x => x.RoleName == "User").FirstOrDefault();
            if (user is null)
            {
                user = new UserAccount()
                {
                    Email = request.Email,
                    Password = request.Password,
                    Role = userRole
                };
                return true;
            }
            return false;
        }
        internal bool IsThereSuchUser(string Email)
        {
            return !_context.Users.Any(x => x.Email == Email);
        }
    }
}
