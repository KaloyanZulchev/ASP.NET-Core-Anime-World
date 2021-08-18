using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeWorld.Areas.Admin.Controllers
{
    [Area(WebConstats.AdminAreaName)]
    [Authorize(Roles = WebConstats.AdministratorRoleName)]
    public class AdminController : Controller
    {
        [Authorize]
        public IActionResult Statistics()
            => View();
    }
}
