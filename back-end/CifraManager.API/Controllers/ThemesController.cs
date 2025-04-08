using AutoMapper;
using CifraManager.Application.Dtos;
using CifraManager.Application.Interfaces;
using CifraManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CifraManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThemesController(IThemeService service, IMapper mapper) : ControllerBase
    {
        private readonly IThemeService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThemeDto>>> GetAll()
        {
            var themes = await _service.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<ThemeDto>>(themes);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThemeDto>> GetById(int id)
        {
            var theme = await _service.GetByIdAsync(id);
            var dto = _mapper.Map<ThemeDto>(theme);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ThemeDto>> Create([FromBody] CreateThemeDto dto)
        {
            var theme = _mapper.Map<Theme>(dto);
            var result = await _service.AddAsync(theme);
            var output = _mapper.Map<ThemeDto>(result);

            return CreatedAtAction(nameof(GetById), new { id = output.Id }, output);
        }
    }
}
