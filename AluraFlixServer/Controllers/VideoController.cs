using AluraFlixServer.Data;
using AluraFlixServer.Dtos;
using AluraFlixServer.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlixServer.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ReadVideoDTO>), 200)]
    public IActionResult GetVideos()
    {
        IEnumerable<ReadVideoDTO> videos = _mapper.Map<List<ReadVideoDTO>>(_context.Videos.ToList());
        return Ok(videos);
    }


    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ReadVideoDTO), 200)]
    public IActionResult GetVideoById(Guid id)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        var readVideoDTO = _mapper.Map<ReadVideoDTO>(video);
        return Ok(readVideoDTO);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(typeof(VideoDTO), 201)]
    public IActionResult AddVideo([FromBody] VideoDTO videoDTO)
    {
        var newVideo = _mapper.Map<Video>(videoDTO);

        _context.Videos.Add(newVideo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetVideoById), new { id = newVideo.Id }, videoDTO);
    }

    [HttpPut("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(VideoDTO), 200)]
    public IActionResult UpdateVideo(Guid id, [FromBody] VideoDTO updateVideoDTO)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        _mapper.Map(updateVideoDTO, video);
        _context.SaveChanges();

        var videoResponse = _mapper.Map<VideoDTO>(video);
        return Ok(videoResponse);
    }

    [HttpPatch("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(VideoDTO), 200)]
    public IActionResult PatchVideo(Guid id, [FromBody] JsonPatchDocument<VideoDTO> patchDocument)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        var videoDTO = _mapper.Map<VideoDTO>(video);
        patchDocument.ApplyTo(videoDTO);

        _mapper.Map(videoDTO, video);
        _context.SaveChanges();

        return Ok(videoDTO);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    public IActionResult DeleteVideo(Guid id)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        _context.Videos.Remove(video);
        _context.SaveChanges();

        return NoContent();
    }
}
