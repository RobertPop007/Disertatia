using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.Entities;
using Proiect_licenta.Entities.Anime;
using Proiect_licenta.Entities.Movies;
using Proiect_licenta.Entities.TvShows;

namespace Proiect_licenta.DatabaseContext
{
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
        public DbSet<TvShowItem> TvShows { get; set; }
        public DbSet<Datum> Anime { get; set; }


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
                .HasKey(bc => new { bc.AppUserId, bc.MovieItemId });
            builder.Entity<AppUserMovieItem>()
                .HasOne(bc => bc.AppUser)
                .WithMany(b => b.AppUserMovieItems)
                .HasForeignKey(bc => bc.AppUserId);
            builder.Entity<AppUserMovieItem>()
                .HasOne(bc => bc.MovieItem)
                .WithMany(c => c.AppUserMovieItems)
                .HasForeignKey(bc => bc.MovieItemId);
        }
    }
}
