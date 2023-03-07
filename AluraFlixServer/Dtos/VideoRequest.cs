using System.ComponentModel.DataAnnotations;

namespace AluraFlixServer.Dtos;

public class VideoRequest
{
    [Required] public string Title { get; set; } = "";

    [Required] public string Description { get; set; } = "";

    [Required] [Url] public string Url { get; set; } = "";

    public int CategoryId { get; set; } = 1;
}
