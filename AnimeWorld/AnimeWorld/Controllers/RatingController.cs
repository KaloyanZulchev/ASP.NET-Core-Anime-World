using AnimeWorld.Infrastructure.Extensions;
using AnimeWorld.Models.Ratings;
using AnimeWorld.Services.Animes;
using AnimeWorld.Services.Ratings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWorld.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingService ratings;
        private readonly IAnimeService animes;

        public RatingController(IRatingService ratings, IAnimeService animes)
        {
            this.ratings = ratings;
            this.animes = animes;
        }

        [Authorize]
        public IActionResult Create(RatingFormModel model)
        {
            if (model.Stars > 5 || model.Stars < 1 || !this.animes.IsValidId(model.AnimeId))
            {
                return BadRequest();
            }

            this.ratings.Create(model.Stars, model.AnimeId, this.User.Id());

            this.TempData[WebConstats.Message] = WebConstats.SuccessfulRating;

            return RedirectToAction("Details", "Anime", new { Id = model.AnimeId});
        }
    }
}
