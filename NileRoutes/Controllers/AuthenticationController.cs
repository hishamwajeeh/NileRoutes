using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NileRoutes.Interfaces;
using NileRoutes.Models.Dtos.AuthDto;

namespace NileRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _user;
        private readonly ITokenRepository _tokenRepository;
        public AuthenticationController(UserManager<IdentityUser> user, ITokenRepository tokenRepository)
        {
            _user = user;
            _tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await _user.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await _user.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok(new { message = "User registered successfully." });
                    }
                }
            }

            return BadRequest(new { message = "User registration failed.", errors = identityResult.Errors.Select(e => e.Description) });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _user.FindByNameAsync(loginRequestDto.Username);

            if (user != null)
            {
                var passwordResult = await _user.CheckPasswordAsync(user, loginRequestDto.Password);

                if (passwordResult)
                {
                    var roles = await _user.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Generate JWT token
                        var token = _tokenRepository.CreateJwtToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = token,
                        };

                        return Ok(response);
                    }   
                }
            }
            return Unauthorized("Invalid username or password.");
        }
    }
}
