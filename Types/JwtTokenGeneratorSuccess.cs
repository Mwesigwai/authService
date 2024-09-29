namespace AuthService.Types;
public class JwtTokenGeneratorSuccess(string token)
{
    public string Token { get; private set; } = token;
}
