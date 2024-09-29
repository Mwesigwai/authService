using AuthService.Types;

namespace AuthService.LoginResponses;
static public class LoginResponseFactory
{
    static public LoginResult GetInternalLoginServerErrorResponse(string message)
    {
        InternalLoginServerError internalLoginServerError = null!;
        return ResponseInstanceIsNull(internalLoginServerError) ? new(message) : internalLoginServerError;
    }

    static public LoginResult GetInvalidLoginDetailsResponse(string message)
    {
        InvalidLoginDetails invalidLoginDetails = null!;
        return ResponseInstanceIsNull(invalidLoginDetails) ? new(message) : invalidLoginDetails;
    }

    static public LoginResult GetLoginSucessfullResponse(string token)
    {
        LoginSucessfull loginSucessfull = null!;
        return ResponseInstanceIsNull(loginSucessfull) ? new(token) : loginSucessfull;
    }

    static private bool ResponseInstanceIsNull(LoginResult instance)
    {
        return instance is null;
    }
}