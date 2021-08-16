using System.ComponentModel.DataAnnotations;
using static AnimeWorld.Data.DataConstants.Rating;

namespace AnimeWorld.Models.Ratings
{
    public class RatingFormModel
    {
        public int AnimeId { get; set; }

        [Range(MinStars, MaxStars)]
        public int Stars { get; set; }
    }
}
