using AnimeWorld.Infrastructure.Extensions;
using AnimeWorld.Services.Animes;
using AnimeWorld.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWorld.Controllers
{
    public class UserController : Controller
    {
        private readonly IAnimeService animes;
        private readonly IUserService users;

        public UserController(IAnimeService animes, IUserService users)
        {
            this.animes = animes;
            this.users = users;
        }

        [Authorize]
        public IActionResult FollowAnime(int animeId)
        {
            if (!this.animes.IsValidId(animeId))
            {
                return BadRequest();
            }

            this.users.FollowAnime(animeId, this.User.Id());

            return RedirectToAction("Details", "Anime", new { Id = animeId });
        }
    }
}
