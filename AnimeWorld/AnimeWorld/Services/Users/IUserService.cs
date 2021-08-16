namespace AnimeWorld.Services.Users
{
    public interface IUserService
    {
        void FollowAnime(int animeId, string userId);

        bool IsFollow(int animeId, string userId);
    }
}
