namespace AnimeWorld.Data.Models
{
    public class AnimeGenre
    {
        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
