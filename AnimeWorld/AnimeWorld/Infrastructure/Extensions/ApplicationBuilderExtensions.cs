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
            SeedAnimes(services);

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
                    NameEN = null,
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
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Sword Art Online II",
                    NameEN = null,
                    Description = @"A year after escaping Sword Art Online, Kazuto Kirigaya has been settling back into the real world. However, his peace is short-lived as a new incident occurs in a game called Gun Gale Online, where a player by the name of Death Gun appears to be killing people in the real world by shooting them in-game. Approached by officials to assist in investigating the murders, Kazuto assumes his persona of Kirito once again and logs into Gun Gale Online, intent on stopping the killer.

Once inside, Kirito meets Sinon, a highly skilled sniper afflicted by a traumatic past. She is soon dragged in his chase after Death Gun, and together they enter the Bullet of Bullets, a tournament where their target is sure to appear. Uncertain of Death Gun's real powers, Kirito and Sinon race to stop him before he has the chance to claim another life. Not everything goes smoothly, however, as scars from the past impede their progress. In a high-stakes game where the next victim could easily be one of them, Kirito puts his life on the line in the virtual world once more",
                    Epizodes = 24,
                    Aired = DateTime.ParseExact("05-07-2014", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("20-12-2014", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "https://cdn.myanimelist.net/images/anime/11/65185.jpg",
                    TrailerURL = "https://www.youtube.com/embed/Wyi8ITQBeNw",
                    TypeId = 1,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Sword Art Online Movie: Ordinal Scale",
                    NameEN = null,
                    Description = @"In 2026, four years after the infamous Sword Art Online incident, a revolutionary new form of technology has emerged: the Augma, a device that utilizes an Augmented Reality system. Unlike the Virtual Reality of the NerveGear and the Amusphere, it is perfectly safe and allows players to use it while they are conscious, creating an instant hit on the market. The most popular application for the Augma is the game Ordinal Scale, which immerses players in a fantasy role-playing game with player rankings and rewards.

Following the new craze, Kirito's friends dive into the game, and despite his reservations about the system, Kirito eventually joins them. While at first it appears to be just fun and games, they soon find out that the game is not all that it seems...
",
                    Epizodes = 1,
                    Aired = DateTime.ParseExact("18-02-2017", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = null,
                    ImageURL = "https://cdn.myanimelist.net/images/anime/4/83811.jpg",
                    TrailerURL = "https://www.youtube.com/embed/32FLqOWjUfI",
                    TypeId = 6,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Naruto",
                    NameEN = null,
                    Description = @"Moments prior to Naruto Uzumaki's birth, a huge demon known as the Kyuubi, the Nine-Tailed Fox, attacked Konohagakure, the Hidden Leaf Village, and wreaked havoc. In order to put an end to the Kyuubi's rampage, the leader of the village, the Fourth Hokage, sacrificed his life and sealed the monstrous beast inside the newborn Naruto.

Now, Naruto is a hyperactive and knuckle-headed ninja still living in Konohagakure. Shunned because of the Kyuubi inside him, Naruto struggles to find his place in the village, while his burning desire to become the Hokage of Konohagakure leads him not only to some great new friends, but also some deadly foes.",
                    Epizodes = 220,
                    Aired = DateTime.ParseExact("03-10-2002", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("08-02-2007", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "https://cdn.myanimelist.net/images/anime/13/17405.jpg",
                    TrailerURL = "https://youtu.be/j2hiC9BmJlQ",
                    TypeId = 1,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Naruto: Shippuuden",
                    NameEN = null,
                    Description = @"It has been two and a half years since Naruto Uzumaki left Konohagakure, the Hidden Leaf Village, for intense training following events which fueled his desire to be stronger. Now Akatsuki, the mysterious organization of elite rogue ninja, is closing in on their grand plan which may threaten the safety of the entire shinobi world.

Although Naruto is older and sinister events loom on the horizon, he has changed little in personality—still rambunctious and childish—though he is now far more confident and possesses an even greater determination to protect his friends and home. Come whatever may, Naruto will carry on with the fight for what is important to him, even at the expense of his own body, in the continuation of the saga about the boy who wishes to become Hokage.",
                    Epizodes = 500,
                    Aired = DateTime.ParseExact("15-02-2007", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("23-03-2017", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "https://cdn.myanimelist.net/images/anime/5/17407.jpg",
                    TrailerURL = "https://youtu.be/1dy2zPPrKD0",
                    TypeId = 1,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Kimetsu no Yaiba",
                    NameEN = "Demon Slayer",
                    Description = @"Ever since the death of his father, the burden of supporting the family has fallen upon Tanjirou Kamado's shoulders. Though living impoverished on a remote mountain, the Kamado family are able to enjoy a relatively peaceful and happy life. One day, Tanjirou decides to go down to the local village to make a little money selling charcoal. On his way back, night falls, forcing Tanjirou to take shelter in the house of a strange man, who warns him of the existence of flesh-eating demons that lurk in the woods at night.

When he finally arrives back home the next day, he is met with a horrifying sight—his whole family has been slaughtered. Worse still, the sole survivor is his sister Nezuko, who has been turned into a bloodthirsty demon. Consumed by rage and hatred, Tanjirou swears to avenge his family and stay by his only remaining sibling. Alongside the mysterious group calling themselves the Demon Slayer Corps, Tanjirou will do whatever it takes to slay the demons and protect the remnants of his beloved sister's humanity.",
                    Epizodes = 26,
                    Aired = DateTime.ParseExact("06-04-2019", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("28-09-2019", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "https://cdn.myanimelist.net/images/anime/1286/99889.jpg",
                    TrailerURL = "https://youtu.be/6vMuWuWlW4I",
                    TypeId = 1,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Kimetsu no Yaiba Movie: Mugen Ressha-hen",
                    NameEN = "Demon Slayer The Movie: Mugen Train",
                    Description = @"After a string of mysterious disappearances begin to plague a train, the Demon Slayer Corps' multiple attempts to remedy the problem prove fruitless. To prevent further casualties, the flame pillar, Kyoujurou Rengoku, takes it upon himself to eliminate the threat. Accompanying him are some of the Corps' most promising new blood: Tanjirou Kamado, Zenitsu Agatsuma, and Inosuke Hashibira, who all hope to witness the fiery feats of this model demon slayer firsthand.

Unbeknownst to them, the demonic forces responsible for the disappearances have already put their sinister plan in motion. Under this demonic presence, the group must muster every ounce of their willpower and draw their swords to save all two hundred passengers onboard. Kimetsu no Yaiba Movie: Mugen Ressha-hen delves into the deepest corners of Tanjirou's mind, putting his resolve and commitment to duty to the test.",
                    Epizodes = 1,
                    Aired = DateTime.ParseExact("16-10-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = null,
                    ImageURL = "https://cdn.myanimelist.net/images/anime/1704/106947.jpg",
                    TrailerURL = "https://youtu.be/PrZ0O8Qp18s",
                    TypeId = 6,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Shingeki no Kyojin",
                    NameEN = "Attack on Titan",
                    Description = @"Centuries ago, mankind was slaughtered to near extinction by monstrous humanoid creatures called titans, forcing humans to hide in fear behind enormous concentric walls. What makes these giants truly terrifying is that their taste for human flesh is not born out of hunger but what appears to be out of pleasure. To ensure their survival, the remnants of humanity began living within defensive barriers, resulting in one hundred years without a single titan encounter. However, that fragile calm is soon shattered when a colossal titan manages to breach the supposedly impregnable outer wall, reigniting the fight for survival against the man-eating abominations.

After witnessing a horrific personal loss at the hands of the invading creatures, Eren Yeager dedicates his life to their eradication by enlisting into the Survey Corps, an elite military unit that combats the merciless humanoids outside the protection of the walls. Based on Hajime Isayama's award-winning manga, Shingeki no Kyojin follows Eren, along with his adopted sister Mikasa Ackerman and his childhood friend Armin Arlert, as they join the brutal war against the titans and race to discover a way of defeating them before the last walls are breached.",
                    Epizodes = 25,
                    Aired = DateTime.ParseExact("07-04-2013", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("29-09-2013", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "https://cdn.myanimelist.net/images/anime/10/47347.jpg",
                    TrailerURL = "https://youtu.be/LHtdKWJdif4",
                    TypeId = 1,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Jujutsu Kaisen",
                    NameEN = null,
                    Description = @"Idly indulging in baseless paranormal activities with the Occult Club, high schooler Yuuji Itadori spends his days at either the clubroom or the hospital, where he visits his bedridden grandfather. However, this leisurely lifestyle soon takes a turn for the strange when he unknowingly encounters a cursed item. Triggering a chain of supernatural occurrences, Yuuji finds himself suddenly thrust into the world of Curses—dreadful beings formed from human malice and negativity—after swallowing the said item, revealed to be a finger belonging to the demon Sukuna Ryoumen, the ""King of Curses.""

Yuuji experiences first-hand the threat these Curses pose to society as he discovers his own newfound powers. Introduced to the Tokyo Metropolitan Jujutsu Technical High School, he begins to walk down a path from which he cannot return—the path of a Jujutsu sorcerer.
",
                    Epizodes = 24,
                    Aired = DateTime.ParseExact("03-10-2020", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("27-03-2021", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "https://cdn.myanimelist.net/images/anime/1171/109222.jpg",
                    TrailerURL = "https://youtu.be/4A_X-Dvl0ws",
                    TypeId = 1,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Youjo Senki",
                    NameEN = "Saga of Tanya the Evil",
                    Description = @"Tanya Degurechaff is a young soldier infamous for predatorial-like ruthlessness and an uncanny, tactical aptitude, earning her the nickname of the ""Devil of the Rhine."" Underneath her innocuous appearance, however, lies the soul of a man who challenged Being X, the self-proclaimed God, to a battle of wits—which resulted in him being reincarnated as a little girl into a world of magical warfare. Hellbent on defiance, Tanya resolves to ascend the ranks of her country's military as it slowly plunges into world war, with only Being X proving to be the strongest obstacle in recreating the peaceful life she once knew. But her perceptive actions and combat initiative have an unintended side effect: propelling the mighty Empire into becoming one of the most powerful nations in mankind's history.",
                    Epizodes = 12,
                    Aired = DateTime.ParseExact("06-01-2017", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("31-03-2017", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "https://cdn.myanimelist.net/images/anime/5/82890.jpg",
                    TrailerURL = "https://youtu.be/eQXrx39ImTI",
                    TypeId = 1,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
                },
                new Anime
                {
                    NameJPN = "Shokugeki no Souma",
                    NameEN = "Food Wars!",
                    Description = @"Ever since he was a child, fifteen-year-old Souma Yukihira has helped his father by working as the sous chef in the restaurant his father runs and owns. Throughout the years, Souma developed a passion for entertaining his customers with his creative, skilled, and daring culinary creations. His dream is to someday own his family's restaurant as its head chef.

Yet when his father suddenly decides to close the restaurant to test his cooking abilities in restaurants around the world, he sends Souma to Tootsuki Culinary Academy, an elite cooking school where only 10 percent of the students graduate. The institution is famous for its ""Shokugeki"" or ""food wars,"" where students face off in intense, high-stakes cooking showdowns.

As Souma and his new schoolmates struggle to survive the extreme lifestyle of Tootsuki, more and greater challenges await him, putting his years of learning under his father to the test.",
                    Epizodes = 24,
                    Aired = DateTime.ParseExact("04-04-2015", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Finished = DateTime.ParseExact("26-09-2015", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ImageURL = "https://cdn.myanimelist.net/images/anime/3/72943.jpg",
                    TrailerURL = "https://youtu.be/H-4Qyr_3V-E",
                    TypeId = 1,
                    Views = new Random().Next(50, 200000),
                    UserId = "rex_k@abv.bgrex_k@abv.bg"
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
