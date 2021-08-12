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
            DateTime aired,
            DateTime? finished,
            int typeId,
            int genreId,
            string userId);

        AnimeQueryServieModel All(
            string searchTerm = null,
            int typeId = 0,
            int genreId = 0,
            int animesPerPage = AnimeServieModel.AimesPerPage,
            AnimeSorting sorting = AnimeSorting.DateCreated,
            int currentPage = 1);

        AnimeDetailsServcieModel Details(int id);

        IEnumerable<TopViewsAnime> TopViewsAnimes();

        IEnumerable<TopRatedAnime> TopRatedAnimes();

        bool GenreExist(int genreId);

        bool TypeExist(int typeId);

        IEnumerable<AnimeGanreServiceModel> AllGenres();

        IEnumerable<AnimeTypeServiceModel> AllTypes();

        bool IsValidId(int id);
    }
}
