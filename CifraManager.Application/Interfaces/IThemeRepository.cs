using CifraManager.Domain.Entities;

namespace CifraManager.Application.Interfaces
{
    public interface IThemeRepository
    {
        Task<Theme> AddAsync(Theme theme);
        Task<IEnumerable<Theme>> GetAllAsync();
    }
}
