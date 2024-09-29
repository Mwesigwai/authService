using Microsoft.AspNetCore.Identity;

namespace AuthService.LoginTokens;
public interface ITokenGenerator
{
    object GenerateToken(IdentityUser user);
}