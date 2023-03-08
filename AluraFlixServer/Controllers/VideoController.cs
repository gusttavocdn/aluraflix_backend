using System.Globalization;
using AluraFlixServer.Data;
using AluraFlixServer.Dtos;
using AluraFlixServer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlixServer.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
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
    [ProducesResponseType(typeof(IEnumerable<VideoResponse>), 200)]
    public IActionResult GetVideos([FromQuery] string? search, int page = 1)
    {
        var skip = (page - 1) * 5;
        var videos = _context.Videos.AsQueryable();

        if (string.IsNullOrEmpty(search))
        {
            var videosResponse = _mapper.Map<List<VideoResponse>>(
                videos.Skip(skip).Take(5).ToList());
            return Ok(videosResponse);
        }

        var filteredVideos = videos.Where(v =>
            v.Title.Contains(search));

        var filteredVideosResponse = _mapper.Map<List<VideoResponse>>(
            filteredVideos.Skip(skip).Take(5).ToList());
        return Ok(filteredVideosResponse);
    }

    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(VideoResponse), 200)]
    public IActionResult GetVideoById(Guid id)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        var videoResponse = _mapper.Map<VideoResponse>(video);
        return Ok(videoResponse);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(typeof(VideoResponse), 201)]
    public IActionResult AddVideo([FromBody] VideoRequest videoRequest)
    {
        var newVideo = _mapper.Map<Video>(videoRequest);

        _context.Videos.Add(newVideo);
        _context.SaveChanges();

        var videoResponse = _mapper.Map<VideoResponse>(newVideo);
        return CreatedAtAction(nameof(GetVideoById), new { id = videoResponse.Id }, videoResponse);
    }

    [HttpPut("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(VideoResponse), 200)]
    public IActionResult UpdateVideo(Guid id, [FromBody] VideoRequest updateVideoRequest)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        _mapper.Map(updateVideoRequest, video);
        _context.SaveChanges();

        var videoResponse = _mapper.Map<VideoResponse>(video);
        return Ok(videoResponse);
    }

    [HttpPatch("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(VideoResponse), 200)]
    public IActionResult PatchVideo(Guid id, [FromBody] JsonPatchDocument<VideoRequest> patchDocument)
    {
        var video = _context.Videos.Find(id);

        if (video == null) return NotFound(new { message = "Video not found" });

        var videoRequest = _mapper.Map<VideoRequest>(video);
        patchDocument.ApplyTo(videoRequest);

        _mapper.Map(videoRequest, video);
        _context.SaveChanges();

        var videoResponse = _mapper.Map<VideoResponse>(video);
        return Ok(videoResponse);
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
