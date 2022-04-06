﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_licenta.DatabaseContext;

namespace Proiect_licenta.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220404005047_AddedTvShowEntities")]
    partial class AddedTvShowEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interests")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KnownAs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LookingFor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppUserMovieItem", b =>
                {
                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("MovieItemId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AppUserId", "MovieItemId");

                    b.HasIndex("MovieItemId");

                    b.ToTable("AppUserMovieItems");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppUserTvShowItem", b =>
                {
                    b.Property<int>("AppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserId1")
                        .HasColumnType("int");

                    b.Property<string>("TvShowItemId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AppUserId");

                    b.HasIndex("AppUserId1");

                    b.HasIndex("TvShowItemId");

                    b.ToTable("AppUserTvShowItem");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Connection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConnectionId");

                    b.HasIndex("GroupName");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Group", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MessageSent")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RecipientDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<string>("RecipientUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SenderDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("SenderUsername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Movies.MovieItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Crew")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImDbRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImDbRatingCount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Top250Movies");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.TvShows.TvShowItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Crew")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImDbRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImDbRatingCount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TvShows");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.UserFriend", b =>
                {
                    b.Property<int>("AddedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("AddedUserId")
                        .HasColumnType("int");

                    b.HasKey("AddedByUserId", "AddedUserId");

                    b.HasIndex("AddedUserId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppUserMovieItem", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppUser", "AppUser")
                        .WithMany("AppUserMovieItems")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_licenta.Entities.Movies.MovieItem", "MovieItem")
                        .WithMany("AppUserMovieItems")
                        .HasForeignKey("MovieItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("MovieItem");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppUserRole", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_licenta.Entities.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppUserTvShowItem", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_licenta.Entities.TvShows.TvShowItem", "TvShowItem")
                        .WithMany("AppUserTvShowItems")
                        .HasForeignKey("TvShowItemId");

                    b.Navigation("AppUser");

                    b.Navigation("TvShowItem");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Connection", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.Group", null)
                        .WithMany("Connections")
                        .HasForeignKey("GroupName");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Message", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppUser", "Recipient")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proiect_licenta.Entities.AppUser", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Photo", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppUser", "AppUser")
                        .WithOne("ProfilePicture")
                        .HasForeignKey("Proiect_licenta.Entities.Photo", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.UserFriend", b =>
                {
                    b.HasOne("Proiect_licenta.Entities.AppUser", "AddedByUser")
                        .WithMany("AddedUsers")
                        .HasForeignKey("AddedByUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Proiect_licenta.Entities.AppUser", "AddedUser")
                        .WithMany("AddedByUsers")
                        .HasForeignKey("AddedUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AddedByUser");

                    b.Navigation("AddedUser");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.AppUser", b =>
                {
                    b.Navigation("AddedByUsers");

                    b.Navigation("AddedUsers");

                    b.Navigation("AppUserMovieItems");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");

                    b.Navigation("ProfilePicture");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Group", b =>
                {
                    b.Navigation("Connections");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.Movies.MovieItem", b =>
                {
                    b.Navigation("AppUserMovieItems");
                });

            modelBuilder.Entity("Proiect_licenta.Entities.TvShows.TvShowItem", b =>
                {
                    b.Navigation("AppUserTvShowItems");
                });
#pragma warning restore 612, 618
        }
    }
}
