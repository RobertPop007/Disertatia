using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Backend.Entities;
using Backend.Entities.Anime;
using Backend.Entities.Games.Game;
using Backend.Entities.Games.GamesIds;
using Backend.Entities.Manga;
using Backend.Entities.Movies;
using Backend.Entities.TvShows;
using System;

namespace Backend.DatabaseContext;

public class DataContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, 
    AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserFriend> Friends { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Connection> Connections { get; set; }
    public DbSet<MovieItem> Top250Movies { get; set; }
    public DbSet<AppUserMovieItem> AppUserMovieItems { get; set; }
    public DbSet<AppUserTvShowItem> AppUserTvShowItems { get; set; }
    public DbSet<TvShowItem> TvShows { get; set; }
    public DbSet<Datum> Anime { get; set; }
    public DbSet<DatumManga> Manga { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<TvShow> TrueTvShow { get; set; }
    public DbSet<Result> GamesIds { get; set; }
    public DbSet<Game> Games { get; set; }


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

        builder.Entity<TvSeriesInfo>()
        .Property(e => e.Seasons)
        .HasConversion(
            v => string.Join(',', v),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
    }
}
