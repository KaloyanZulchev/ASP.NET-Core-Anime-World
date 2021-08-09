using AnimeWorld.Data.Models;
using AnimeWorld.Services.Animes.Models;
using AutoMapper;

namespace AnimeWorld.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Type, AnimeTypeServiceModel>();
            this.CreateMap<Genre, AnimeGanreServiceModel>();
        }
    }
}
