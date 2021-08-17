namespace AnimeWorld.Services.Users
{
    public interface IUserService
    {
        bool SetImageUrl(string imageUrl, string userId);

        string GetImageUrl(string userId);

        void FollowAnime(int animeId, string userId);

        bool IsFollow(int animeId, string userId);
    }
}
