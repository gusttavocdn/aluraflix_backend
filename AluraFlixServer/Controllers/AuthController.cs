using AluraFlixServer.Data;
using AluraFlixServer.Dtos;
using AluraFlixServer.Models;
using AluraFlixServer.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlixServer.Controllers;

[ApiController]
[Route("/api/")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AuthController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    [Route("signin")]
    public IActionResult Authenticate([FromBody] SigninUserRequest signinUser)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == signinUser.Email);

        if (user == null || user.Password != signinUser.Password)
            return BadRequest(new { message = "User or password invalid" });

        var token = TokenService.GenerateToken(user);
        return Ok(new { token });
    }

    [HttpPost]
    [Route("signup")]
    public IActionResult Signup([FromBody] CreateUserRequest userRequest)
    {
        var user = _mapper.Map<User>(userRequest);

        _context.Users.Add(user);
        _context.SaveChanges();

        var token = TokenService.GenerateToken(user);
        return Ok(new { token });
    }
}
