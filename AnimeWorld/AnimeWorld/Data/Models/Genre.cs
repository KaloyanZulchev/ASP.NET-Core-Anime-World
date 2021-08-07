using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimeWorld.Data.Models
{
    public class Genre
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        public ICollection<AnimeGenre> Animes { get; init; } = new HashSet<AnimeGenre>();
    }
}
