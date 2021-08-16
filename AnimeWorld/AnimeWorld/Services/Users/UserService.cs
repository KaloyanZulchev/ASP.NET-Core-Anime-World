using AnimeWorld.Data;
using AnimeWorld.Data.Models;
using System.Linq;

namespace AnimeWorld.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AnimeWorldDbContext data;

        public UserService(AnimeWorldDbContext data) => this.data = data;

        public void FollowAnime(int animeId, string userId)
        {
            var animeUserData = this.data
                .AnimesUsers
                .FirstOrDefault(au => au.AnimeId == animeId && au.UserId == userId);

            var user = this.data
                        .Users
                        .Find(userId);

            if (animeUserData == null)
            {
                animeUserData = new AnimeUser { AnimeId = animeId, UserId = userId };

                user.ListedAnimes.Add(animeUserData);

                this.data.SaveChanges();
            }
            else
            {
                user.ListedAnimes.Remove(animeUserData);

                this.data.SaveChanges();
            }
        }

        public bool IsFollow(int animeId, string userId)
        {
            if (userId == null)
            {
                return false;
            }

            return this.data.AnimesUsers.Any(au => au.AnimeId == animeId && au.UserId == userId);
        }
    }
}
