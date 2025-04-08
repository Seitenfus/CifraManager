namespace CifraManager.Application.Dtos;
public class UpdateSongThemeDto
{
    public int ThemeId { get; set; }
    public string ThemeName { get; set; } = default!;
}