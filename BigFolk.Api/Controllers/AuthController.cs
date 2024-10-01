using BigFolk.Api.Models.DTO.AuthModels;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(ITokenRepository tokenRepository, UserManager<IdentityUser> userManager)
        {
            _tokenRepository = tokenRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto requestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = requestDto.Username,
                Email = requestDto.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, requestDto.Password);

            if(identityResult.Succeeded)
            {
                // Add Roles To This User
                if(requestDto.Roles != null && requestDto.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, requestDto.Roles);

                    if(identityResult.Succeeded )
                    {
                        return Ok("User was registered! Please login");
                    }
                }
            }

            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
        {
            var user = await _userManager.FindByEmailAsync(requestDto.Username);

            if(user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, requestDto.Password);

                if (checkPasswordResult)
                {
                    // Get Roles for this user
                    var roles = await _userManager.GetRolesAsync(user);

                    if(roles != null)
                    {
                        // Create token 
                        var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or Password incorrect");
        }
    }
}
