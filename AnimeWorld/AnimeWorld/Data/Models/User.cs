using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AnimeWorld.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Anime> AddedAnimes { get; init; } = new HashSet<Anime>();

        public ICollection<AnimeUser> ListedAnimes { get; init; } = new HashSet<AnimeUser>();

        public ICollection<Comment> Comments { get; init; } = new HashSet<Comment>();
    }
}
