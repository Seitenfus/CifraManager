using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;
using CifraManager.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CifraManager.Infraestructure.Repositories
{
    public class ThemeRepository(AppDbContext context) : IThemeRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Theme>> GetAllAsync()
        {
            return await _context.Themes.ToListAsync();
        }

        public async Task<Theme> GetByIdAsync(int id)
        {
            return await _context.Themes.FirstOrDefaultAsync(t => t.Id == id)
                ?? throw new NullReferenceException("Tema não encontrado.");
        }

        public async Task<Theme> AddAsync(Theme theme)
        {
            _context.Themes.Add(theme);
            await _context.SaveChangesAsync();
            return theme;
        }
    }
}
