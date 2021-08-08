using System.ComponentModel.DataAnnotations;

using static AnimeWorld.Data.DataConstants.Comment;

namespace AnimeWorld.Data.Models
{
    public class Comment
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
