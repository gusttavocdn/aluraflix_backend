using System.ComponentModel.DataAnnotations;

namespace AluraFlixServer.Dtos;

public class CreateUserRequest
{
    [Required] public string Username { get; set; } = string.Empty;

    [Required] public string Password { get; set; } = string.Empty;

    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(user|admin)$", ErrorMessage = "The Role field must be either 'user' or 'admin'.")]
    public string Role { get; set; } = string.Empty;
}
