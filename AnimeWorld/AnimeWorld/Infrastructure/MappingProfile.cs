using AnimeWorld.Data.Models;
using AnimeWorld.Services.Animes.Models;
using AnimeWorld.Services.Commets.Models;
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
            this.CreateMap<Anime, SimilarAnimeServiceModel>();
            this.CreateMap<Anime, TopRatedAnime>()
                .ForMember(c => c.Genre, cfg => cfg.MapFrom(c => c.Genres.FirstOrDefault().Genre.Name));

            this.CreateMap<Anime, AnimeServieModel>()
                .ForMember(c => c.Comments, cfg => cfg.MapFrom(c => c.Comments.Count))
                .ForMember(c => c.GenreName, cfg => cfg.MapFrom(c => c.Genres.FirstOrDefault().Genre.Name));

            this.CreateMap<Anime, AnimeDetailsServcieModel>()
                .ForMember(c => c.TypeName, cfg => cfg.MapFrom(c => c.Type.Name))
                .ForMember(c => c.Producers, cfg => cfg.MapFrom(c => c.Producers.Select(p => p.Producer.Name)))
                .ForMember(c => c.Genres, cfg => cfg.MapFrom(c => c.Genres.Select(g => g.Genre.Name)));

            this.CreateMap<Comment, CommentServiceModel>()
                .ForMember(c => c.UserName, cfg => cfg.MapFrom(c => c.User.UserName));
        }
    }
}
