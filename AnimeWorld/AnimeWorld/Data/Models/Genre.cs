using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static AnimeWorld.Data.DataConstants.Genre;

namespace AnimeWorld.Data.Models
{
    public class Genre
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<AnimeGenre> Animes { get; init; } = new HashSet<AnimeGenre>();
    }
}
