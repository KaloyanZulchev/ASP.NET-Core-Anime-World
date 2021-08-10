using AnimeWorld.Data;
using AnimeWorld.Data.Models;
using AnimeWorld.Models;
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

        public AnimeQueryServieModel All(
            string searchTerm = null,
            int typeId = 0,
            int genreId = 0,
            int carsPerPage = 1,
            AnimeSorting sorting = AnimeSorting.DateCreated,
            int currentPage = 1)
        {
            var animeQuery = this.data.Animes.AsQueryable();

            if (typeId != 0)
            {
                animeQuery = animeQuery
                    .Where(a => a.TypeId == typeId);
            }

            if (genreId != 0)
            {
                animeQuery = animeQuery
                    .Where(a => a.Genres.Any(g => g.GenreId == genreId));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                animeQuery = animeQuery
                    .Where(a => (a.NameJPN + " " + a.NameEN).ToLower().Contains(searchTerm.ToLower())
                    || a.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            animeQuery = sorting switch
            {
                AnimeSorting.Alphabetically => animeQuery.OrderBy(a => a.NameJPN),
                AnimeSorting.MostViews => animeQuery.OrderByDescending(a => a.Views),
                AnimeSorting.DateCreated or _ => animeQuery.OrderByDescending(a => a.Id)
            };

            var totalAnimes = animeQuery.Count();

            var animes = animeQuery
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage)
                .ProjectTo<AnimeServieModel>(this.mapper)
                .ToList();

            return new AnimeQueryServieModel
            {
                Animes = animes,
                TotalAnimes = totalAnimes
            };
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

        public IEnumerable<AnimeGanreServiceModel> AllGenres()
            => this.data
                .Genres
                .ProjectTo<AnimeGanreServiceModel>(this.mapper)
                .ToList();

        public IEnumerable<AnimeTypeServiceModel> AllTypes()
            => this.data
                .Types
                .ProjectTo<AnimeTypeServiceModel>(this.mapper)
                .ToList();

        public bool GenreExist(int genreId)
            => this.data
                .Genres
                .Any(g => g.Id == genreId);

        public bool TypeExist(int typeId)
            => this.data
                .Types
                .Any(t => t.Id == typeId);
    }
}
