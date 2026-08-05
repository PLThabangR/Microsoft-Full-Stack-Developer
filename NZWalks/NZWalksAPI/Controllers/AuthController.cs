using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Dtos.authDto;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
{           
    private readonly UserManager<IdentityUser> userManager;

        //Constructor
        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;

        }

        //Post https://localhost:7000/api/auth/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {        // Create user
            var user = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Username
            };

            // Try to create user using 
            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Add roles to user
            if (registerDto.Roles?.Any() == true)
            {
                foreach (var role in registerDto.Roles)
                {
                    result = await userManager.AddToRoleAsync(user, role);
                    if (!result.Succeeded)
                        return BadRequest(result.Errors);
                }
            }

            return Ok("User registered successfully");

        }// end of register



    }
}
