using AnimeWorld.Data.Models;
using AnimeWorld.Services.Animes.Models;
using AutoMapper;
using System.Linq;

namespace AnimeWorld.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Type, AnimeTypeServiceModel>();
            this.CreateMap<Genre, AnimeGanreServiceModel>();
            this.CreateMap<Anime, TopViewsAnime>();
            this.CreateMap<Anime, TopRatedAnime>()
                .ForMember(c => c.Genre, cfg => cfg.MapFrom(c => c.Genres.FirstOrDefault().Genre.Name));

            this.CreateMap<Anime, AnimeServieModel>()
                .ForMember(c => c.Comments, cfg => cfg.MapFrom(c => c.Comments.Count))
                .ForMember(c => c.GenreName, cfg => cfg.MapFrom(c => c.Genres.FirstOrDefault().Genre.Name));
        }
    }
}
