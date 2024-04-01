using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Games.GamesIds;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Entities.TvShows;
using System;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoDbGenericRepository;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Disertatie_backend.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<UserFriend> Friends { get; init; }
        public DbSet<Message> Messages { get; init; }
        public DbSet<Group> Groups { get; init; }
        public DbSet<Connection> Connections { get; init; }
        public DbSet<MovieItem> Top250Movies { get; set; }
        public DbSet<AppUserMovieItem> AppUserMovieItems { get; init; }
        public DbSet<AppUserTvShowItem> AppUserTvShowItems { get; init; }
        public DbSet<AppUserAnimeItem> AppUserAnimeItems { get; set; }
        public DbSet<AppUserMangaItem> AppUserMangaItems { get; init; }
        public DbSet<AppUserGameItem> AppUserGameItems { get; init; }
        public DbSet<TvShowItem> TvShows { get; init; }
        public DbSet<Datum> Anime { get; init; }
        public DbSet<DatumManga> Manga { get; init; }
        public DbSet<Movie> Movies { get; init; }
        public DbSet<TvShow> TrueTvShow { get; init; }
        public DbSet<Result> GamesIds { get; init; }
        public DbSet<Game> Games { get; init; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToCollection("Users");
            builder.Entity<AppRole>().ToCollection("Roles");
            builder.Entity<AppUserAnimeItem>().ToCollection("UsersAnime");
            //builder.Entity<UserFriend>().ToCollection("Friends");
            //builder.Entity<Message>().ToCollection("Messages");
            //builder.Entity<Group>().ToCollection("Groups");
            //builder.Entity<Connection>().ToCollection("Connections");
            //builder.Entity<MovieItem>().ToCollection("MovieItems");
            //builder.Entity<AppUserMovieItem>().ToCollection("Movies for users");
            //builder.Entity<AppUserTvShowItem>().ToCollection("TV  Shows for users");
            //builder.Entity<AppUserAnimeItem>().ToCollection("Animes for users");
            //builder.Entity<AppUserMangaItem>().ToCollection("Mangas for users");
            //builder.Entity<AppUserGameItem>().ToCollection("Games for users");
            //builder.Entity<TvShowItem>().ToCollection("TV Shows Items");
            //builder.Entity<Datum>().ToCollection("Animes");
            //builder.Entity<DatumManga>().ToCollection("Mangas");
            //builder.Entity<Movie>().ToCollection("Movies");
            //builder.Entity<TvShow>().ToCollection("TV Shows");
            //builder.Entity<Result>().ToCollection("GamesIds");
            //builder.Entity<Game>().ToCollection("Games");

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<UserFriend>()
                .HasKey(k => new { k.AddedByUserId, k.AddedUserId });

            builder.Entity<UserFriend>()
                .HasOne(s => s.AddedByUser)
                .WithMany(l => l.AddedUsers)
                .HasForeignKey(s => s.AddedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserFriend>()
                .HasOne(s => s.AddedUser)
                .WithMany(l => l.AddedByUsers)
                .HasForeignKey(s => s.AddedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppUserMovieItem>()
                .HasKey(bc => new { bc.AppUserId, bc.MovieId });
            builder.Entity<AppUserMovieItem>()
                .HasOne(bc => bc.AppUser)
                .WithMany(b => b.AppUserMovie)
                .HasForeignKey(bc => bc.AppUserId);
            builder.Entity<AppUserMovieItem>()
                .HasOne(bc => bc.MovieItem)
                .WithMany(c => c.AppUserMovie)
                .HasForeignKey(bc => bc.MovieId);

            builder.Entity<AppUserTvShowItem>()
                .HasKey(bc => new { bc.AppUserId, bc.TvShowId });
            builder.Entity<AppUserTvShowItem>()
                .HasOne(bc => bc.AppUser)
                .WithMany(b => b.AppUserTvShow)
                .HasForeignKey(bc => bc.AppUserId);
            builder.Entity<AppUserTvShowItem>()
                .HasOne(bc => bc.TvShowItem)
                .WithMany(c => c.AppUserTvShow)
                .HasForeignKey(bc => bc.TvShowId);

            builder.Entity<AppUserAnimeItem>()
                .HasKey(bc => new { bc.AppUserId, bc.AnimeId });
            builder.Entity<AppUserAnimeItem>()
                .HasOne(bc => bc.AppUser)
                .WithMany(b => b.AppUserAnime)
                .HasForeignKey(bc => bc.AppUserId);
            builder.Entity<AppUserAnimeItem>()
                .HasOne(bc => bc.AnimeItem)
                .WithMany(c => c.AppUserAnime)
                .HasForeignKey(bc => bc.AnimeId);

            builder.Entity<AppUserMangaItem>()
                .HasKey(bc => new { bc.AppUserId, bc.MangaId });
            builder.Entity<AppUserMangaItem>()
                .HasOne(bc => bc.AppUser)
                .WithMany(b => b.AppUserManga)
                .HasForeignKey(bc => bc.AppUserId);
            builder.Entity<AppUserMangaItem>()
                .HasOne(bc => bc.MangaItem)
                .WithMany(c => c.AppUserManga)
                .HasForeignKey(bc => bc.MangaId);

            builder.Entity<AppUserGameItem>()
                .HasKey(bc => new { bc.AppUserId, bc.GameId });
            builder.Entity<AppUserGameItem>()
                .HasOne(bc => bc.AppUser)
                .WithMany(b => b.AppUserGame)
                .HasForeignKey(bc => bc.AppUserId);
            builder.Entity<AppUserGameItem>()
                .HasOne(bc => bc.GameItem)
                .WithMany(c => c.AppUserGame)
                .HasForeignKey(bc => bc.GameId);

            builder.Entity<TvSeriesInfo>()
            .Property(e => e.Seasons)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            builder.Entity<UserLoginInfo>()
            .HasNoKey() // If a keyless entity
            .Ignore(p => p.ProviderDisplayName);
        }
    }
}
