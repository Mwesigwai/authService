namespace AuthService.Types;
public class LoginSucessfull(string token):LoginResult("")
{
    public string Token { get; private set; } = token;
}