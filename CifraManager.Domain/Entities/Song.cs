namespace CifraManager.Domain.Entities;

public class Song
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required byte[] PdfData { get; set; }
    public int ThemeId { get; set; }

    public Theme? Theme { get; set; }
}