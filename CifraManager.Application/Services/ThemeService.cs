using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;

namespace CifraManager.Application.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _repository;

        public ThemeService(IThemeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Theme> AddThemeAsync(Theme theme)
        {
            return await _repository.AddAsync(theme);
        }

        public async Task<IEnumerable<Theme>> GetAllThemesAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
