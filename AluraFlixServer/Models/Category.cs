using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace AluraFlixServer.Models;

public class Category
{
    [Key] [Required] public int Id { get; set; }

    [Required] public string Title { get; init; } = "";

    [Required] public string Color { get; init; } = "";

    [JsonIgnore] public virtual ICollection<Video>? Videos { get; set; }
}
