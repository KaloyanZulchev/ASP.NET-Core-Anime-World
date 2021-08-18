using AnimeWorld.Data;
using AnimeWorld.Data.Models;
using AnimeWorld.Services.Commets.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
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
                DateCreated = DateTime.UtcNow,
                UserId = userId
            };

            this.data.Comments.Add(commentData);
            this.data.SaveChanges();

            return commentData.Id;
        }

        public bool Delete(int id)
        {
            var comment = this.data.Comments.Find(id);

            this.data.Comments.Remove(comment);
            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<CommentServiceModel> AllByAnimeId(int animeId)
            => this.data
                .Comments
                .Where(c => c.AnimeId == animeId)
                .ProjectTo<CommentServiceModel>(this.mapper)
                .ToList();

        public bool IsValidId(int id)
            => this.data
                .Comments
                .Any(c => c.Id == id);
    }
}
