using Microsoft.AspNetCore.Identity;

namespace NZWalksAPI.Reositories
{
   public  interface ITokenService
    {
         string CreateToken(IdentityUser user,List<string> roles);
    }
}
