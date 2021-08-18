
using System;

namespace AnimeWorld.Services.Commets.Models
{
    public class CommentServiceModel
    {
        public int Id { get; init; }

        public string UserId { get; init; }

        public string Content { get; init; }

        public int SecondsAfterCreation { get; init; }

        public string UserName { get; init; }

        public string UserImageURL { get; init; }
    }
}
