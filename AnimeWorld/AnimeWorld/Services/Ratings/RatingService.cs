using AnimeWorld.Data;
using AnimeWorld.Data.Models;
using System.Linq;

namespace AnimeWorld.Services.Ratings
{
    public class RatingService : IRatingService
    {
        private readonly AnimeWorldDbContext data;

        public RatingService(AnimeWorldDbContext data) => this.data = data;

        public int Create(int stars, int animeId, string userId)
        {
            var ratingData = this.data
                .Ratings
                .FirstOrDefault(r => r.AnimeId == animeId && r.UserId == userId);

            if (ratingData == null)
            {
                ratingData = new Rating
                {
                    AnimeId = animeId,
                    UserId = userId,
                    Stars = stars
                };

                this.data.Ratings.Add(ratingData);
                this.data.SaveChanges();
            }
            else
            {
                ratingData.Stars = stars;

                this.data.SaveChanges();
            }

            return ratingData.Id;
        }

        public double CalculateRating(int animeId)
        {
            var stars = this.data
                .Ratings
                .Where(r => r.AnimeId == animeId)
                .Select(r => r.Stars)
                .ToList();

            if (stars.Count == 0)
            {
                return 0;
            }

            var rawRating = (stars.Sum() * 1.0) / stars.Count();

            var residue = rawRating % 1;

            if (residue < 0.25)
            {
                residue = 0;
            }
            else if (residue >= 0.25 && residue <= 0.5)
            {
                residue = 0.5;
            }
            else if (residue > 0.5)
            {
                residue = 1;
            }

            var rating = stars.Sum() / stars.Count + residue;

            return rating;
        }

        public int VotesCount(int animeId)
            => this.data
                .Ratings
                .Where(r => r.AnimeId == animeId)
                .Count();
    }
}
