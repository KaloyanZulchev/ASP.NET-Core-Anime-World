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
            int animesPerPage = AnimeServieModel.AimesPerPage,
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
                .Skip((currentPage - 1) * animesPerPage)
                .Take(animesPerPage)
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
            if (nameEN == nameJPN)
            {
                nameEN = null;
            }

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

        public AnimeDetailsServcieModel Details(int id)
            => this.data
                .Animes
                .Where(a => a.Id == id)
                .ProjectTo<AnimeDetailsServcieModel>(this.mapper)
                .FirstOrDefault();

        public IEnumerable<TopViewsAnime> TopViewsAnimes()
            => this.data
                .Animes
                .OrderByDescending(a => a.Views)
                .Take(TopViewsAnime.AnimesPerPage)
                .ProjectTo<TopViewsAnime>(this.mapper)
                .ToList();


        //TO DOO when add ratig refactor this method
        public IEnumerable<TopRatedAnime> TopRatedAnimes()
            => this.data
                .Animes
                .OrderBy(a => a.Views)
                .Take(TopRatedAnime.AnimesPerPage)
                .ProjectTo<TopRatedAnime>(this.mapper)
                .ToList();

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

        public bool IsValidId(int id)
            => this.data
                .Animes
                .Any(a => a.Id == id);
    }
}
