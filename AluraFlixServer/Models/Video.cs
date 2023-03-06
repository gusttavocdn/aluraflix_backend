using System.ComponentModel.DataAnnotations;

namespace AluraFlixServer.Models;

public class Video
{
  [Key] public Guid Id { get; set; } = Guid.NewGuid();

  [Required] public string Title { get; set; } = "";

  [Required] public string Description { get; set; } = "";

  [Required] [Url] public string Url { get; set; } = "";
}
