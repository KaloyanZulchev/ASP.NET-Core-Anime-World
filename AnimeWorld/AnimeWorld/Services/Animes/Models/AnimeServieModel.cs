namespace AnimeWorld.Services.Animes.Models
{
    public class AnimeServieModel
    {
        public string NameJPN { get; init; }

        public string NameEN { get; init; }

        public string ImageURL { get; set; }

        public string TypeName { get; init; }

        public string GenreName { get; init; }

        public int Epizodes { get; init; }

        public int Views { get; init; }

        public int Comments { get; init; }
    }
}
