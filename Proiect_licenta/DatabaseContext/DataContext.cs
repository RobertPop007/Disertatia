using Microsoft.EntityFrameworkCore;
using Disertatie_backend.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;

namespace Disertatie_backend.DatabaseContext
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>,
        AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<Message> Messages { get; init; }
        public DbSet<Group> Groups { get; init; }
        public DbSet<Connection> Connections { get; init; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
