namespace CifraManager.Application.Dtos;

public class SongDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int PageNumber { get; set; }
    public int PdfId { get; set; }
    public int ThemeId { get; set; }
    public ThemeDto Theme { get; set; } = default!;
}