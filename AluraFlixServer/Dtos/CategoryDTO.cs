using System.ComponentModel.DataAnnotations;

namespace AluraFlixServer.Dtos;

public class CategoryDTO
{
    [Required] public string? Title { get; set; }
    [Required] public string? Color { get; set; }
}
