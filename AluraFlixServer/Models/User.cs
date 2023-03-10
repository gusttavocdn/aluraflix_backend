using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AluraFlixServer.Models;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key] public int Id { get; set; }
    [Required] public string Username { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string Role { get; set; } = string.Empty;
}
