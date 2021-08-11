namespace AnimeWorld.Services.Animes.Models
{
    public class TopRatedAnime
    {
        public const int AnimesPerPage = 3;

        public int Id { get; init; }

        public string NameJPN { get; init; }

        public string NameEN { get; init; }

        public string Description { get; init; }

        public string Genre { get; init; }

        public string ImageURL { get; init; }
    }
}
