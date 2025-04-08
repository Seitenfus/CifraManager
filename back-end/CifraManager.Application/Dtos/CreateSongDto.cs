namespace CifraManager.Application.Dtos;
public class CreateSongDto
{
    public string Title { get; set; } = default!;
    public int PageNumber { get; set; }
    public int PdfId { get; set; }
    public int ThemeId { get; set; }
}