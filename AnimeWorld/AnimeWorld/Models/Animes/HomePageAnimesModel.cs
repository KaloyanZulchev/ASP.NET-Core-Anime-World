using AnimeWorld.Services.Animes.Models;
using System.Collections.Generic;

namespace AnimeWorld.Models.Animes
{
    public class HomePageAnimesModel
    {
        public IEnumerable<TopRatedAnime> TopRatedAnimes { get; set; }

        public IEnumerable<AnimeServieModel> Animes { get; set; }

        public IEnumerable<TopViewsAnime> TopViewsAnimes { get; set; }
    }
}
