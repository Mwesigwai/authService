using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using AuthService.Types;

namespace AuthService.LoginTokens;
public class JwtTokenGenerator:ITokenGenerator
{
    public object GenerateToken(IdentityUser user)
    {
        var jwtKey = JwtHelper.GetJwtKey();
        var audience = JwtHelper.GetJwtTokenAudience();
        var issuer = JwtHelper.GetJwtTokenIssuer();
        var abstractedInternalErrorMsg = "internal error occured";
        var expirationTime = DateTime.Now.AddMinutes(3);


        if (string.IsNullOrEmpty(jwtKey))
        {
            Console.WriteLine("error occured while trying to get jwt token key environment variable");
            return new JwtTokenGeneratorError(abstractedInternalErrorMsg).Message;
        }

        else if (string.IsNullOrEmpty(audience))
        {
            Console.WriteLine("error occured while trying to get jwt token audience enviroment variable");
            return new JwtTokenGeneratorError(abstractedInternalErrorMsg).Message;
        }

        else if (string.IsNullOrEmpty(issuer))
        {
            Console.WriteLine("error occured while trying to get issuer environment variable");
            return new JwtTokenGeneratorError(abstractedInternalErrorMsg).Message;
        }

        else
        {
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub, user?.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expirationTime,
                signingCredentials: credentials
            );

            return new JwtTokenGeneratorSuccess(token: new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}