using System.ComponentModel.DataAnnotations;

namespace AuthService.Model;
public class LoginModel
{
    [Required]
    [EmailAddress]
    required public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    required public string Password { get; set;}
}