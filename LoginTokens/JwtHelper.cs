namespace AuthService.LoginTokens;
static public class JwtHelper
{
    static public string GetJwtKey()
    {
        var key = Environment.GetEnvironmentVariable("JWT_KEY");
        if (string.IsNullOrEmpty(key))
        {
            Console.WriteLine("jwt key is not set");
            return default!;
        }
        return key;
    }

    static public string GetJwtTokenIssuer()
    {
        var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
        if(string.IsNullOrEmpty(issuer))
        {
            Console.WriteLine("issuer was not found");
            return default!;
        }
        return issuer;
    }

    static public string GetJwtTokenAudience()
    {
        var audience = Environment.GetEnvironmentVariable("JWT_TOKEN_AUDIENCE");
        if (string.IsNullOrEmpty(audience))
        {
            Console.WriteLine("token issuer was not set");
            return default!;
        }
        return audience;
    }
}