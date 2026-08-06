using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace NZWalksAPI.Reositories
{
    public class TokenService : IToken
    {   private readonly IConfiguration configuration;

        //Inject Iconfiguration
        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string CreateTokenAsync(IdentityUser user, List<string> roles)
        {
            //Create Claims for roles
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            //In the claims collections we will have email and role
            
            //Get key from appsettings
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //Create token
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],//token will be issued by this
                audience: configuration["Jwt:Audience"],//token will be used by this
                claims: claims,//
                expires: DateTime.Now.AddMinutes(15),///token will expire in 15 minutes
                signingCredentials: credentials);//token will be signed using key
            
            var tokenHandler = new JwtSecurityTokenHandler();//create token handler
            return tokenHandler.WriteToken(token);//return token

           

        }
    }
}
