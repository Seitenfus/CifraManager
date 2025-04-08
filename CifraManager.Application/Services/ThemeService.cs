using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;

namespace CifraManager.Application.Services
{
    public class ThemeService(IThemeRepository repository) : IThemeService
    {
        private readonly IThemeRepository _repository = repository;

        public async Task<Theme> AddAsync(Theme theme)
        {
            return await _repository.AddAsync(theme);
        }

        public async Task<IEnumerable<Theme>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Theme> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
