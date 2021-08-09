using AnimeWorld.Data;
using AnimeWorld.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

using AnimeType = AnimeWorld.Data.Models.Type;

namespace AnimeWorld.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedTypes(services);
            SeedGenres(services);
            SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<AnimeWorldDbContext>();

            data.Database.Migrate();
        }

        private static void SeedTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<AnimeWorldDbContext>();

            if (data.Types.Any())
            {
                return;
            }

            data.Types.AddRange(new[]
            {
                new AnimeType {Name = "TV"},
                new AnimeType {Name = "ONA"},
                new AnimeType {Name = "OVA"},
                new AnimeType {Name = "Speial"},
                new AnimeType {Name = "Music"},
                new AnimeType {Name = "Movie"},
            });

            data.SaveChanges();
        }

        private static void SeedGenres(IServiceProvider services)
        {
            var data = services.GetRequiredService<AnimeWorldDbContext>();

            if (data.Genres.Any())
            {
                return;
            }

            data.Genres.AddRange(new[]
            {
                new Genre {Name = "Action"},
                new Genre {Name = "Adventure"},
                new Genre {Name = "Cars"},
                new Genre {Name = "Comedy"},
                new Genre {Name = "Dementia"},
                new Genre {Name = "Demons"},
                new Genre {Name = "Mystery"},
                new Genre {Name = "Drama"},
                new Genre {Name = "Ecchi"},
                new Genre {Name = "Fantasy"},
                new Genre {Name = "Game"},
                new Genre {Name = "Hentai"},
                new Genre {Name = "Historical"},
                new Genre {Name = "Horror"},
                new Genre {Name = "Kids"},
                new Genre {Name = "Magic"},
                new Genre {Name = "Martial Arts"},
                new Genre {Name = "Mecha"},
                new Genre {Name = "Music"},
                new Genre {Name = "Parody"},
                new Genre {Name = "Samurai"},
                new Genre {Name = "Romance"},
                new Genre {Name = "School"},
                new Genre {Name = "Sci-Fi"},
                new Genre {Name = "Shoujo"},
                new Genre {Name = "Shoujo Ai"},
                new Genre {Name = "Shounen"},
                new Genre {Name = "Shounen Ai"},
                new Genre {Name = "Space"},
                new Genre {Name = "Sports"},
                new Genre {Name = "Super Power"},
                new Genre {Name = "Vampire"},
                new Genre {Name = "Yaoi"},
                new Genre {Name = "Yuri"},
                new Genre {Name = "Harem"},
                new Genre {Name = "Slice of Life"},
                new Genre {Name = "Supernatural"},
                new Genre {Name = "Military"},
                new Genre {Name = "Police"},
                new Genre {Name = "Psychological"},
                new Genre {Name = "Thriller"},
                new Genre {Name = "Seinen"},
                new Genre {Name = "Josei"},
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            //var userManager = services.GetRequiredService<UserManager<User>>();
            //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            //Task
            //    .Run(async () =>
            //    {
            //        if (await roleManager.RoleExistsAsync(AdministratorRoleName))
            //        {
            //            return;
            //        }

            //        var role = new IdentityRole { Name = AdministratorRoleName };

            //        await roleManager.CreateAsync(role);

            //        const string adminEmail = "admin@crs.com";
            //        const string adminPassword = "admin12";

            //        var user = new User
            //        {
            //            Email = adminEmail,
            //            UserName = adminEmail,
            //            FullName = "Admin"
            //        };

            //        await userManager.CreateAsync(user, adminPassword);

            //        await userManager.AddToRoleAsync(user, role.Name);
            //    })
            //    .GetAwaiter()
            //    .GetResult();
        }
    }
}
