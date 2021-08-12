namespace AnimeWorld.Services.Commets
{
    public interface ICommentService
    {
        int Create(int animeId, string userId, string content);
    }
}
