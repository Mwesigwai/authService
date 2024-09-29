namespace AuthService.Types;
abstract public class LoginResult(string message)
{
    public string Message { get; private set; } = message;
}