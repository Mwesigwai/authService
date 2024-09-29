using AuthService.Model;
using AuthService.Services;
using AuthService.Types;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/jwt")]
    public class AccountController(ICustomAccountService accountService) : ControllerBase
    {
        readonly ICustomAccountService _accountService = accountService;

        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> SignIn([FromBody] LoginModel loginModel)
        {
            var loginResponse = await _accountService.SignInAsync(loginModel);
            if (loginResponse is InvalidLoginDetails invalidLoginDetails)
            {
                return Unauthorized(invalidLoginDetails.Message);
            }
            if (loginResponse is InternalLoginServerError)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (loginResponse is LoginSucessfull loginSucessfull)
            {
                return Ok(new
                {
                    loginSucessfull.Token,
                    loginSucessfull.Message
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
