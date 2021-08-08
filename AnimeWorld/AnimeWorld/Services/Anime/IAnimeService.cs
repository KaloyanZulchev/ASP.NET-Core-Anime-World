using AnimeWorld.Services.Anime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeWorld.Services.Anime
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
            DateTime finished,
            int typeId,
            IEnumerable<int> ganreIds);

        bool GanresExists(IEnumerable<int> ganreIds);

        bool TypeExists(int typeId);

        IEnumerable<AnimeGanreServiceModel> AllGanreas();
    }
}
