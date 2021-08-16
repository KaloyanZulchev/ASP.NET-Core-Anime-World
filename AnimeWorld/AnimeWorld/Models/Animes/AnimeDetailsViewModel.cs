using AnimeWorld.Services.Animes.Models;
using AnimeWorld.Services.Commets.Models;
using System.Collections.Generic;

namespace AnimeWorld.Models.Animes
{
    public class AnimeDetailsViewModel
    {
        public bool IsFollow { get; set; }

        public AnimeDetailsServcieModel Anime { get; set; }

        public RatingInformation Rating { get; set; }

        public IEnumerable<SimilarAnimeServiceModel> SimilarAnimes { get; set; }

        public IEnumerable<CommentServiceModel> Comments { get; set; }
    }
}
