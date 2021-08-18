using AnimeWorld.Services.Animes.Models;
using System.Collections.Generic;

namespace AnimeWorld.Models.Animes
{
    public class FollowAnimesViewModel
    {
        public const int AnimesPerPage = 6;

        public int CurrentPage { get; init; } = 1;

        public int TotalAnimes { get; set; }

        public IEnumerable<AnimeServieModel> Animes { get; set; }
    }
}
