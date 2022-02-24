using Microsoft.EntityFrameworkCore;
using Proiect_licenta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_licenta.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserFriend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
        }
    }
}
