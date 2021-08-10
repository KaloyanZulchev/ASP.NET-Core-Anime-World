using AnimeWorld.Data;
using AnimeWorld.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;

using AnimeType = AnimeWorld.Data.Models.Type;

using static AnimeWorld.WebConstats;

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

            SeedAdministrator(services);
            SeedTypes(services);
            SeedGenres(services);
            //SeedAnimes(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<AnimeWorldDbContext>();

            data.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "rex_k@abv.bg";
                    const string adminPassword = "123456";

                    var user = new User
                    {
                        Id = "rex_k@abv.bgrex_k@abv.bg",
                        Email = adminEmail,
                        UserName = adminEmail,
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void SeedAnimes(IServiceProvider services)
        {
            var data = services.GetRequiredService<AnimeWorldDbContext>();


            if (data.Animes.Any())
            {
                return;
            }


            data.Animes.AddRange(new[]
            {
                new Anime
                { 
                    NameJPN = "Sword Art Online",
                    NameEN = "Sword Art Online",
                    Description = @"In the year 2022, virtual reality has progressed by leaps and bounds, and a massive online role-playing game called Sword Art Online (SAO) is launched. With the aid of ""NerveGear"" technology, players can control their avatars within the game using nothing but their own thoughts.

Kazuto Kirigaya, nicknamed ""Kirito,"" is among the lucky few enthusiasts who get their hands on the first shipment of the game. He logs in to find himself, with ten-thousand others, in the scenic and elaborate world of Aincrad, one full of fantastic medieval weapons and gruesome monsters. However, in a cruel turn of events, the players soon realize they cannot log out; the game's creator has trapped them in his new world until they complete all one hundred levels of the game.

In order to escape Aincrad, Kirito will now have to interact and cooperate with his fellow players. Some are allies, while others are foes, like Asuna Yuuki, who commands the leading group attempting to escape from the ruthless game.To make matters worse, Sword Art Online is not all fun and games: if they die in Aincrad, they die in real life. Kirito must adapt to his new reality, fight for his survival, and hopefully break free from his virtual hell.",
                    Epizodes = 25,
                    Aired = DateTime.ParseExact("08-07-2012", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("23-12-2012", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "https://cdn.myanimelist.net/images/anime/11/39717.jpg",
                    TrailerURL = "https://www.youtube.com/embed/6ohYYtxfDCg",
                    TypeId = 1,
                    Views = new Random().Next(50, 200000),
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
                new Anime
                {
                    NameJPN = "",
                    NameEN = "",
                    Description = "",
                    Epizodes = 0,
                    Aired = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "",
                    TrailerURL = "",
                    TypeId = 1,
                    Views = 0,
                    UserId = ""
                },
            });

            data.SaveChanges();
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
    }
}
