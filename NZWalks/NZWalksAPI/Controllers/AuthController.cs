using System.Linq.Expressions;
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

        //POST:/api/Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {       // Validate input
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Username and password are required");
            }

            try
            {
                // Find user by email
                var user = await userManager.FindByEmailAsync(loginDto.Username);

                // Check if user exists and password is correct
                if (user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
                {
                    // Generic message for security (don't reveal if user exists or password is wrong)
                    return Unauthorized("Invalid email or password");
                }

                // Return successful response with token
                return Ok(new
                {
                    message = "User logged in successfully"
                });


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//end of loginfunc


    }// end of class
}// end of namespace
