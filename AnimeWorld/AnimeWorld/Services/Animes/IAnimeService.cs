using AnimeWorld.Services.Animes.Models;
using System;
using System.Collections.Generic;

namespace AnimeWorld.Services.Animes
{
    public interface IAnimeService
    {
        int Create(
            string nameJPN,
            string nameEN,
            string description,
            int epizodes,
            string imageURL,
            string trailerURL,
            DateTime aired,
            DateTime? finished,
            int typeId,
            string userId);

        bool GanresExists(IEnumerable<int> ganreIds);

        bool TypeExists(int typeId);

        IEnumerable<AnimeGanreServiceModel> AllGanreas();

        IEnumerable<AnimeTypeServiceModel> AllTypes();
    }
}
