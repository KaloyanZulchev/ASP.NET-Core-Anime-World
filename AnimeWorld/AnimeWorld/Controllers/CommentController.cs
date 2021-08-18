using AnimeWorld.Infrastructure.Extensions;
using AnimeWorld.Models.Comments;
using AnimeWorld.Services.Animes;
using AnimeWorld.Services.Commets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWorld.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commets;
        private readonly IAnimeService animes;

        public CommentController(ICommentService commets, IAnimeService animes)
        {
            this.commets = commets;
            this.animes = animes;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CommentFormModel comment)
        {
            if (!this.animes.IsValidId(comment.AnimeId))
            {
                return BadRequest();
            }

            if (this.ModelState.IsValid)
            {
                this.commets.Create(
                    comment.AnimeId,
                    this.User.Id(),
                    comment.Content);
            }

            this.TempData[WebConstats.Message] = WebConstats.CommentAddMessage;

            return RedirectToAction("Details", "Anime", new { id = comment.AnimeId});
        }

        [Authorize]
        public IActionResult Delete(int id, int animeId)
        {
            if (!this.animes.IsValidId(animeId) || !this.commets.IsValidId(id))
            {
                return BadRequest();
            }

            this.commets.Delete(id);

            this.TempData[WebConstats.Message] = WebConstats.CommentDeleteMessage;

            return RedirectToAction("Details", "Anime", new { Id = animeId });
        }
    }
}
