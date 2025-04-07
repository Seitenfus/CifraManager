using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;
using CifraManager.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CifraManager.API.Controllers
{
    [ApiController]
    [Route("api/songs")]
    public class SongsController(ISongService songService) : ControllerBase
    {
        private readonly ISongService _songService = songService;

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] SongUploadDto dto)
        {
            using var stream = new MemoryStream();
            await dto.PdfFile.CopyToAsync(stream);

            var song = new Song
            {
                Title = dto.Title,
                PdfData = stream.ToArray(),
                ThemeId = dto.ThemeId
            };

            var result = await _songService.AddSongAsync(song);
            return Ok(result);
        }

        [HttpPost("get-by-title")]
        public async Task<IActionResult> GetSongsByTitle([FromBody] SongTitleDto dto)
        {
            var songs = await _songService.GetSongsByTitleAsync(dto.Title);
            return Ok(songs);
        }

        [HttpGet("get-by-theme/{id:int}")]
        public async Task<IActionResult> GetSongsByTheme(int id)
        {
            var songs = await _songService.GetSongsByThemeAsync(id);
            return Ok(songs);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSongs()
        {
            var songs = await _songService.GetAllSongsAsync();
            return Ok(songs);
        }

        [HttpPut("change-theme")]
        public async Task<IActionResult> ChangeThemeAsync([FromBody] ChangeThemeDto dto)
        {
            var songs = await _songService.ChangeSongThemeAsync(dto.Id, dto.ThemeId);
            return Ok(songs);
        }
    }
}
