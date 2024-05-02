using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using Disertatie_backend.Entities.User;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MongoDB.Bson;

namespace Disertatie_backend.DatabaseContext
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>,
        AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DataContext()
        {
        }
        public DbSet<Message> Messages { get; init; }
        public DbSet<Group> Groups { get; init; }
        public DbSet<Connection> Connections { get; init; }
        public DbSet<Friendships> Friends { get; init; }
        public DbSet<Review> Reviews { get; init; }
        public DbSet<AppUserAnimeItem> UserAnimes { get; init; }
        public DbSet<AppUserMangaItem> UserMangas { get; init; }
        public DbSet<AppUserGameItem> UserGames { get; init; }
        public DbSet<AppUserMovieItem> UserMovies { get; init; }
        public DbSet<AppUserTvShowItem> UserTvShows { get; init; }
        public DbSet<AppUserBookItem> UserBooks { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var converter = new ValueConverter<ObjectId, string>(
                v => v.ToString(),
                v => ObjectId.Parse(v),
                new ConverterMappingHints(size: 24)); // Assuming ObjectId string representation length is 24

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

            builder.Entity<Friendships>()
                .HasKey(f => new { f.UserID1, f.UserID2 });

            builder.Entity<Friendships>()
                .HasOne(f => f.User1)
                .WithMany(s => s.Friends)
                .HasForeignKey(f => f.UserID1)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Friendships>()
                .HasOne(f => f.User2)
                .WithMany()
                .HasForeignKey(f => f.UserID2)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            builder.Entity<AppUserAnimeItem>()
                .HasKey(ua => new { ua.AppUserId, ua.AnimeId });

            builder.Entity<AppUserAnimeItem>()
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.AppUserAnime)
                .HasForeignKey(ua => ua.AppUserId);

            builder.Entity<AppUserMangaItem>()
                .HasKey(ua => new { ua.AppUserId, ua.MangaId });

            builder.Entity<AppUserMangaItem>()
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.AppUserManga)
                .HasForeignKey(ua => ua.AppUserId);

            builder.Entity<AppUserGameItem>()
                .HasKey(ua => new { ua.AppUserId, ua.GameId });

            builder.Entity<AppUserGameItem>()
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.AppUserGame)
                .HasForeignKey(ua => ua.AppUserId);

            builder.Entity<AppUserMovieItem>()
                .HasKey(ua => new { ua.AppUserId, ua.MovieId });

            builder.Entity<AppUserMovieItem>()
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.AppUserMovie)
                .HasForeignKey(ua => ua.AppUserId);

            builder.Entity<AppUserTvShowItem>()
                .HasKey(ua => new { ua.AppUserId, ua.TvShowId });

            builder.Entity<AppUserTvShowItem>()
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.AppUserTvShow)
                .HasForeignKey(ua => ua.AppUserId);

            builder.Entity<AppUserBookItem>()
                .HasKey(ua => new { ua.AppUserId, ua.BookId });

            builder.Entity<AppUserBookItem>()
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.AppUserBook)
                .HasForeignKey(ua => ua.AppUserId);

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews) // Navigation property for user reviews
                .HasForeignKey(r => r.UserId);

            //builder.Entity<UserFriend>()
            //    .HasKey(k => new { k.AddedByUserId, k.AddedUserId });

            //builder.Entity<UserFriend>()
            //    .HasOne(s => s.AddedByUser)
            //    .WithMany(l => l.AddedUsers)
            //    .HasForeignKey(s => s.AddedByUserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<UserFriend>()
            //    .HasOne(s => s.AddedUser)
            //    .WithMany(l => l.AddedByUsers)
            //    .HasForeignKey(s => s.AddedUserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<AppUserMovieItem>()
            //    .HasKey(bc => new { bc.AppUserId, bc.MovieId });
            //builder.Entity<AppUserMovieItem>()
            //    .HasOne(bc => bc.AppUser)
            //    .WithMany(b => b.AppUserMovie)
            //    .HasForeignKey(bc => bc.AppUserId);
            //builder.Entity<AppUserMovieItem>()
            //    .HasOne(bc => bc.MovieItem)
            //    .WithMany(c => c.AppUserMovie)
            //    .HasForeignKey(bc => bc.MovieId);

            //builder.Entity<AppUserTvShowItem>()
            //    .HasKey(bc => new { bc.AppUserId, bc.TvShowId });
            //builder.Entity<AppUserTvShowItem>()
            //    .HasOne(bc => bc.AppUser)
            //    .WithMany(b => b.AppUserTvShow)
            //    .HasForeignKey(bc => bc.AppUserId);
            //builder.Entity<AppUserTvShowItem>()
            //    .HasOne(bc => bc.TvShowItem)
            //    .WithMany(c => c.AppUserTvShow)
            //    .HasForeignKey(bc => bc.TvShowId);

            //builder.Entity<AppUserAnimeItem>()
            //    .HasKey(bc => new { bc.AppUserId, bc.AnimeId });
            //builder.Entity<AppUserAnimeItem>()
            //    .HasOne(bc => bc.AppUser)
            //    .WithMany(b => b.AppUserAnime)
            //    .HasForeignKey(bc => bc.AppUserId);
            //builder.Entity<AppUserAnimeItem>()
            //    .HasOne(bc => bc.AnimeItem)
            //    .WithMany(c => c.AppUserAnime)
            //    .HasForeignKey(bc => bc.AnimeId);

            //builder.Entity<AppUserMangaItem>()
            //    .HasKey(bc => new { bc.AppUserId, bc.MangaId });
            //builder.Entity<AppUserMangaItem>()
            //    .HasOne(bc => bc.AppUser)
            //    .WithMany(b => b.AppUserManga)
            //    .HasForeignKey(bc => bc.AppUserId);
            //builder.Entity<AppUserMangaItem>()
            //    .HasOne(bc => bc.MangaItem)
            //    .WithMany(c => c.AppUserManga)
            //    .HasForeignKey(bc => bc.MangaId);

            //builder.Entity<AppUserGameItem>()
            //    .HasKey(bc => new { bc.AppUserId, bc.GameId });
            //builder.Entity<AppUserGameItem>()
            //    .HasOne(bc => bc.AppUser)
            //    .WithMany(b => b.AppUserGame)
            //    .HasForeignKey(bc => bc.AppUserId);
            //builder.Entity<AppUserGameItem>()
            //    .HasOne(bc => bc.GameItem)
            //    .WithMany(c => c.AppUserGame)
            //    .HasForeignKey(bc => bc.GameId);

            //builder.Entity<TvSeriesInfo>()
            //.Property(e => e.Seasons)
            //.HasConversion(
            //    v => string.Join(',', v),
            //    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            //builder.Entity<UserLoginInfo>()
            //.HasNoKey() // If a keyless entity
            //.Ignore(p => p.ProviderDisplayName);
        }
    }
}
