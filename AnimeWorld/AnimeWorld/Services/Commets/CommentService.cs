using AnimeWorld.Data;
using AnimeWorld.Data.Models;
using AnimeWorld.Services.Commets.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;

namespace AnimeWorld.Services.Commets
{
    public class CommentService : ICommentService
    {
        private readonly AnimeWorldDbContext data;
        private readonly IConfigurationProvider mapper;

        public CommentService(AnimeWorldDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
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

        public IEnumerable<CommentServiceModel> AllByAnimeId(int animeId)
            => this.data
                .Comments
                .Where(c => c.AnimeId == animeId)
                .ProjectTo<CommentServiceModel>(this.mapper)
                .ToList();
    }
}
