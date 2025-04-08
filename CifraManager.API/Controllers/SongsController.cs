using AutoMapper;
using CifraManager.Application.Dtos;
using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CifraManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController(ISongService service, IMapper mapper) : ControllerBase
    {
        private readonly ISongService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{id}")]
        public async Task<ActionResult<SongDto>> GetById(int id)
        {
            var song = await _service.GetByIdAsync(id);
            var dto = _mapper.Map<SongDto>(song);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetAll([FromQuery] int? themeId)
        {
            IEnumerable<Song> songs;

            if (themeId.HasValue)
            {
                songs = await _service.GetByThemeAsync(themeId.Value);
            }
            else
            {
                songs = await _service.GetAllAsync();
            }

            var dtoList = _mapper.Map<IEnumerable<SongDto>>(songs);
            return Ok(dtoList);
        }


        [HttpPost]
        public async Task<ActionResult<SongDto>> Create([FromForm] CreateSongDto dto, [FromForm] IFormFile PdfFile)
        {
            if (PdfFile == null || PdfFile.Length == 0)
                return BadRequest("Arquivo PDF não foi enviado.");

            var fileName = $"{Guid.NewGuid()}.pdf";
            var filePath = Path.Combine("Pdfs", fileName);

            Directory.CreateDirectory("Pdfs");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await PdfFile.CopyToAsync(stream);
            }

            var song = _mapper.Map<Song>(dto);
            song.PdfId = int.Parse(Path.GetFileNameWithoutExtension(fileName));
            var result = await _service.AddAsync(song);
            var output = _mapper.Map<SongDto>(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, output);
        }

        [HttpPatch("{id}/theme")]
        public async Task<ActionResult<SongDto>> ChangeTheme(int id, [FromBody] UpdateSongThemeDto dto)
        {
            var result = await _service.ChangeThemeAsync(id, dto.ThemeId, dto.ThemeName);
            var output = _mapper.Map<SongDto>(result);
            return Ok(output);
        }

    }
}
