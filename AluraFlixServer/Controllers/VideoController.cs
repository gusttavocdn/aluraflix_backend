using AluraFlixServer.Data;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlixServer.Controllers;

[ApiController]
[Route("[controller]")]

public class VideoController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public VideoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetVideos()
    {
        var videos = _context.Videos.ToList();
        return Ok(videos);
    }
}
