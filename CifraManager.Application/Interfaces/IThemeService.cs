using CifraManager.Domain.Entities;

namespace CifraManager.Application.Interfaces
{
    public interface IThemeService
    {
        Task<Theme> AddThemeAsync(Theme theme);
        Task<IEnumerable<Theme>> GetAllThemesAsync();
    }
}