using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CifraManager.API.Controllers
{
    [ApiController]
    [Route("api/themes")]
    public class ThemesController : ControllerBase
    {
        private readonly IThemeService _themeService;

        public ThemesController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheme([FromBody] ThemeDto dto)
        {
            var theme = new Theme { Name = dto.Name };
            var result = await _themeService.AddThemeAsync(theme);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllThemes()
        {
            var themes = await _themeService.GetAllThemesAsync();
            return Ok(themes);
        }
    }

    public class ThemeDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
