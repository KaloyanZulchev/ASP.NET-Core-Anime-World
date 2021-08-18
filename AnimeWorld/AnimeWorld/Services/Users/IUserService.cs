namespace AnimeWorld.Services.Users
{
    public interface IUserService
    {
        bool SetImageUrl(string imageUrl, string userId);

        string GetImageUrl(string userId);

        bool FollowAnime(int animeId, string userId);

        bool IsFollow(int animeId, string userId);
    }
}
