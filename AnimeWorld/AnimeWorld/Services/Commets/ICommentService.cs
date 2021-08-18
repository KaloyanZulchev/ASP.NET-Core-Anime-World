using AnimeWorld.Services.Commets.Models;
using System.Collections.Generic;

namespace AnimeWorld.Services.Commets
{
    public interface ICommentService
    {
        int Create(int animeId, string userId, string content);

        bool Delete(int id);

        IEnumerable<CommentServiceModel> AllByAnimeId(int animeId);

        bool IsValidId(int id);
    }
}
