using AnimeWorld.Services.Animes.Models;
using System.Collections.Generic;

namespace AnimeWorld.Models.Animes
{
    public class AllAnimesQueryModel
    {
        public const int AnimesPerPage = 6;

        public int CurrentPage { get; init; } = 1;

        public int TypeId { get; init; }

        public int GenreId { get; init; }

        public string SearchTerm { get; init; }

        public int TotalAnimes { get; set; }

        public AnimeSorting Sorting { get; init; }

        public IEnumerable<AnimeGanreServiceModel> Genres { get; set; }

        public IEnumerable<AnimeTypeServiceModel> Types { get; set; }

        public IEnumerable<AnimeServieModel> Animes { get; set; }
    }
}
