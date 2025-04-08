using AutoMapper;
using CifraManager.Application.Dtos;
using CifraManager.Domain.Entities;

namespace CifraManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongDto>();
            CreateMap<CreateSongDto, Song>();
            CreateMap<UpdateSongThemeDto, Song>();

            CreateMap<CreateThemeDto, Theme>();
            CreateMap<Theme, ThemeDto>();
        }
    }
}
