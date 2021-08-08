using AnimeWorld.Services.Anime.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static AnimeWorld.Data.DataConstants.Anime;

namespace AnimeWorld.Models.Animes
{
    public class AnimeFormModel
    {
        public const string MinDate = "1960-01-01";
        public const string MaxDate = "2026-01-01";

        [Required]
        [MaxLength(NameMaxLength)]
        public string NameJPN { get; set; }

        [MaxLength(NameMaxLength)]
        public string NameEN { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public int Epizodes { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string TrailerURL { get; set; }

        public DateTime Aired { get; set; }

        public DateTime? Finished { get; set; }

        public int TypeId { get; set; }

        public IEnumerable<AnimeGanreServiceModel> Genres { get; set; }
    }
}
