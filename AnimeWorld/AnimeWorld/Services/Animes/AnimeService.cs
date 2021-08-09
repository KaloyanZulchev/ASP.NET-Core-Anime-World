using AnimeWorld.Data;
using AnimeWorld.Data.Models;
using AnimeWorld.Services.Animes.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimeWorld.Services.Animes
{
    public class AnimeService : IAnimeService
    {
        private readonly AnimeWorldDbContext data;
        private readonly IConfigurationProvider mapper;

        public AnimeService(AnimeWorldDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public int Create(
            string nameJPN,
            string nameEN,
            string description,
            int epizodes,
            string imageURL,
            string trailerURL,
            DateTime aired,
            DateTime? finished,
            int typeId,
            string userId)
        {
            var animeData = new Anime
            {
                NameJPN = nameJPN,
                NameEN = nameEN,
                Description = description,
                Epizodes = epizodes,
                ImageURL = imageURL,
                TrailerURL = trailerURL,
                Aired = aired,
                Finished = finished,
                TypeId = typeId,
                UserId = userId
            };

            this.data.Animes.Add(animeData);
            this.data.SaveChanges();

            return animeData.Id;
        }

        public IEnumerable<AnimeGanreServiceModel> AllGanreas()
            => this.data
                .Genres
                .ProjectTo<AnimeGanreServiceModel>(this.mapper)
                .ToList();

        public IEnumerable<AnimeTypeServiceModel> AllTypes()
            => this.data
                .Types
                .ProjectTo<AnimeTypeServiceModel>(this.mapper)
                .ToList();

        public bool GanresExists(IEnumerable<int> ganreIds)
        {
            throw new NotImplementedException();
        }

        public bool TypeExists(int typeId)
            => this.data
                .Types
                .Any(t => t.Id == typeId);
    }
}
