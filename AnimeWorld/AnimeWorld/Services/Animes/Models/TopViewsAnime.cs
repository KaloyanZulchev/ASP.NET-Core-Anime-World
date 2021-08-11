namespace AnimeWorld.Services.Animes.Models
{
    public class TopViewsAnime
    {
        public const int AnimesPerPage = 5;

        public int Id { get; init; }

        public string NameJPN { get; init; }

        public string NameEN { get; init; }

        public int Epizodes { get; init; }

        public int Views { get; init; }

        public string ImageURL { get; init; }
    }
}
