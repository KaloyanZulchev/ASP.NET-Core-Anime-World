using AnimeWorld.Infrastructure.Extensions;
using AnimeWorld.Models.Animes;
using AnimeWorld.Services.Animes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWorld.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IAnimeService animes;

        public AnimeController(IAnimeService animes) => this.animes = animes;

        public IActionResult All() => View();

        [Authorize]
        public IActionResult Add()
            => View(new AnimeFormModel
                {
                    Types = this.animes.AllTypes()
                });

        [HttpPost]
        [Authorize]
        public IActionResult Add(AnimeFormModel anime)
        {
            if (!this.animes.TypeExists(anime.TypeId))
            {
                this.ModelState.AddModelError(nameof(anime.TypeId), "Type does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                anime.Types = this.animes.AllTypes();

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
                this.User.Id());

            return RedirectToAction("Index", "Home");
        }
    }
}
