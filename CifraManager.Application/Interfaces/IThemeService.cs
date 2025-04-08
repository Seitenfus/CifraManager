using CifraManager.Domain.Entities;

namespace CifraManager.Application.Interfaces
{
    public interface IThemeService
    {
        Task<IEnumerable<Theme>> GetAllAsync();
        Task<Theme> GetByIdAsync(int id);
        Task<Theme> AddAsync(Theme theme);
    }
}