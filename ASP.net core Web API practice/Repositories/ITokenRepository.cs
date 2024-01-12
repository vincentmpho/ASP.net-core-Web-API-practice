using Microsoft.AspNetCore.Identity;

namespace Walk_and_Trails_of_SA_API.Repositories
{
    public interface ITokenRepository
    {

        string CreateJWTToken(IdentityUser user, List<string>roles);
    }
}
