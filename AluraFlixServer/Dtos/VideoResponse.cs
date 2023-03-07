namespace AluraFlixServer.Dtos;

public class VideoResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }

    public int CategoryId { get; set; }
}
