using System;

namespace AnimeWorld.Services.Animes.Models
{
    public class EditAnimeServiceModel
    {
        public string NameJPN { get; set; }

        public string NameEN { get; set; }

        public string Description { get; set; }

        public int Epizodes { get; set; }

        public string ImageURL { get; set; }

        public string TrailerURL { get; set; }

        public DateTime Aired { get; set; }

        public DateTime? Finished { get; set; }

        public int TypeId { get; set; }
    }
}
