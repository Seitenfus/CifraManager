
using CifraManager.Domain.Entities;

namespace CifraManager.Application.Interfaces;
public interface ISongRepository
{
    Task<Song> AddAsync(Song song);
    Task<IEnumerable<Song>> GetByTitleAsync(string title);
    Task<IEnumerable<Song>> GetByThemeAsync(string themeName);
}