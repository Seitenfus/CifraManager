using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;

namespace CifraManager.Application.Services
{
    public class SongService(ISongRepository repository) : ISongService
    {
        private readonly ISongRepository _repository = repository;

        public async Task<Song> AddSongAsync(Song song)
        {
            return await _repository.AddAsync(song);
        }

        public async Task<IEnumerable<Song>> GetSongsByTitleAsync(string title)
        {
            return await _repository.GetByTitleAsync(title);
        }

        public async Task<IEnumerable<Song>> GetSongsByThemeAsync(int themeId)
        {
            return await _repository.GetByThemeAsync(themeId);
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Song> ChangeSongThemeAsync(int id, int themeId)
        {
            return await _repository.ChangeThemeAsync(id, themeId);
        }
    }
}
