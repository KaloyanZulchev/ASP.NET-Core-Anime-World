using AnimeWorld.Data;
using AnimeWorld.Data.Models;

namespace AnimeWorld.Services.Commets
{
    public class CommentService : ICommentService
    {
        private readonly AnimeWorldDbContext data;

        public CommentService(AnimeWorldDbContext data)
        {
            this.data = data;
        }

        public int Create(int animeId, string userId, string content)
        {
            var commentData = new Comment
            {
                AnimeId = animeId,
                Content = content,
                UserId = userId
            };

            this.data.Comments.Add(commentData);
            this.data.SaveChanges();

            return commentData.Id;
        }
    }
}
