using AluraFlixServer.Data;
using AluraFlixServer.Dtos;
using AluraFlixServer.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlixServer.Controllers;

[ApiController]
[Route("[controller]/{id:guid}")]
public class VideoController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public VideoController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetVideos()
    {
        IEnumerable<Video> videos = _context.Videos.ToList();
        return Ok(videos);
    }

    [HttpGet("")]
    public IActionResult GetVideoById(Guid id)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        return Ok(video);
    }

    [HttpPost]
    public IActionResult AddVideo([FromBody] VideoDTO videoDTO)
    {
        var newVideo = _mapper.Map<Video>(videoDTO);

        _context.Videos.Add(newVideo);
        _context.SaveChanges();
        return Ok(newVideo);
    }

    [HttpPut("")]
    public IActionResult UpdateVideo(Guid id, [FromBody] VideoDTO updateVideoDTO)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        _mapper.Map(updateVideoDTO, video);
        _context.SaveChanges();

        return Ok(video);
    }

    [HttpPatch("")]
    public IActionResult PatchVideo(Guid id, [FromBody] JsonPatchDocument<VideoDTO> patchDocument)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        var videoDTO = _mapper.Map<VideoDTO>(video);
        patchDocument.ApplyTo(videoDTO);

        _mapper.Map(videoDTO, video);
        _context.SaveChanges();

        return Ok(video);
    }

    [HttpDelete("")]
    public IActionResult DeleteVideo(Guid id)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        _context.Videos.Remove(video);
        _context.SaveChanges();

        return NoContent();
    }
}
