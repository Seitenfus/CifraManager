using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;
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
    }

    public class SongUploadDto
    {
        public required string Title { get; set; }
        public int ThemeId { get; set; }
        public required IFormFile PdfFile { get; set; }
    }
}
