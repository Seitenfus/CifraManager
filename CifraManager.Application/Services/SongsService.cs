using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;

namespace CifraManager.Application.Services
{
    public class SongService(ISongRepository repository) : ISongService
    {
        private readonly ISongRepository _repository = repository;

        public async Task<Song> AddAsync(Song song)
        {
            return await _repository.AddAsync(song);
        }

        public async Task<IEnumerable<Song>> GetByTitleAsync(string title)
        {
            return await _repository.GetByTitleAsync(title);
        }

        public async Task<IEnumerable<Song>> GetByThemeAsync(int themeId)
        {
            return await _repository.GetByThemeAsync(themeId);
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }


        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Song> ChangeThemeAsync(int id, int themeId, string themeName)
        {
            return await _repository.ChangeThemeAsync(id, themeId, themeName);
        }
    }
}
