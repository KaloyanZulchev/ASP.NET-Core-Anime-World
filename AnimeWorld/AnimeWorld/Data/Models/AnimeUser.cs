using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeWorld.Data.Models
{
    public class AnimeUser
    {
        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
