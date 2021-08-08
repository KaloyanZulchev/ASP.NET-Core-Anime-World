using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static AnimeWorld.Data.DataConstants.Type;

namespace AnimeWorld.Data.Models
{
    public class Type
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Anime> Animes { get; init; } = new HashSet<Anime>();
    }
}
