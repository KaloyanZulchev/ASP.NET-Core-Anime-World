using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimeWorld.Data.Models
{
    public class User : IdentityUser
    {
        [Url]
        public string ImageURL { get; set; }

        public ICollection<Anime> AddedAnimes { get; init; } = new HashSet<Anime>();

        public ICollection<AnimeUser> ListedAnimes { get; init; } = new HashSet<AnimeUser>();

        public ICollection<Comment> Comments { get; init; } = new HashSet<Comment>();

        public ICollection<Rating> Rateings { get; init; } = new HashSet<Rating>();
    }
}
