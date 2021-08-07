using System.ComponentModel.DataAnnotations;

namespace AnimeWorld.Data.Models
{
    public class Comment
    {
        public int Id { get; init; }

        [Required]
        public string Content { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
