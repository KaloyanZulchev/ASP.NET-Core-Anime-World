using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimeWorld.Data
{
    public class AnimeWorldDbContext : IdentityDbContext
    {
        public AnimeWorldDbContext(DbContextOptions<AnimeWorldDbContext> options)
            : base(options)
        {
        }
    }
}
