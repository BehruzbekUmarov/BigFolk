using Microsoft.AspNetCore.Identity;

namespace BigFolk.Api.Repository.Interface
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
