using System.ComponentModel.DataAnnotations;

namespace AluraFlixServer.Dtos;

public class CategoryRequest
{
    [Required] public string? Title { get; set; }
    [Required] public string? Color { get; set; }
}
