using AnimeWorld.Models;
using AnimeWorld.Services.Animes.Models;
using System;
using System.Collections.Generic;

namespace AnimeWorld.Services.Animes
{
    public interface IAnimeService
    {
        int Create(
            string nameJPN,
            string nameEN,
            string description,
            int epizodes,
            string imageURL,
            string trailerURL,
            string producerName,
            DateTime aired,
            DateTime? finished,
            int typeId,
            int genreId,
            string userId);

        AnimeQueryServieModel All(
            string userId = null,
            int currentPage = 1,
            string searchTerm = null,
            int typeId = 0,
            int genreId = 0,
            int animesPerPage = AnimeServieModel.AimesPerPage,
            AnimeSorting sorting = AnimeSorting.DateCreated);

        AnimeDetailsServcieModel Details(int id);

        void Edit(
             int id,
             string nameJPN,
             string nameEN,
             string description,
             int epizodes,
             string imageURL,
             string trailerURL,
             DateTime aired,
             DateTime? finished,
             int typeId);

        EditAnimeServiceModel ById(int id);

        IEnumerable<TopViewsAnime> TopViewsAnimes();

        IEnumerable<TopRatedAnime> TopRatedAnimes();

        IEnumerable<SimilarAnimeServiceModel> SimilarAnimes(int id);

        bool GenreExist(int genreId);

        bool TypeExist(int typeId);

        void IncreaseViews(int id);

        string Trailer(int id);

        IEnumerable<AnimeGanreServiceModel> AllGenres();

        IEnumerable<AnimeTypeServiceModel> AllTypes();

        bool IsValidId(int id);

        bool IsOnUser(int id, string userId);
    }
}
