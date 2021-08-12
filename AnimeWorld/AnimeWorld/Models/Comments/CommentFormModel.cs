using System.ComponentModel.DataAnnotations;
using static AnimeWorld.Data.DataConstants.Comment;

namespace AnimeWorld.Models.Comments
{
    public class CommentFormModel
    {
        public int AnimeId { get; init; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; init; }
    }
}
