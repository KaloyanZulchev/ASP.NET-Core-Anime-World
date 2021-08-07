using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimeWorld.Data.Models
{
    public class Type
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        public ICollection<Anime> Animes { get; init; } = new HashSet<Anime>();
    }
}
