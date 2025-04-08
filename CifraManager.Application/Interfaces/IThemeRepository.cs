using CifraManager.Domain.Entities;

namespace CifraManager.Application.Interfaces
{
    public interface IThemeRepository
    {
        Task<IEnumerable<Theme>> GetAllAsync();
        Task<Theme> GetByIdAsync(int id);
        Task<Theme> AddAsync(Theme theme);
    }
}
