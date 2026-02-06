using System.Linq;
using System.Security.Claims;

namespace Stationery.PaperStore.API.Extensions
{
    public static class ClaimsPrincipleExtension
    {
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(x =>x.Type == ClaimTypes.Email)?.Value;
        }
    }
}