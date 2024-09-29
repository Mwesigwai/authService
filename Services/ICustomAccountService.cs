using AuthService.Model;
using AuthService.Types;

namespace AuthService.Services;
public interface ICustomAccountService
{
    Task<LoginResult> SignInAsync(LoginModel loginModel);
}