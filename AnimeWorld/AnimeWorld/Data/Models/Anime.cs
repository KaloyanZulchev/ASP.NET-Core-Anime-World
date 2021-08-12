using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static AnimeWorld.Data.DataConstants.Anime;

namespace AnimeWorld.Data.Models
{
    public class Anime
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string NameJPN { get; set; }

        [MaxLength(NameMaxLength)]
        public string NameEN { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public int Epizodes { get; set; }

        public int Views { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public string TrailerURL { get; set; }

        public DateTime Aired { get; set; }

        public DateTime? Finished { get; set; }

        public int? NextSeasonId { get; set; }

        public Anime NextSeason { get; set; }

        public int TypeId { get; set; }

        public Type Type { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<AnimeGenre> Genres { get; init; } = new HashSet<AnimeGenre>();

        public ICollection<Comment> Comments { get; init; } = new HashSet<Comment>();

        public ICollection<AnimeProducer> Producers { get; init; } = new HashSet<AnimeProducer>();

        public ICollection<AnimeUser> Users { get; init; } = new HashSet<AnimeUser>();
    }
}
