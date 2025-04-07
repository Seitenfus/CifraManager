using CifraManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CifraManager.Infraestructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Song> Songs { get; set; }
    public DbSet<Theme> Themes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Theme>()
            .HasIndex(t => t.Name)
            .IsUnique();
    }
}
