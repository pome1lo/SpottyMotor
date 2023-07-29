using AuthenticationWebApi.Database;
using AuthenticationWebApi.Services;
using JWTAuthenticationManager;
using JWTAuthenticationManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenHandlerModels.Shared;

namespace AuthenticationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly UserAccountDbContext _context;
        private readonly ProviderMailService _emailService;

        private UserAccountService _userService;

        public AccountController(JwtTokenHandler jwtTokenHandler, UserAccountDbContext context, ProviderMailService email)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _context = context;
            _emailService = email;
            _userService = new UserAccountService(_context);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest request)
        {
            if (request.IsNotEmpty())
            {
                UserAccount? user;
                if (_userService.GetUserOrDefault(request, out user))
                {
                    return _jwtTokenHandler.GenerateJwtToken(user);
                }
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public ActionResult<AuthenticationResponse?> Registration([FromBody] AuthenticationRequest request)
        {
            UserAccount? user;
            if (request.IsNotEmpty() && _userService.IsThereSuchUser(request, out user))
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok();
            }
            return Unauthorized();
        }


        [HttpPost]
        [Route("VerifyEmail")]
        [AllowAnonymous]
        public async Task<ActionResult> VerifyEmail([FromBody] AuthenticationRequest request)
        {
            if (request.IsNotEmpty() && _userService.IsThereSuchUser(request.Email))
            {
                await _emailService.SendEmailAsync(
                    request.Email,
                    "Email verification",
                    $"Your verification code is: {request.EmailConfirmationCode}"
                );
                return Ok();
            }
            return Unauthorized();
        }
    }
}
