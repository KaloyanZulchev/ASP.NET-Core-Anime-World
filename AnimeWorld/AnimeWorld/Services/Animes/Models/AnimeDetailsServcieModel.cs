using System;
using System.Collections.Generic;

namespace AnimeWorld.Services.Animes.Models
{
    public class AnimeDetailsServcieModel
    {
        public int Id { get; init; }

        public string NameJPN { get; init; }

        public string NameEN { get; init; }

        public string Description { get; init; }

        public int Epizodes { get; init; }

        public string ImageURL { get; init; }

        public string TypeName { get; init; }

        public DateTime Aired { get; init; }

        public DateTime? Finished { get; init; }

        public int Views { get; init; }

        public IEnumerable<string> Producers { get; init; }

        public IEnumerable<string> Genres { get; init; }
    }
}
