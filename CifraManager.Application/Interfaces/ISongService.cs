
using CifraManager.Domain.Entities;

namespace CifraManager.Application.Interfaces;

public interface ISongService
{
    Task<Song> AddSongAsync(Song song);
    Task<IEnumerable<Song>> GetSongsByTitleAsync(string title);
    Task<IEnumerable<Song>> GetSongsByThemeAsync(int themeId);
    Task<IEnumerable<Song>> GetAllSongsAsync();
    Task<Song> ChangeSongThemeAsync(int id, int themeId);
}