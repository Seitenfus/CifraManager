namespace CifraManager.Application.Dtos;

public class UploadSongDto
{
    public string Title { get; set; } = default!;
    public int PageNumber { get; set; }
    public int ThemeId { get; set; }
}
