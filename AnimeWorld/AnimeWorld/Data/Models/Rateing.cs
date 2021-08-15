using System.ComponentModel.DataAnnotations;
using static AnimeWorld.Data.DataConstants.Rating;

namespace AnimeWorld.Data.Models
{
    public class Rateing
    {
        public int Id { get; init; }

        [Range(MinStars, MaxStars)]
        public int Stars { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }
    }
}
