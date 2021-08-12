using AnimeWorld.Services.Animes.Models;
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
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string NameJPN { get; set; }

        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string NameEN { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Range(MinEpizodes, MaxEpizodes)]
        public int Epizodes { get; set; }

        [Required]
        [Url]
        public string ImageURL { get; set; }

        [Url]
        public string TrailerURL { get; set; }

        public DateTime Aired { get; set; }

        public DateTime? Finished { get; set; }

        [Display(Name = "Type")]
        public int TypeId { get; set; }

        [Display(Name = "Gener")]
        public int GenerId { get; set; }

        public IEnumerable<AnimeTypeServiceModel> Types { get; set; }

        public IEnumerable<AnimeGanreServiceModel> Geners { get; set; }
    }
}
