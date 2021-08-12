using AnimeWorld.Infrastructure.Extensions;
using AnimeWorld.Models.Animes;
using AnimeWorld.Services.Animes;
using AnimeWorld.Services.Commets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWorld.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IAnimeService animes;
        private readonly ICommentService comments;

        public AnimeController(IAnimeService anime, ICommentService comments)
        {
            this.animes = anime;
            this.comments = comments;
        }

        public IActionResult All([FromQuery] AllAnimesQueryModel query)
        {
            var queryResult = this.animes.All(
                query.SearchTerm,
                query.TypeId,
                query.GenreId,
                AllAnimesQueryModel.AnimesPerPage,
                query.Sorting,
                query.CurrentPage);

            query.Genres = this.animes.AllGenres();
            query.Types = this.animes.AllTypes();

            query.Animes = queryResult.Animes;
            query.TopViewsAnimes = this.animes.TopViewsAnimes();
            query.TotalAnimes = queryResult.TotalAnimes;

            return View(query);
        }

        [Authorize]
        public IActionResult Add()
            => View(new AnimeFormModel
                {
                    Types = this.animes.AllTypes(),
                    Geners = this.animes.AllGenres()
                });

        [HttpPost]
        [Authorize]
        public IActionResult Add(AnimeFormModel anime)
        {
            if (!this.animes.TypeExist(anime.TypeId))
            {
                this.ModelState.AddModelError(nameof(anime.TypeId), "Type does not exist.");
            }

            if (!this.animes.GenreExist(anime.GenerId))
            {
                this.ModelState.AddModelError(nameof(anime.GenerId), "Genre does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                anime.Types = this.animes.AllTypes();
                anime.Geners = this.animes.AllGenres();

                return View(anime);
            }

            var animeId = this.animes.Create(
                anime.NameJPN,
                anime.NameEN,
                anime.Description,
                anime.Epizodes,
                anime.ImageURL,
                anime.TrailerURL,
                anime.Aired,
                anime.Finished,
                anime.TypeId,
                anime.GenerId,
                this.User.Id());

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            if (!this.animes.IsValidId(id))
            {
                return BadRequest();
            }

            return View(new AnimeDetailsViewModel()
            {
                Anime = this.animes.Details(id),
                Comments = this.comments.AllByAnimeId(id)
            });
        }
    }
}
