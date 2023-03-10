using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AluraFlixServer.Models;

public class Video
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();

    [Required] public string Title { get; set; } = "";

    [Required] public string Description { get; set; } = "";

    [Required] [Url] public string Url { get; set; } = "";

    public int CategoryId { get; set; } = 1;
    public virtual Category Category { get; set; }
}
