using System.ComponentModel.DataAnnotations;

namespace AluraFlixServer.Dtos;

public class SigninUserRequest
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Password { get; set; }
}
