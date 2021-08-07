using System.Collections.Generic;

namespace AnimeWorld.Data.Models
{
    public class Producer
    {
        public int Id { get; init; }

        public ICollection<AnimeProducer> Animes { get; init; } = new HashSet<AnimeProducer>();
    }
}
