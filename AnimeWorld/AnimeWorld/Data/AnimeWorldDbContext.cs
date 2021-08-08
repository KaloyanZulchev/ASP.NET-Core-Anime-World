using AnimeWorld.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimeWorld.Data
{
    public class AnimeWorldDbContext : IdentityDbContext<User>
    {
        public AnimeWorldDbContext(DbContextOptions<AnimeWorldDbContext> options)
            : base(options)
        {
        }

        public DbSet<Anime> Animes { get; init; }

        public DbSet<Comment> Comments { get; init; }

        public DbSet<Genre> Genres { get; init; }

        public DbSet<Type> Types { get; init; }

        public DbSet<Producer> Producers { get; init; }

        public DbSet<AnimeGenre> AnimesGenres { get; init; }

        public DbSet<AnimeProducer> AnimesProducers { get; init; }

        public DbSet<AnimeUser> AnimesUsers { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<AnimeGenre>()
                .HasKey(ag => new { ag.GenreId, ag.AnimeId });

            builder
                .Entity<AnimeProducer>()
                .HasKey(ap => new { ap.ProducerId, ap.AnimeId });

            builder
                .Entity<AnimeUser>()
                .HasKey(au => new { au.UserId, au.AnimeId });

            builder
                .Entity<AnimeGenre>()
                .HasOne(ag => ag.Genre)
                .WithMany(ag => ag.Animes)
                .HasForeignKey(ag => ag.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AnimeGenre>()
                .HasOne(ag => ag.Anime)
                .WithMany(ag => ag.Genres)
                .HasForeignKey(ag => ag.AnimeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AnimeUser>()
                .HasOne(au => au.User)
                .WithMany(au => au.ListedAnimes)
                .HasForeignKey(au => au.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AnimeUser>()
                .HasOne(au => au.Anime)
                .WithMany(au => au.Users)
                .HasForeignKey(au => au.AnimeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AnimeProducer>()
                .HasOne(ap => ap.Producer)
                .WithMany(ap => ap.Animes)
                .HasForeignKey(ap => ap.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AnimeProducer>()
                .HasOne(ap => ap.Anime)
                .WithMany(ap => ap.Producers)
                .HasForeignKey(ap => ap.AnimeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
