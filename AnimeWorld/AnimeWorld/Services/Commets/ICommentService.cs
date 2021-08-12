using AnimeWorld.Services.Commets.Models;
using System.Collections.Generic;

namespace AnimeWorld.Services.Commets
{
    public interface ICommentService
    {
        int Create(int animeId, string userId, string content);

        IEnumerable<CommentServiceModel> AllByAnimeId(int animeId);
    }
}
