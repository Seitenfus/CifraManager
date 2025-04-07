using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;
using CifraManager.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CifraManager.Infraestructure.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly AppDbContext _context;

        public ThemeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Theme> AddAsync(Theme theme)
        {
            _context.Themes.Add(theme);
            await _context.SaveChangesAsync();
            return theme;
        }

        public async Task<IEnumerable<Theme>> GetAllAsync()
        {
            return await _context.Themes.ToListAsync();
        }
    }
}
