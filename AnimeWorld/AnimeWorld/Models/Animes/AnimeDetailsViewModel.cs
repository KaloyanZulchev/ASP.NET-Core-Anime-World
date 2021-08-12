using AnimeWorld.Services.Animes.Models;
using AnimeWorld.Services.Commets.Models;
using System.Collections.Generic;

namespace AnimeWorld.Models.Animes
{
    public class AnimeDetailsViewModel
    {
        public AnimeDetailsServcieModel Anime { get; set; }

        public IEnumerable<CommentServiceModel> Comments { get; set; }
    }
}
