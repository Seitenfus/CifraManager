namespace CifraManager.Domain.Entities;

public class Theme
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public required ICollection<Song> Songs { get; set; }
}