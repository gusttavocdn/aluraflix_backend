using AluraFlixServer.Models;
using AluraFlixServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlixServer.Controllers;

[ApiController]
public class SignInController : ControllerBase
{
    [HttpPost]
    [Route("signin")]
    public IActionResult Authenticate()
    {
        var user = new User
        {
            Id = 1,
            Email = "user@example.com",
            Password = "password",
            Role = "user",
            Username = "Otaku"
        };

        var token = TokenService.GenerateToken(user);
        return Ok(new { token });
    }
}
