using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static AnimeWorld.Data.DataConstants.Producer;

namespace AnimeWorld.Data.Models
{
    public class Producer
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<AnimeProducer> Animes { get; init; } = new HashSet<AnimeProducer>();
    }
}
