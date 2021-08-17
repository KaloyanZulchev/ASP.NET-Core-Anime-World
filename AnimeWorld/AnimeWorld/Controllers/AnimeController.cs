using AnimeWorld.Infrastructure.Extensions;
using AnimeWorld.Models.Animes;
using AnimeWorld.Services.Animes;
using AnimeWorld.Services.Animes.Models;
using AnimeWorld.Services.Commets;
using AnimeWorld.Services.Ratings;
using AnimeWorld.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimeWorld.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IAnimeService animes;
        private readonly IRatingService ratings;
        private readonly ICommentService comments;
        private readonly IUserService users;

        public AnimeController(
            IAnimeService anime,
            IRatingService ratings,
            ICommentService comments,
            IUserService users)
        {
            this.animes = anime;
            this.ratings = ratings;
            this.comments = comments;
            this.users = users;
        }

        public IActionResult All([FromQuery] AllAnimesQueryModel query)
        {
            var queryResult = this.animes.All(
                null,
                query.CurrentPage,
                query.SearchTerm,
                query.TypeId,
                query.GenreId,
                AllAnimesQueryModel.AnimesPerPage,
                query.Sorting);

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
                anime.Producer,
                anime.Aired,
                anime.Finished,
                anime.TypeId,
                anime.GenerId,
                this.User.Id());

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.animes.IsOnUser(id, this.User.Id()))
            {
                return BadRequest();
            }

            var animeModel = this.animes.ById(id);

            return View(new AnimeEditFormModel
            {
                Id = id,
                NameJPN = animeModel.NameJPN,
                NameEN = animeModel.NameEN,
                Description = animeModel.Description,
                Epizodes = animeModel.Epizodes,
                ImageURL = animeModel.ImageURL,
                TrailerURL = animeModel.TrailerURL,
                Aired = animeModel.Aired,
                Finished = animeModel.Finished,
                TypeId = animeModel.TypeId,
                Types = this.animes.AllTypes()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(AnimeEditFormModel anime)
        {
            this.ModelState.ClearValidationState("Producer");
            this.ModelState.MarkFieldValid("Producer");

            if (!this.animes.TypeExist(anime.TypeId))
            {
                this.ModelState.AddModelError(nameof(anime.TypeId), "Type does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                anime.Types = this.animes.AllTypes();

                return View(anime);
            }

            this.animes.Edit(
                    anime.Id,
                    anime.NameJPN,
                    anime.NameEN,
                    anime.Description,
                    anime.Epizodes,
                    anime.ImageURL,
                    anime.TrailerURL,
                    anime.Aired,
                    anime.Finished,
                    anime.TypeId);

            return RedirectToAction("Details", "Anime", new { Id = anime.Id });
        }

        public IActionResult Details(int id)
        {
            if (!this.animes.IsValidId(id))
            {
                return BadRequest();
            }

            this.animes.IncreaseViews(id);

            var isFollow = false;

            if (this.User.FindFirst(ClaimTypes.NameIdentifier) != null)
            {
                isFollow = this.users.IsFollow(id, this.User.Id());
            }

            return View(new AnimeDetailsViewModel()
            {
                IsFollow = isFollow,
                Anime = this.animes.Details(id),
                SimilarAnimes = this.animes.SimilarAnimes(id),
                Comments = this.comments.AllByAnimeId(id),
                Rating = new RatingInformation { Rating = this.ratings.CalculateRating(id),
                                                 Votes = this.ratings.VotesCount(id)}
            });
        }

        [Authorize]
        public IActionResult Mine([FromQuery] AllAnimesQueryModel query)
        {
            var queryResult = this.animes.All(
                this.User.Id(),
                query.CurrentPage);

            query.Animes = queryResult.Animes;

            foreach (var anime in query.Animes)
            {
                anime.IsOnMinePage = true;
            }

            query.TotalAnimes = queryResult.TotalAnimes;

            return View(query);
        }

        public IActionResult Watch(int id)
        {
            if (!this.animes.IsValidId(id))
            {
                return BadRequest();
            }

            return View(null, this.animes.Trailer(id));
        }
    }
}
