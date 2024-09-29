namespace AuthService.Types;
public class JwtTokenGeneratorError(string message):LoginResult(message: message);
