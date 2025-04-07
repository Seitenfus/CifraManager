using CifraManager.Application.Interfaces;
using CifraManager.Application.Services;
using Microsoft.EntityFrameworkCore;
using CifraManager.Infraestructure.Repositories;
using CifraManager.Infraestructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura a conexão com o SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependências
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IThemeRepository, ThemeRepository>();
builder.Services.AddScoped<IThemeService, ThemeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Middleware de desenvolvimento
/* if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} */

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
