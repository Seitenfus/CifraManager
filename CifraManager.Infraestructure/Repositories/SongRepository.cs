using CifraManager.Domain.Entities;
using CifraManager.Application.Interfaces;
using CifraManager.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;


namespace CifraManager.Infraestructure.Repositories
{
    public class SongRepository(AppDbContext context) : ISongRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Song> AddAsync(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<IEnumerable<Song>> GetByTitleAsync(string title)
        {
            return await _context.Songs
                .Where(s => s.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetByThemeAsync(int themeId)
        {
            return await _context.Songs
                .Where(s => s.ThemeId == themeId)
                .OrderBy(s => s.Title)
                .ToListAsync();
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            var song = await _context.Songs.Include(s => s.Theme).Where(s => s.Id == id).FirstOrDefaultAsync() ?? throw new NullReferenceException("Essa música não foi incluída (ainda).");
            return song;
        }

        public async Task<Song> ChangeThemeAsync(int id, int themeId, string themeName)
        {
            var song = await _context.Songs.Where(s => s.Id == id).FirstOrDefaultAsync();


            if (song == null)
            {
                throw new NullReferenceException("Essa música não foi incluída (ainda).");
            }
            else
            {
                song.ThemeId = themeId;
                song.ThemeName = themeName;
            }
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _context.Songs.ToListAsync();
        }
    }
}
