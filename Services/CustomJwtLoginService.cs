using AuthService.LoginResponses;
using AuthService.LoginTokens;
using AuthService.Model;
using AuthService.Types;
using Microsoft.AspNetCore.Identity;
namespace AuthService.Services;
public class CustomJwtAccountService(
    UserManager<IdentityUser> userManager,
    ITokenGenerator tokenGenerator) : ICustomAccountService
{
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<LoginResult> SignInAsync(LoginModel loginModel)
    {
        var user = await _userManager.FindByEmailAsync(loginModel.Email);
        if (user is null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
        {
            return LoginResponseFactory.GetInvalidLoginDetailsResponse("Invalid login inputs");
        }

        var result = _tokenGenerator.GenerateToken(user);
        if (result is JwtTokenGeneratorError errorResult)
        {
            return LoginResponseFactory.GetInternalLoginServerErrorResponse(errorResult.Message);
        }

        if (result is JwtTokenGeneratorSuccess successResult)
        {
            return LoginResponseFactory.GetLoginSucessfullResponse(token: successResult.Token);
        }

        return LoginResponseFactory.GetInternalLoginServerErrorResponse("Internal server error");
    }
}