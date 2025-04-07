namespace CifraManager.API.Dtos;

public class SongUploadDto
{
    public required string Title { get; set; }
    public int ThemeId { get; set; }
    public required IFormFile PdfFile { get; set; }
}