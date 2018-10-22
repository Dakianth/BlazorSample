using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlazorSpa.Server.Extensions
{
    public static class JwtUserExtensions
    {
        public static async Task<TUser> GetJwtUserAsync<TUser>(this UserManager<TUser> manager, ClaimsPrincipal principal) where TUser : class
        {
            string value = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            if (value == null)
                return null;

            var user = await manager.FindByEmailAsync(value);
            return user;
        }
    }
}