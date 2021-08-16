namespace AnimeWorld.Services.Ratings
{
    public interface IRatingService
    {
        int Create(int stars, int animeId, string userId);

        double CalculateRating(int animeId);

        int VotesCount(int animeId);
    }
}
