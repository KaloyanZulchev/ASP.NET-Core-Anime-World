namespace AnimeWorld.Data.Models
{
    public class AnimeProducer
    {
        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
    }
}
