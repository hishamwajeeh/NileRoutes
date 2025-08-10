using Microsoft.AspNetCore.Identity;

namespace NileRoutes.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
