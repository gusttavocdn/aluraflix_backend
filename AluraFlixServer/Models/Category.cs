using System.ComponentModel.DataAnnotations;

namespace AluraFlixServer.Models;

public class Category
{
    [Key] [Required] public int Id { get; set; }

    [Required] public string Title { get; set; } = "";

    [Required] public string color { get; set; } = "";

    public virtual ICollection<Video>? Videos { get; set; }
}
