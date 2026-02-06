using Stationery.PaperStore.Core.Entities.Identity;

namespace Stationery.PaperStore.Core.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
    }
}