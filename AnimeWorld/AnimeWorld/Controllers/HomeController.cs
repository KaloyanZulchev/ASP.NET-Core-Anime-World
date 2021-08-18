using AnimeWorld.Models;
using AnimeWorld.Models.Animes;
using AnimeWorld.Services.Animes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AnimeWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnimeService animes;

        public HomeController(ILogger<HomeController> logger, IAnimeService animes)
        {
            _logger = logger;
            this.animes = animes;
        }

        public IActionResult Index()
            => View(new HomePageAnimesModel
                {
                    Animes = this.animes.All().Animes,
                    TopRatedAnimes = this.animes.TopRatedAnimes(),
                    TopViewsAnimes = this.animes.TopViewsAnimes()
                });

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
