using System.Collections.Generic;

namespace AnimeWorld.Services.Animes.Models
{
    public class AnimeQueryServieModel
    {
        public int TotalAnimes { get; init; }

        public IEnumerable<AnimeServieModel> Animes { get; init; }
    }
}
