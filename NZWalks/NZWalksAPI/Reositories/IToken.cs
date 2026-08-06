using Microsoft.AspNetCore.Identity;

namespace NZWalksAPI.Reositories
{
   public  interface IToken
    {
         string CreateTokenAsync(IdentityUser user,List<string> roles);
    }
}
