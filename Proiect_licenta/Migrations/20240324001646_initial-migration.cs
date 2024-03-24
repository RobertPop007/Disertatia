using System;
using Microsoft.EntityFrameworkCore.Migrations;

<<<<<<< HEAD:Proiect_licenta/Migrations/20220513070929_InitialMigration.cs
namespace Proiect_licenta.Migrations;

public partial class InitialMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
<<<<<<< HEAD:Proiect_licenta/Migrations/20220513070929_InitialMigration.cs
=======
#nullable disable

namespace Proiect_licenta.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
>>>>>>> 8f968e6dcf9ad96ae3b6b3a574efd2be4d1a9ec3:Proiect_licenta/Migrations/20240324001646_initial-migration.cs
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddedByStatusGame",
                columns: table => new
                {
                    AddedByStatusGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Yet = table.Column<int>(type: "int", nullable: false),
                    Owned = table.Column<int>(type: "int", nullable: false),
                    Beaten = table.Column<int>(type: "int", nullable: false),
                    Toplay = table.Column<int>(type: "int", nullable: false),
                    Dropped = table.Column<int>(type: "int", nullable: false),
                    Playing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedByStatusGame", x => x.AddedByStatusGameId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KnownAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSubscribedToNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    HasDarkMode = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoxOffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningWeekendUSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossUSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CumulativeWorldwideGross = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxOffice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Broadcast",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    String = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broadcast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EsrbRatingGame",
                columns: table => new
                {
                    EsrbRatingGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsrbRatingGame", x => x.EsrbRatingGameId);
                });

            migrationBuilder.CreateTable(
                name: "From",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_From", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FromManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FromManga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamesIds",
                columns: table => new
                {
                    ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesIds", x => x.ResultId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Jpg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jpg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JpgManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JpgManga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesTrailer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkEmbed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesTrailer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformChildGame",
                columns: table => new
                {
                    PlatformChildGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformChildGame", x => x.PlatformChildGameId);
                });

            migrationBuilder.CreateTable(
                name: "PlatformGame",
                columns: table => new
                {
                    PlatformGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year_end = table.Column<int>(type: "int", nullable: true),
                    Year_start = table.Column<int>(type: "int", nullable: true),
                    Games_count = table.Column<int>(type: "int", nullable: false),
                    Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformGame", x => x.PlatformGameId);
                });

            migrationBuilder.CreateTable(
                name: "PlotFull",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlotFull", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlotShort",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlotShort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metacritic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheMovieDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RottenTomatoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmAffinity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequirementsGame",
                columns: table => new
                {
                    RequirementsGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Minimum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommended = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementsGame", x => x.RequirementsGameId);
                });

            migrationBuilder.CreateTable(
                name: "StoreGame",
                columns: table => new
                {
                    StoreGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Games_count = table.Column<int>(type: "int", nullable: false),
                    Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGame", x => x.StoreGameId);
                });

            migrationBuilder.CreateTable(
                name: "To",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToManga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Top250Movies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRatingCount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Top250Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvSeriesInfo",
                columns: table => new
                {
                    TvShowInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creators = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seasons = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeriesInfo", x => x.TvShowInfoId);
                });

            migrationBuilder.CreateTable(
                name: "TvShowBoxOffice",
                columns: table => new
                {
                    TvShowBoxOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningWeekendUSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossUSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CumulativeWorldwideGross = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowBoxOffice", x => x.TvShowBoxOfficeId);
                });

            migrationBuilder.CreateTable(
                name: "TvShowImages",
                columns: table => new
                {
                    TvShowImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowImages", x => x.TvShowImagesId);
                });

            migrationBuilder.CreateTable(
                name: "TvShowPlotFull",
                columns: table => new
                {
                    TvShowPlotFullId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowPlotFull", x => x.TvShowPlotFullId);
                });

            migrationBuilder.CreateTable(
                name: "TvShowPlotShort",
                columns: table => new
                {
                    TvShowPlotShortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowPlotShort", x => x.TvShowPlotShortId);
                });

            migrationBuilder.CreateTable(
                name: "TvShowRatings",
                columns: table => new
                {
                    TvShowRatingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metacritic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheMovieDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RottenTomatoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmAffinity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowRatings", x => x.TvShowRatingsId);
                });

            migrationBuilder.CreateTable(
                name: "TvShows",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRatingCount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvShowTrailer",
                columns: table => new
                {
                    TvShowTrailerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkEmbed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowTrailer", x => x.TvShowTrailerId);
                });

            migrationBuilder.CreateTable(
                name: "Webp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebpManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebpManga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    AddedByUserId = table.Column<int>(type: "int", nullable: false),
                    AddedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.AddedByUserId, x.AddedUserId });
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_AddedUserId",
                        column: x => x.AddedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    SenderUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    RecipientUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MessageSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecipientDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_original = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metacritic = table.Column<int>(type: "int", nullable: true),
                    Released = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tba = table.Column<bool>(type: "bit", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Background_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background_image_additional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Rating_top = table.Column<int>(type: "int", nullable: false),
                    Added = table.Column<int>(type: "int", nullable: false),
                    Added_by_statusAddedByStatusGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Playtime = table.Column<int>(type: "int", nullable: false),
                    Screenshots_count = table.Column<int>(type: "int", nullable: false),
                    Movies_count = table.Column<int>(type: "int", nullable: false),
                    Creators_count = table.Column<int>(type: "int", nullable: false),
                    Achievements_count = table.Column<int>(type: "int", nullable: false),
                    Parent_achievements_count = table.Column<int>(type: "int", nullable: false),
                    Reddit_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reddit_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reddit_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reddit_logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reddit_count = table.Column<int>(type: "int", nullable: false),
                    Twitch_count = table.Column<int>(type: "int", nullable: false),
                    Youtube_count = table.Column<int>(type: "int", nullable: false),
                    Reviews_text_count = table.Column<int>(type: "int", nullable: false),
                    Ratings_count = table.Column<int>(type: "int", nullable: false),
                    Suggestions_count = table.Column<int>(type: "int", nullable: false),
                    Metacritic_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parents_count = table.Column<int>(type: "int", nullable: false),
                    Additions_count = table.Column<int>(type: "int", nullable: false),
                    Game_series_count = table.Column<int>(type: "int", nullable: false),
                    Reviews_count = table.Column<int>(type: "int", nullable: false),
                    Saturated_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dominant_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Esrb_ratingEsrbRatingGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description_raw = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_AddedByStatusGame_Added_by_statusAddedByStatusGameId",
                        column: x => x.Added_by_statusAddedByStatusGameId,
                        principalTable: "AddedByStatusGame",
                        principalColumn: "AddedByStatusGameId");
                    table.ForeignKey(
                        name: "FK_Games_EsrbRatingGame_Esrb_ratingEsrbRatingGameId",
                        column: x => x.Esrb_ratingEsrbRatingGameId,
                        principalTable: "EsrbRatingGame",
                        principalColumn: "EsrbRatingGameId");
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    ConnectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_Connections_Groups_GroupName",
                        column: x => x.GroupName,
                        principalTable: "Groups",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoviesImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_MoviesImages_MoviesImagesId",
                        column: x => x.MoviesImagesId,
                        principalTable: "MoviesImages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wikipedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleInLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotShortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlotFullId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wikipedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wikipedia_PlotFull_PlotFullId",
                        column: x => x.PlotFullId,
                        principalTable: "PlotFull",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wikipedia_PlotShort_PlotShortId",
                        column: x => x.PlotShortId,
                        principalTable: "PlotShort",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prop_From_FromId",
                        column: x => x.FromId,
                        principalTable: "From",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prop_To_ToId",
                        column: x => x.ToId,
                        principalTable: "To",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropManga_FromManga_FromId",
                        column: x => x.FromId,
                        principalTable: "FromManga",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropManga_ToManga_ToId",
                        column: x => x.ToId,
                        principalTable: "ToManga",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TvShowCreatorList",
                columns: table => new
                {
                    TvShowCreatorListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvSeriesInfoTvShowInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowCreatorList", x => x.TvShowCreatorListId);
                    table.ForeignKey(
                        name: "FK_TvShowCreatorList_TvSeriesInfo_TvSeriesInfoTvShowInfoId",
                        column: x => x.TvSeriesInfoTvShowInfoId,
                        principalTable: "TvSeriesInfo",
                        principalColumn: "TvShowInfoId");
                });

            migrationBuilder.CreateTable(
                name: "TvShowItems",
                columns: table => new
                {
                    TvShowItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvShowImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowItems", x => x.TvShowItemsId);
                    table.ForeignKey(
                        name: "FK_TvShowItems_TvShowImages_TvShowImagesId",
                        column: x => x.TvShowImagesId,
                        principalTable: "TvShowImages",
                        principalColumn: "TvShowImagesId");
                });

            migrationBuilder.CreateTable(
                name: "TvShowWikipedia",
                columns: table => new
                {
                    TvShowWikipediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleInLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotShortTvShowPlotShortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlotFullTvShowPlotFullId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowWikipedia", x => x.TvShowWikipediaId);
                    table.ForeignKey(
                        name: "FK_TvShowWikipedia_TvShowPlotFull_PlotFullTvShowPlotFullId",
                        column: x => x.PlotFullTvShowPlotFullId,
                        principalTable: "TvShowPlotFull",
                        principalColumn: "TvShowPlotFullId");
                    table.ForeignKey(
                        name: "FK_TvShowWikipedia_TvShowPlotShort_PlotShortTvShowPlotShortId",
                        column: x => x.PlotShortTvShowPlotShortId,
                        principalTable: "TvShowPlotShort",
                        principalColumn: "TvShowPlotShortId");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JpgId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WebpId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medium_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maximum_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Jpg_JpgId",
                        column: x => x.JpgId,
                        principalTable: "Jpg",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Webp_WebpId",
                        column: x => x.WebpId,
                        principalTable: "Webp",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImagesManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JpgId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WebpId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesManga_JpgManga_JpgId",
                        column: x => x.JpgId,
                        principalTable: "JpgManga",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImagesManga_WebpManga_WebpId",
                        column: x => x.WebpId,
                        principalTable: "WebpManga",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUserGameItems",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserGameItems", x => new { x.AppUserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_AppUserGameItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserGameItems_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperGame",
                columns: table => new
                {
                    DeveloperGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Games_count = table.Column<int>(type: "int", nullable: false),
                    Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperGame", x => x.DeveloperGameId);
                    table.ForeignKey(
                        name: "FK_DeveloperGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GenreGame",
                columns: table => new
                {
                    GenreGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Games_count = table.Column<int>(type: "int", nullable: false),
                    Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreGame", x => x.GenreGameId);
                    table.ForeignKey(
                        name: "FK_GenreGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParentPlatformGame",
                columns: table => new
                {
                    ParentPlatformGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformChildGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentPlatformGame", x => x.ParentPlatformGameId);
                    table.ForeignKey(
                        name: "FK_ParentPlatformGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParentPlatformGame_PlatformChildGame_PlatformChildGameId",
                        column: x => x.PlatformChildGameId,
                        principalTable: "PlatformChildGame",
                        principalColumn: "PlatformChildGameId");
                });

            migrationBuilder.CreateTable(
                name: "PlatformsGame",
                columns: table => new
                {
                    PlatformsGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Released_at = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequirementsGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsGame", x => x.PlatformsGameId);
                    table.ForeignKey(
                        name: "FK_PlatformsGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlatformsGame_PlatformGame_PlatformGameId",
                        column: x => x.PlatformGameId,
                        principalTable: "PlatformGame",
                        principalColumn: "PlatformGameId");
                    table.ForeignKey(
                        name: "FK_PlatformsGame_RequirementsGame_RequirementsGameId",
                        column: x => x.RequirementsGameId,
                        principalTable: "RequirementsGame",
                        principalColumn: "RequirementsGameId");
                });

            migrationBuilder.CreateTable(
                name: "PublisherGame",
                columns: table => new
                {
                    PublisherGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Games_count = table.Column<int>(type: "int", nullable: false),
                    Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherGame", x => x.PublisherGameId);
                    table.ForeignKey(
                        name: "FK_PublisherGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RatingGame",
                columns: table => new
                {
                    RatingGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingGame", x => x.RatingGameId);
                    table.ForeignKey(
                        name: "FK_RatingGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoresGame",
                columns: table => new
                {
                    StoresGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoresGame", x => x.StoresGameId);
                    table.ForeignKey(
                        name: "FK_StoresGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoresGame_StoreGame_StoreGameId",
                        column: x => x.StoreGameId,
                        principalTable: "StoreGame",
                        principalColumn: "StoreGameId");
                });

            migrationBuilder.CreateTable(
                name: "TagGame",
                columns: table => new
                {
                    TagGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Games_count = table.Column<int>(type: "int", nullable: false),
                    Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagGame", x => x.TagGameId);
                    table.ForeignKey(
                        name: "FK_TagGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuntimeMins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuntimeStr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotLocalIsRtl = table.Column<bool>(type: "bit", nullable: false),
                    Awards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Directors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Writers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Countries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRatingVotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetacriticRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WikipediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrailerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoxOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_BoxOffice_BoxOfficeId",
                        column: x => x.BoxOfficeId,
                        principalTable: "BoxOffice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_MoviesImages_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "MoviesImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_MoviesTrailer_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "MoviesTrailer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Ratings_RatingsId",
                        column: x => x.RatingsId,
                        principalTable: "Ratings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Wikipedia_WikipediaId",
                        column: x => x.WikipediaId,
                        principalTable: "Wikipedia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aired",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    String = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aired", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aired_Prop_PropId",
                        column: x => x.PropId,
                        principalTable: "Prop",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PublishedManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    String = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishedManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublishedManga_PropManga_PropId",
                        column: x => x.PropId,
                        principalTable: "PropManga",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrueTvShow",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuntimeMins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuntimeStr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotLocalIsRtl = table.Column<bool>(type: "bit", nullable: false),
                    Awards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Directors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Writers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Countries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRatingVotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetacriticRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingsTvShowRatingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WikipediaTvShowWikipediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImagesTvShowImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrailerTvShowTrailerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoxOfficeTvShowBoxOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvSeriesInfoTvShowInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueTvShow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrueTvShow_TvSeriesInfo_TvSeriesInfoTvShowInfoId",
                        column: x => x.TvSeriesInfoTvShowInfoId,
                        principalTable: "TvSeriesInfo",
                        principalColumn: "TvShowInfoId");
                    table.ForeignKey(
                        name: "FK_TrueTvShow_TvShowBoxOffice_BoxOfficeTvShowBoxOfficeId",
                        column: x => x.BoxOfficeTvShowBoxOfficeId,
                        principalTable: "TvShowBoxOffice",
                        principalColumn: "TvShowBoxOfficeId");
                    table.ForeignKey(
                        name: "FK_TrueTvShow_TvShowImages_ImagesTvShowImagesId",
                        column: x => x.ImagesTvShowImagesId,
                        principalTable: "TvShowImages",
                        principalColumn: "TvShowImagesId");
                    table.ForeignKey(
                        name: "FK_TrueTvShow_TvShowRatings_RatingsTvShowRatingsId",
                        column: x => x.RatingsTvShowRatingsId,
                        principalTable: "TvShowRatings",
                        principalColumn: "TvShowRatingsId");
                    table.ForeignKey(
                        name: "FK_TrueTvShow_TvShowTrailer_TrailerTvShowTrailerId",
                        column: x => x.TrailerTvShowTrailerId,
                        principalTable: "TvShowTrailer",
                        principalColumn: "TvShowTrailerId");
                    table.ForeignKey(
                        name: "FK_TrueTvShow_TvShowWikipedia_WikipediaTvShowWikipediaId",
                        column: x => x.WikipediaTvShowWikipediaId,
                        principalTable: "TvShowWikipedia",
                        principalColumn: "TvShowWikipediaId");
                });

            migrationBuilder.CreateTable(
                name: "Trailer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Youtube_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Embed_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trailer_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActorList",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AsCharacter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorList", x => x.ActorId);
                    table.ForeignKey(
                        name: "FK_ActorList_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUserMovieItems",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserMovieItems", x => new { x.AppUserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_AppUserMovieItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserMovieItems_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserMovieItems_Top250Movies_MovieItemId",
                        column: x => x.MovieItemId,
                        principalTable: "Top250Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyList",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyList", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_CompanyList_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CountryList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryList_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DirectorList",
                columns: table => new
                {
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorList", x => x.DirectorId);
                    table.ForeignKey(
                        name: "FK_DirectorList_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GenreList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreList_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageList_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Similar",
                columns: table => new
                {
                    SimilarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Similar", x => x.SimilarId);
                    table.ForeignKey(
                        name: "FK_Similar_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StarList",
                columns: table => new
                {
                    StarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarList", x => x.StarId);
                    table.ForeignKey(
                        name: "FK_StarList_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WriterList",
                columns: table => new
                {
                    WriterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriterList", x => x.WriterId);
                    table.ForeignKey(
                        name: "FK_WriterList_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Manga",
                columns: table => new
                {
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_english = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_japanese = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chapters = table.Column<int>(type: "int", nullable: true),
                    Volumes = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publishing = table.Column<bool>(type: "bit", nullable: false),
                    PublishedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: true),
                    Scored = table.Column<double>(type: "float", nullable: false),
                    Scored_by = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Popularity = table.Column<int>(type: "int", nullable: true),
                    Members = table.Column<int>(type: "int", nullable: false),
                    Favorites = table.Column<int>(type: "int", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga", x => x.Mal_id);
                    table.ForeignKey(
                        name: "FK_Manga_ImagesManga_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "ImagesManga",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Manga_PublishedManga_PublishedId",
                        column: x => x.PublishedId,
                        principalTable: "PublishedManga",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUserTvShowItems",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TvShowItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTvShowItems", x => new { x.AppUserId, x.TvShowId });
                    table.ForeignKey(
                        name: "FK_AppUserTvShowItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTvShowItems_TrueTvShow_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TrueTvShow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTvShowItems_TvShows_TvShowItemId",
                        column: x => x.TvShowItemId,
                        principalTable: "TvShows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TvShowActorList",
                columns: table => new
                {
                    TvShowActorListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AsCharacter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowActorList", x => x.TvShowActorListId);
                    table.ForeignKey(
                        name: "FK_TvShowActorList_TrueTvShow_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TrueTvShow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TvShowCompanyList",
                columns: table => new
                {
                    TvShowCompanyListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowCompanyList", x => x.TvShowCompanyListId);
                    table.ForeignKey(
                        name: "FK_TvShowCompanyList_TrueTvShow_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TrueTvShow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TvShowCountryList",
                columns: table => new
                {
                    TvShowCountryListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowCountryList", x => x.TvShowCountryListId);
                    table.ForeignKey(
                        name: "FK_TvShowCountryList_TrueTvShow_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TrueTvShow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TvShowGenreList",
                columns: table => new
                {
                    TvShowGenreListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowGenreList", x => x.TvShowGenreListId);
                    table.ForeignKey(
                        name: "FK_TvShowGenreList_TrueTvShow_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TrueTvShow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TvShowLanguageList",
                columns: table => new
                {
                    TvShowLanguageListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowLanguageList", x => x.TvShowLanguageListId);
                    table.ForeignKey(
                        name: "FK_TvShowLanguageList_TrueTvShow_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TrueTvShow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TvShowSimilar",
                columns: table => new
                {
                    TvShowSimilarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowSimilar", x => x.TvShowSimilarId);
                    table.ForeignKey(
                        name: "FK_TvShowSimilar_TrueTvShow_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TrueTvShow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TvShowStarList",
                columns: table => new
                {
                    TvShowStarListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowStarList", x => x.TvShowStarListId);
                    table.ForeignKey(
                        name: "FK_TvShowStarList_TrueTvShow_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TrueTvShow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrailerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_english = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_japanese = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Episodes = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Airing = table.Column<bool>(type: "bit", nullable: false),
                    AiredId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: true),
                    Scored_by = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Popularity = table.Column<int>(type: "int", nullable: true),
                    Members = table.Column<int>(type: "int", nullable: true),
                    Favorites = table.Column<int>(type: "int", nullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    BroadcastId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.Mal_id);
                    table.ForeignKey(
                        name: "FK_Anime_Aired_AiredId",
                        column: x => x.AiredId,
                        principalTable: "Aired",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Anime_Broadcast_BroadcastId",
                        column: x => x.BroadcastId,
                        principalTable: "Broadcast",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Anime_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Anime_Trailer_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUserMangaItems",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    MangaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserMangaItems", x => new { x.AppUserId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_AppUserMangaItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserMangaItems_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Mal_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMangaMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorManga_Manga_DatumMangaMal_id",
                        column: x => x.DatumMangaMal_id,
                        principalTable: "Manga",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "DemographicManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMangaMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemographicManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemographicManga_Manga_DatumMangaMal_id",
                        column: x => x.DatumMangaMal_id,
                        principalTable: "Manga",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "GenreManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMangaMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreManga_Manga_DatumMangaMal_id",
                        column: x => x.DatumMangaMal_id,
                        principalTable: "Manga",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "SerializationManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMangaMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerializationManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerializationManga_Manga_DatumMangaMal_id",
                        column: x => x.DatumMangaMal_id,
                        principalTable: "Manga",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "ThemeManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMangaMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThemeManga_Manga_DatumMangaMal_id",
                        column: x => x.DatumMangaMal_id,
                        principalTable: "Manga",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "AppUserAnimeItems",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AnimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAnimeItems", x => new { x.AppUserId, x.AnimeId });
                    table.ForeignKey(
                        name: "FK_AppUserAnimeItems_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Mal_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserAnimeItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Demographic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demographic_Anime_DatumMal_id",
                        column: x => x.DatumMal_id,
                        principalTable: "Anime",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_Anime_DatumMal_id",
                        column: x => x.DatumMal_id,
                        principalTable: "Anime",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "Licensor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licensor_Anime_DatumMal_id",
                        column: x => x.DatumMal_id,
                        principalTable: "Anime",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producer_Anime_DatumMal_id",
                        column: x => x.DatumMal_id,
                        principalTable: "Anime",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studio_Anime_DatumMal_id",
                        column: x => x.DatumMal_id,
                        principalTable: "Anime",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mal_id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumMal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theme_Anime_DatumMal_id",
                        column: x => x.DatumMal_id,
                        principalTable: "Anime",
                        principalColumn: "Mal_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorList_MovieId",
                table: "ActorList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Aired_PropId",
                table: "Aired",
                column: "PropId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_AiredId",
                table: "Anime",
                column: "AiredId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_BroadcastId",
                table: "Anime",
                column: "BroadcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_ImagesId",
                table: "Anime",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_TrailerId",
                table: "Anime",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAnimeItems_AnimeId",
                table: "AppUserAnimeItems",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserGameItems_GameId",
                table: "AppUserGameItems",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMangaItems_MangaId",
                table: "AppUserMangaItems",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMovieItems_MovieId",
                table: "AppUserMovieItems",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMovieItems_MovieItemId",
                table: "AppUserMovieItems",
                column: "MovieItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTvShowItems_TvShowId",
                table: "AppUserTvShowItems",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTvShowItems_TvShowItemId",
                table: "AppUserTvShowItems",
                column: "TvShowItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorManga_DatumMangaMal_id",
                table: "AuthorManga",
                column: "DatumMangaMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyList_MovieId",
                table: "CompanyList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_GroupName",
                table: "Connections",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_CountryList_MovieId",
                table: "CountryList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DatumMal_id",
                table: "Demographic",
                column: "DatumMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_DemographicManga_DatumMangaMal_id",
                table: "DemographicManga",
                column: "DatumMangaMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperGame_GameId",
                table: "DeveloperGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorList_MovieId",
                table: "DirectorList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_AddedUserId",
                table: "Friends",
                column: "AddedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Added_by_statusAddedByStatusGameId",
                table: "Games",
                column: "Added_by_statusAddedByStatusGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Esrb_ratingEsrbRatingGameId",
                table: "Games",
                column: "Esrb_ratingEsrbRatingGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_DatumMal_id",
                table: "Genre",
                column: "DatumMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_GenreGame_GameId",
                table: "GenreGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreList_MovieId",
                table: "GenreList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreManga_DatumMangaMal_id",
                table: "GenreManga",
                column: "DatumMangaMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_JpgId",
                table: "Images",
                column: "JpgId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_WebpId",
                table: "Images",
                column: "WebpId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesManga_JpgId",
                table: "ImagesManga",
                column: "JpgId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesManga_WebpId",
                table: "ImagesManga",
                column: "WebpId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_MoviesImagesId",
                table: "Item",
                column: "MoviesImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageList_MovieId",
                table: "LanguageList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Licensor_DatumMal_id",
                table: "Licensor",
                column: "DatumMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_ImagesId",
                table: "Manga",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_PublishedId",
                table: "Manga",
                column: "PublishedId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_BoxOfficeId",
                table: "Movies",
                column: "BoxOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ImagesId",
                table: "Movies",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RatingsId",
                table: "Movies",
                column: "RatingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TrailerId",
                table: "Movies",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_WikipediaId",
                table: "Movies",
                column: "WikipediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentPlatformGame_GameId",
                table: "ParentPlatformGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentPlatformGame_PlatformChildGameId",
                table: "ParentPlatformGame",
                column: "PlatformChildGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsGame_GameId",
                table: "PlatformsGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsGame_PlatformGameId",
                table: "PlatformsGame",
                column: "PlatformGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsGame_RequirementsGameId",
                table: "PlatformsGame",
                column: "RequirementsGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Producer_DatumMal_id",
                table: "Producer",
                column: "DatumMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Prop_FromId",
                table: "Prop",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Prop_ToId",
                table: "Prop",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_PropManga_FromId",
                table: "PropManga",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_PropManga_ToId",
                table: "PropManga",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_PublishedManga_PropId",
                table: "PublishedManga",
                column: "PropId");

            migrationBuilder.CreateIndex(
                name: "IX_PublisherGame_GameId",
                table: "PublisherGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingGame_GameId",
                table: "RatingGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_SerializationManga_DatumMangaMal_id",
                table: "SerializationManga",
                column: "DatumMangaMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Similar_MovieId",
                table: "Similar",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_StarList_MovieId",
                table: "StarList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_StoresGame_GameId",
                table: "StoresGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_StoresGame_StoreGameId",
                table: "StoresGame",
                column: "StoreGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Studio_DatumMal_id",
                table: "Studio",
                column: "DatumMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_TagGame_GameId",
                table: "TagGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Theme_DatumMal_id",
                table: "Theme",
                column: "DatumMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeManga_DatumMangaMal_id",
                table: "ThemeManga",
                column: "DatumMangaMal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trailer_ImagesId",
                table: "Trailer",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueTvShow_BoxOfficeTvShowBoxOfficeId",
                table: "TrueTvShow",
                column: "BoxOfficeTvShowBoxOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueTvShow_ImagesTvShowImagesId",
                table: "TrueTvShow",
                column: "ImagesTvShowImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueTvShow_RatingsTvShowRatingsId",
                table: "TrueTvShow",
                column: "RatingsTvShowRatingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueTvShow_TrailerTvShowTrailerId",
                table: "TrueTvShow",
                column: "TrailerTvShowTrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueTvShow_TvSeriesInfoTvShowInfoId",
                table: "TrueTvShow",
                column: "TvSeriesInfoTvShowInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueTvShow_WikipediaTvShowWikipediaId",
                table: "TrueTvShow",
                column: "WikipediaTvShowWikipediaId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowActorList_TvShowId",
                table: "TvShowActorList",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowCompanyList_TvShowId",
                table: "TvShowCompanyList",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowCountryList_TvShowId",
                table: "TvShowCountryList",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowCreatorList_TvSeriesInfoTvShowInfoId",
                table: "TvShowCreatorList",
                column: "TvSeriesInfoTvShowInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowGenreList_TvShowId",
                table: "TvShowGenreList",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowItems_TvShowImagesId",
                table: "TvShowItems",
                column: "TvShowImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowLanguageList_TvShowId",
                table: "TvShowLanguageList",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowSimilar_TvShowId",
                table: "TvShowSimilar",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowStarList_TvShowId",
                table: "TvShowStarList",
                column: "TvShowId");
=======
        migrationBuilder.CreateTable(
            name: "AddedByStatusGame",
            columns: table => new
            {
                AddedByStatusGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Yet = table.Column<int>(type: "int", nullable: false),
                Owned = table.Column<int>(type: "int", nullable: false),
                Beaten = table.Column<int>(type: "int", nullable: false),
                Toplay = table.Column<int>(type: "int", nullable: false),
                Dropped = table.Column<int>(type: "int", nullable: false),
                Playing = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AddedByStatusGame", x => x.AddedByStatusGameId);
            });

        migrationBuilder.CreateTable(
            name: "AspNetRoles",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUsers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                KnownAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastActive = table.Column<DateTime>(type: "datetime2", nullable: false),
                Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LookingFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Interests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "BoxOffice",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                OpeningWeekendUSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GrossUSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CumulativeWorldwideGross = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BoxOffice", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Broadcast",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                String = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Broadcast", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "EsrbRatingGame",
            columns: table => new
            {
                EsrbRatingGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EsrbRatingGame", x => x.EsrbRatingGameId);
            });

<<<<<<< HEAD:Proiect_licenta/Migrations/20220513070929_InitialMigration.cs
        migrationBuilder.CreateTable(
            name: "From",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Day = table.Column<int>(type: "int", nullable: false),
                Month = table.Column<int>(type: "int", nullable: false),
                Year = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_From", x => x.Id);
            });
=======
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorList");
>>>>>>> 8f968e6dcf9ad96ae3b6b3a574efd2be4d1a9ec3:Proiect_licenta/Migrations/20240324001646_initial-migration.cs

        migrationBuilder.CreateTable(
            name: "FromManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Day = table.Column<int>(type: "int", nullable: true),
                Month = table.Column<int>(type: "int", nullable: true),
                Year = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FromManga", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "GamesIds",
            columns: table => new
            {
                ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GamesIds", x => x.ResultId);
            });

        migrationBuilder.CreateTable(
            name: "Groups",
            columns: table => new
            {
                Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Groups", x => x.Name);
            });

        migrationBuilder.CreateTable(
            name: "Jpg",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Jpg", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "JpgManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_JpgManga", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "MoviesImages",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MoviesImages", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "MoviesTrailer",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                VideoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                VideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                VideoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LinkEmbed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MoviesTrailer", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "PlatformChildGame",
            columns: table => new
            {
                PlatformChildGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Id = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PlatformChildGame", x => x.PlatformChildGameId);
            });

        migrationBuilder.CreateTable(
            name: "PlatformGame",
            columns: table => new
            {
                PlatformGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Id = table.Column<int>(type: "int", nullable: false),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year_end = table.Column<int>(type: "int", nullable: true),
                Year_start = table.Column<int>(type: "int", nullable: true),
                Games_count = table.Column<int>(type: "int", nullable: false),
                Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PlatformGame", x => x.PlatformGameId);
            });

        migrationBuilder.CreateTable(
            name: "PlotFull",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Html = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PlotFull", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "PlotShort",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Html = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PlotShort", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Ratings",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Metacritic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TheMovieDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RottenTomatoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FilmAffinity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Ratings", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "RequirementsGame",
            columns: table => new
            {
                RequirementsGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Minimum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Recommended = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RequirementsGame", x => x.RequirementsGameId);
            });

        migrationBuilder.CreateTable(
            name: "StoreGame",
            columns: table => new
            {
                StoreGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Games_count = table.Column<int>(type: "int", nullable: false),
                Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StoreGame", x => x.StoreGameId);
            });

        migrationBuilder.CreateTable(
            name: "To",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Day = table.Column<int>(type: "int", nullable: true),
                Month = table.Column<int>(type: "int", nullable: true),
                Year = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_To", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ToManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Day = table.Column<int>(type: "int", nullable: true),
                Month = table.Column<int>(type: "int", nullable: true),
                Year = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ToManga", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Top250Movies",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Crew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRatingCount = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Top250Movies", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "TvSeriesInfo",
            columns: table => new
            {
                TvShowInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                YearEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Creators = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Seasons = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvSeriesInfo", x => x.TvShowInfoId);
            });

        migrationBuilder.CreateTable(
            name: "TvShowBoxOffice",
            columns: table => new
            {
                TvShowBoxOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                OpeningWeekendUSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GrossUSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CumulativeWorldwideGross = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowBoxOffice", x => x.TvShowBoxOfficeId);
            });

        migrationBuilder.CreateTable(
            name: "TvShowImages",
            columns: table => new
            {
                TvShowImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowImages", x => x.TvShowImagesId);
            });

        migrationBuilder.CreateTable(
            name: "TvShowPlotFull",
            columns: table => new
            {
                TvShowPlotFullId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Html = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowPlotFull", x => x.TvShowPlotFullId);
            });

        migrationBuilder.CreateTable(
            name: "TvShowPlotShort",
            columns: table => new
            {
                TvShowPlotShortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Html = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowPlotShort", x => x.TvShowPlotShortId);
            });

        migrationBuilder.CreateTable(
            name: "TvShowRatings",
            columns: table => new
            {
                TvShowRatingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Metacritic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TheMovieDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RottenTomatoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FilmAffinity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowRatings", x => x.TvShowRatingsId);
            });

        migrationBuilder.CreateTable(
            name: "TvShows",
            columns: table => new
            {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Crew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRatingCount = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShows", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "TvShowTrailer",
            columns: table => new
            {
                TvShowTrailerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                VideoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                VideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                VideoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LinkEmbed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowTrailer", x => x.TvShowTrailerId);
            });

        migrationBuilder.CreateTable(
            name: "Webp",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Webp", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "WebpManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WebpManga", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AspNetRoleClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                RoleId = table.Column<int>(type: "int", nullable: false),
                ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                table.ForeignKey(
                    name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "AspNetRoles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>(type: "int", nullable: false),
                ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                table.ForeignKey(
                    name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserLogins",
            columns: table => new
            {
                LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UserId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                table.ForeignKey(
                    name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserRoles",
            columns: table => new
            {
                UserId = table.Column<int>(type: "int", nullable: false),
                RoleId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                table.ForeignKey(
                    name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "AspNetRoles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserTokens",
            columns: table => new
            {
                UserId = table.Column<int>(type: "int", nullable: false),
                LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                table.ForeignKey(
                    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Friends",
            columns: table => new
            {
                AddedByUserId = table.Column<int>(type: "int", nullable: false),
                AddedUserId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Friends", x => new { x.AddedByUserId, x.AddedUserId });
                table.ForeignKey(
                    name: "FK_Friends_AspNetUsers_AddedByUserId",
                    column: x => x.AddedByUserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Friends_AspNetUsers_AddedUserId",
                    column: x => x.AddedUserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Messages",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                SenderId = table.Column<int>(type: "int", nullable: false),
                SenderUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RecipientId = table.Column<int>(type: "int", nullable: false),
                RecipientUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
                MessageSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                SenderDeleted = table.Column<bool>(type: "bit", nullable: false),
                RecipientDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Messages", x => x.Id);
                table.ForeignKey(
                    name: "FK_Messages_AspNetUsers_RecipientId",
                    column: x => x.RecipientId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Messages_AspNetUsers_SenderId",
                    column: x => x.SenderId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Photos",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AppUserId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Photos", x => x.Id);
                table.ForeignKey(
                    name: "FK_Photos_AspNetUsers_AppUserId",
                    column: x => x.AppUserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Games",
            columns: table => new
            {
                GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false),
                Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name_original = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Metacritic = table.Column<int>(type: "int", nullable: true),
                Released = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Tba = table.Column<bool>(type: "bit", nullable: false),
                Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                Background_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Background_image_additional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Rating = table.Column<double>(type: "float", nullable: false),
                Rating_top = table.Column<int>(type: "int", nullable: false),
                Added = table.Column<int>(type: "int", nullable: false),
                Added_by_statusAddedByStatusGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Playtime = table.Column<int>(type: "int", nullable: false),
                Screenshots_count = table.Column<int>(type: "int", nullable: false),
                Movies_count = table.Column<int>(type: "int", nullable: false),
                Creators_count = table.Column<int>(type: "int", nullable: false),
                Achievements_count = table.Column<int>(type: "int", nullable: false),
                Parent_achievements_count = table.Column<int>(type: "int", nullable: false),
                Reddit_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Reddit_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Reddit_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Reddit_logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Reddit_count = table.Column<int>(type: "int", nullable: false),
                Twitch_count = table.Column<int>(type: "int", nullable: false),
                Youtube_count = table.Column<int>(type: "int", nullable: false),
                Reviews_text_count = table.Column<int>(type: "int", nullable: false),
                Ratings_count = table.Column<int>(type: "int", nullable: false),
                Suggestions_count = table.Column<int>(type: "int", nullable: false),
                Metacritic_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Parents_count = table.Column<int>(type: "int", nullable: false),
                Additions_count = table.Column<int>(type: "int", nullable: false),
                Game_series_count = table.Column<int>(type: "int", nullable: false),
                Reviews_count = table.Column<int>(type: "int", nullable: false),
                Saturated_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Dominant_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Esrb_ratingEsrbRatingGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Description_raw = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Games", x => x.GameId);
                table.ForeignKey(
                    name: "FK_Games_AddedByStatusGame_Added_by_statusAddedByStatusGameId",
                    column: x => x.Added_by_statusAddedByStatusGameId,
                    principalTable: "AddedByStatusGame",
                    principalColumn: "AddedByStatusGameId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Games_EsrbRatingGame_Esrb_ratingEsrbRatingGameId",
                    column: x => x.Esrb_ratingEsrbRatingGameId,
                    principalTable: "EsrbRatingGame",
                    principalColumn: "EsrbRatingGameId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Connections",
            columns: table => new
            {
                ConnectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GroupName = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Connections", x => x.ConnectionId);
                table.ForeignKey(
                    name: "FK_Connections_Groups_GroupName",
                    column: x => x.GroupName,
                    principalTable: "Groups",
                    principalColumn: "Name",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Item",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MoviesImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Item", x => x.Id);
                table.ForeignKey(
                    name: "FK_Item_MoviesImages_MoviesImagesId",
                    column: x => x.MoviesImagesId,
                    principalTable: "MoviesImages",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Wikipedia",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TitleInLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PlotShortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                PlotFullId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Wikipedia", x => x.Id);
                table.ForeignKey(
                    name: "FK_Wikipedia_PlotFull_PlotFullId",
                    column: x => x.PlotFullId,
                    principalTable: "PlotFull",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Wikipedia_PlotShort_PlotShortId",
                    column: x => x.PlotShortId,
                    principalTable: "PlotShort",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Prop",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                ToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Prop", x => x.Id);
                table.ForeignKey(
                    name: "FK_Prop_From_FromId",
                    column: x => x.FromId,
                    principalTable: "From",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Prop_To_ToId",
                    column: x => x.ToId,
                    principalTable: "To",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "PropManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                ToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PropManga", x => x.Id);
                table.ForeignKey(
                    name: "FK_PropManga_FromManga_FromId",
                    column: x => x.FromId,
                    principalTable: "FromManga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_PropManga_ToManga_ToId",
                    column: x => x.ToId,
                    principalTable: "ToManga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowCreatorList",
            columns: table => new
            {
                TvShowCreatorListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvSeriesInfoTvShowInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowCreatorList", x => x.TvShowCreatorListId);
                table.ForeignKey(
                    name: "FK_TvShowCreatorList_TvSeriesInfo_TvSeriesInfoTvShowInfoId",
                    column: x => x.TvSeriesInfoTvShowInfoId,
                    principalTable: "TvSeriesInfo",
                    principalColumn: "TvShowInfoId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowItems",
            columns: table => new
            {
                TvShowItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvShowImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowItems", x => x.TvShowItemsId);
                table.ForeignKey(
                    name: "FK_TvShowItems_TvShowImages_TvShowImagesId",
                    column: x => x.TvShowImagesId,
                    principalTable: "TvShowImages",
                    principalColumn: "TvShowImagesId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowWikipedia",
            columns: table => new
            {
                TvShowWikipediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ImDbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TitleInLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PlotShortTvShowPlotShortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                PlotFullTvShowPlotFullId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowWikipedia", x => x.TvShowWikipediaId);
                table.ForeignKey(
                    name: "FK_TvShowWikipedia_TvShowPlotFull_PlotFullTvShowPlotFullId",
                    column: x => x.PlotFullTvShowPlotFullId,
                    principalTable: "TvShowPlotFull",
                    principalColumn: "TvShowPlotFullId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_TvShowWikipedia_TvShowPlotShort_PlotShortTvShowPlotShortId",
                    column: x => x.PlotShortTvShowPlotShortId,
                    principalTable: "TvShowPlotShort",
                    principalColumn: "TvShowPlotShortId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Images",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                JpgId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                WebpId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Small_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Medium_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Large_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Maximum_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Images", x => x.Id);
                table.ForeignKey(
                    name: "FK_Images_Jpg_JpgId",
                    column: x => x.JpgId,
                    principalTable: "Jpg",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Images_Webp_WebpId",
                    column: x => x.WebpId,
                    principalTable: "Webp",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "ImagesManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                JpgId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                WebpId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ImagesManga", x => x.Id);
                table.ForeignKey(
                    name: "FK_ImagesManga_JpgManga_JpgId",
                    column: x => x.JpgId,
                    principalTable: "JpgManga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ImagesManga_WebpManga_WebpId",
                    column: x => x.WebpId,
                    principalTable: "WebpManga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "DeveloperGame",
            columns: table => new
            {
                DeveloperGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Games_count = table.Column<int>(type: "int", nullable: false),
                Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DeveloperGame", x => x.DeveloperGameId);
                table.ForeignKey(
                    name: "FK_DeveloperGame_Games_GameId",
                    column: x => x.GameId,
                    principalTable: "Games",
                    principalColumn: "GameId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "GenreGame",
            columns: table => new
            {
                GenreGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Games_count = table.Column<int>(type: "int", nullable: false),
                Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GenreGame", x => x.GenreGameId);
                table.ForeignKey(
                    name: "FK_GenreGame_Games_GameId",
                    column: x => x.GameId,
                    principalTable: "Games",
                    principalColumn: "GameId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "ParentPlatformGame",
            columns: table => new
            {
                ParentPlatformGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PlatformChildGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ParentPlatformGame", x => x.ParentPlatformGameId);
                table.ForeignKey(
                    name: "FK_ParentPlatformGame_Games_GameId",
                    column: x => x.GameId,
                    principalTable: "Games",
                    principalColumn: "GameId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ParentPlatformGame_PlatformChildGame_PlatformChildGameId",
                    column: x => x.PlatformChildGameId,
                    principalTable: "PlatformChildGame",
                    principalColumn: "PlatformChildGameId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "PlatformsGame",
            columns: table => new
            {
                PlatformsGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PlatformGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Released_at = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RequirementsGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PlatformsGame", x => x.PlatformsGameId);
                table.ForeignKey(
                    name: "FK_PlatformsGame_Games_GameId",
                    column: x => x.GameId,
                    principalTable: "Games",
                    principalColumn: "GameId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_PlatformsGame_PlatformGame_PlatformGameId",
                    column: x => x.PlatformGameId,
                    principalTable: "PlatformGame",
                    principalColumn: "PlatformGameId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_PlatformsGame_RequirementsGame_RequirementsGameId",
                    column: x => x.RequirementsGameId,
                    principalTable: "RequirementsGame",
                    principalColumn: "RequirementsGameId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "PublisherGame",
            columns: table => new
            {
                PublisherGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Games_count = table.Column<int>(type: "int", nullable: false),
                Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PublisherGame", x => x.PublisherGameId);
                table.ForeignKey(
                    name: "FK_PublisherGame_Games_GameId",
                    column: x => x.GameId,
                    principalTable: "Games",
                    principalColumn: "GameId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "RatingGame",
            columns: table => new
            {
                RatingGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Count = table.Column<int>(type: "int", nullable: false),
                Percent = table.Column<double>(type: "float", nullable: false),
                GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RatingGame", x => x.RatingGameId);
                table.ForeignKey(
                    name: "FK_RatingGame_Games_GameId",
                    column: x => x.GameId,
                    principalTable: "Games",
                    principalColumn: "GameId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "StoresGame",
            columns: table => new
            {
                StoresGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                StoreGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StoresGame", x => x.StoresGameId);
                table.ForeignKey(
                    name: "FK_StoresGame_Games_GameId",
                    column: x => x.GameId,
                    principalTable: "Games",
                    principalColumn: "GameId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_StoresGame_StoreGame_StoreGameId",
                    column: x => x.StoreGameId,
                    principalTable: "StoreGame",
                    principalColumn: "StoreGameId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TagGame",
            columns: table => new
            {
                TagGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Games_count = table.Column<int>(type: "int", nullable: false),
                Image_background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TagGame", x => x.TagGameId);
                table.ForeignKey(
                    name: "FK_TagGame_Games_GameId",
                    column: x => x.GameId,
                    principalTable: "Games",
                    principalColumn: "GameId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Movies",
            columns: table => new
            {
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RuntimeMins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RuntimeStr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PlotLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PlotLocalIsRtl = table.Column<bool>(type: "bit", nullable: false),
                Awards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Directors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Writers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Stars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Companies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Countries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ContentRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRatingVotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MetacriticRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RatingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                WikipediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                ImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                TrailerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                BoxOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Movies", x => x.MovieId);
                table.ForeignKey(
                    name: "FK_Movies_BoxOffice_BoxOfficeId",
                    column: x => x.BoxOfficeId,
                    principalTable: "BoxOffice",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Movies_MoviesImages_ImagesId",
                    column: x => x.ImagesId,
                    principalTable: "MoviesImages",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Movies_MoviesTrailer_TrailerId",
                    column: x => x.TrailerId,
                    principalTable: "MoviesTrailer",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Movies_Ratings_RatingsId",
                    column: x => x.RatingsId,
                    principalTable: "Ratings",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Movies_Wikipedia_WikipediaId",
                    column: x => x.WikipediaId,
                    principalTable: "Wikipedia",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Aired",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                From = table.Column<DateTime>(type: "datetime2", nullable: false),
                To = table.Column<DateTime>(type: "datetime2", nullable: true),
                PropId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                String = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Aired", x => x.Id);
                table.ForeignKey(
                    name: "FK_Aired_Prop_PropId",
                    column: x => x.PropId,
                    principalTable: "Prop",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "PublishedManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                From = table.Column<DateTime>(type: "datetime2", nullable: true),
                To = table.Column<DateTime>(type: "datetime2", nullable: true),
                PropId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                String = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PublishedManga", x => x.Id);
                table.ForeignKey(
                    name: "FK_PublishedManga_PropManga_PropId",
                    column: x => x.PropId,
                    principalTable: "PropManga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TrueTvShow",
            columns: table => new
            {
                TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RuntimeMins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RuntimeStr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PlotLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PlotLocalIsRtl = table.Column<bool>(type: "bit", nullable: false),
                Awards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Directors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Writers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Stars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Companies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Countries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ContentRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRatingVotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MetacriticRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                RatingsTvShowRatingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                WikipediaTvShowWikipediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                ImagesTvShowImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                TrailerTvShowTrailerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                BoxOfficeTvShowBoxOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvSeriesInfoTvShowInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TrueTvShow", x => x.TvShowId);
                table.ForeignKey(
                    name: "FK_TrueTvShow_TvSeriesInfo_TvSeriesInfoTvShowInfoId",
                    column: x => x.TvSeriesInfoTvShowInfoId,
                    principalTable: "TvSeriesInfo",
                    principalColumn: "TvShowInfoId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_TrueTvShow_TvShowBoxOffice_BoxOfficeTvShowBoxOfficeId",
                    column: x => x.BoxOfficeTvShowBoxOfficeId,
                    principalTable: "TvShowBoxOffice",
                    principalColumn: "TvShowBoxOfficeId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_TrueTvShow_TvShowImages_ImagesTvShowImagesId",
                    column: x => x.ImagesTvShowImagesId,
                    principalTable: "TvShowImages",
                    principalColumn: "TvShowImagesId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_TrueTvShow_TvShowRatings_RatingsTvShowRatingsId",
                    column: x => x.RatingsTvShowRatingsId,
                    principalTable: "TvShowRatings",
                    principalColumn: "TvShowRatingsId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_TrueTvShow_TvShowTrailer_TrailerTvShowTrailerId",
                    column: x => x.TrailerTvShowTrailerId,
                    principalTable: "TvShowTrailer",
                    principalColumn: "TvShowTrailerId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_TrueTvShow_TvShowWikipedia_WikipediaTvShowWikipediaId",
                    column: x => x.WikipediaTvShowWikipediaId,
                    principalTable: "TvShowWikipedia",
                    principalColumn: "TvShowWikipediaId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Trailer",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Youtube_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Embed_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Trailer", x => x.Id);
                table.ForeignKey(
                    name: "FK_Trailer_Images_ImagesId",
                    column: x => x.ImagesId,
                    principalTable: "Images",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "ActorList",
            columns: table => new
            {
                ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AsCharacter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ActorList", x => x.ActorId);
                table.ForeignKey(
                    name: "FK_ActorList_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "AppUserMovieItems",
            columns: table => new
            {
                AppUserId = table.Column<int>(type: "int", nullable: false),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                MovieItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AppUserMovieItems", x => new { x.AppUserId, x.MovieId });
                table.ForeignKey(
                    name: "FK_AppUserMovieItems_AspNetUsers_AppUserId",
                    column: x => x.AppUserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AppUserMovieItems_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AppUserMovieItems_Top250Movies_MovieItemId",
                    column: x => x.MovieItemId,
                    principalTable: "Top250Movies",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "CompanyList",
            columns: table => new
            {
                CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CompanyList", x => x.CompanyId);
                table.ForeignKey(
                    name: "FK_CompanyList_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "CountryList",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CountryList", x => x.Id);
                table.ForeignKey(
                    name: "FK_CountryList_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "DirectorList",
            columns: table => new
            {
                DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DirectorList", x => x.DirectorId);
                table.ForeignKey(
                    name: "FK_DirectorList_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "GenreList",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GenreList", x => x.Id);
                table.ForeignKey(
                    name: "FK_GenreList_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "LanguageList",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LanguageList", x => x.Id);
                table.ForeignKey(
                    name: "FK_LanguageList_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Similar",
            columns: table => new
            {
                SimilarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Similar", x => x.SimilarId);
                table.ForeignKey(
                    name: "FK_Similar_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "StarList",
            columns: table => new
            {
                StarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StarList", x => x.StarId);
                table.ForeignKey(
                    name: "FK_StarList_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "WriterList",
            columns: table => new
            {
                WriterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MovieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WriterList", x => x.WriterId);
                table.ForeignKey(
                    name: "FK_WriterList_Movies_MovieId",
                    column: x => x.MovieId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Manga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title_english = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title_japanese = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Chapters = table.Column<int>(type: "int", nullable: true),
                Volumes = table.Column<int>(type: "int", nullable: true),
                Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Publishing = table.Column<bool>(type: "bit", nullable: false),
                PublishedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Score = table.Column<double>(type: "float", nullable: true),
                Scored = table.Column<double>(type: "float", nullable: false),
                Scored_by = table.Column<int>(type: "int", nullable: false),
                Rank = table.Column<int>(type: "int", nullable: true),
                Popularity = table.Column<int>(type: "int", nullable: true),
                Members = table.Column<int>(type: "int", nullable: false),
                Favorites = table.Column<int>(type: "int", nullable: false),
                Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Background = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Manga", x => x.Id);
                table.ForeignKey(
                    name: "FK_Manga_ImagesManga_ImagesId",
                    column: x => x.ImagesId,
                    principalTable: "ImagesManga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Manga_PublishedManga_PublishedId",
                    column: x => x.PublishedId,
                    principalTable: "PublishedManga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "AppUserTvShowItems",
            columns: table => new
            {
                AppUserId = table.Column<int>(type: "int", nullable: false),
                TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                TvShowItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AppUserTvShowItems", x => new { x.AppUserId, x.TvShowId });
                table.ForeignKey(
                    name: "FK_AppUserTvShowItems_AspNetUsers_AppUserId",
                    column: x => x.AppUserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AppUserTvShowItems_TrueTvShow_TvShowId",
                    column: x => x.TvShowId,
                    principalTable: "TrueTvShow",
                    principalColumn: "TvShowId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AppUserTvShowItems_TvShows_TvShowItemId",
                    column: x => x.TvShowItemId,
                    principalTable: "TvShows",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowActorList",
            columns: table => new
            {
                TvShowActorListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AsCharacter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowActorList", x => x.TvShowActorListId);
                table.ForeignKey(
                    name: "FK_TvShowActorList_TrueTvShow_TvShowId",
                    column: x => x.TvShowId,
                    principalTable: "TrueTvShow",
                    principalColumn: "TvShowId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowCompanyList",
            columns: table => new
            {
                TvShowCompanyListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowCompanyList", x => x.TvShowCompanyListId);
                table.ForeignKey(
                    name: "FK_TvShowCompanyList_TrueTvShow_TvShowId",
                    column: x => x.TvShowId,
                    principalTable: "TrueTvShow",
                    principalColumn: "TvShowId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowCountryList",
            columns: table => new
            {
                TvShowCountryListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowCountryList", x => x.TvShowCountryListId);
                table.ForeignKey(
                    name: "FK_TvShowCountryList_TrueTvShow_TvShowId",
                    column: x => x.TvShowId,
                    principalTable: "TrueTvShow",
                    principalColumn: "TvShowId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowGenreList",
            columns: table => new
            {
                TvShowGenreListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowGenreList", x => x.TvShowGenreListId);
                table.ForeignKey(
                    name: "FK_TvShowGenreList_TrueTvShow_TvShowId",
                    column: x => x.TvShowId,
                    principalTable: "TrueTvShow",
                    principalColumn: "TvShowId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowLanguageList",
            columns: table => new
            {
                TvShowLanguageListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowLanguageList", x => x.TvShowLanguageListId);
                table.ForeignKey(
                    name: "FK_TvShowLanguageList_TrueTvShow_TvShowId",
                    column: x => x.TvShowId,
                    principalTable: "TrueTvShow",
                    principalColumn: "TvShowId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowSimilar",
            columns: table => new
            {
                TvShowSimilarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowSimilar", x => x.TvShowSimilarId);
                table.ForeignKey(
                    name: "FK_TvShowSimilar_TrueTvShow_TvShowId",
                    column: x => x.TvShowId,
                    principalTable: "TrueTvShow",
                    principalColumn: "TvShowId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "TvShowStarList",
            columns: table => new
            {
                TvShowStarListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShowStarList", x => x.TvShowStarListId);
                table.ForeignKey(
                    name: "FK_TvShowStarList_TrueTvShow_TvShowId",
                    column: x => x.TvShowId,
                    principalTable: "TrueTvShow",
                    principalColumn: "TvShowId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Anime",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                TrailerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title_english = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title_japanese = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Episodes = table.Column<int>(type: "int", nullable: true),
                Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Airing = table.Column<bool>(type: "bit", nullable: false),
                AiredId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Score = table.Column<double>(type: "float", nullable: true),
                Scored_by = table.Column<int>(type: "int", nullable: false),
                Rank = table.Column<int>(type: "int", nullable: true),
                Popularity = table.Column<int>(type: "int", nullable: true),
                Members = table.Column<int>(type: "int", nullable: true),
                Favorites = table.Column<int>(type: "int", nullable: true),
                Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Year = table.Column<int>(type: "int", nullable: true),
                BroadcastId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Anime", x => x.Id);
                table.ForeignKey(
                    name: "FK_Anime_Aired_AiredId",
                    column: x => x.AiredId,
                    principalTable: "Aired",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Anime_Broadcast_BroadcastId",
                    column: x => x.BroadcastId,
                    principalTable: "Broadcast",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Anime_Images_ImagesId",
                    column: x => x.ImagesId,
                    principalTable: "Images",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Anime_Trailer_TrailerId",
                    column: x => x.TrailerId,
                    principalTable: "Trailer",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "AuthorManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumMangaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AuthorManga", x => x.Id);
                table.ForeignKey(
                    name: "FK_AuthorManga_Manga_DatumMangaId",
                    column: x => x.DatumMangaId,
                    principalTable: "Manga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "DemographicManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_Id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumMangaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DemographicManga", x => x.Id);
                table.ForeignKey(
                    name: "FK_DemographicManga_Manga_DatumMangaId",
                    column: x => x.DatumMangaId,
                    principalTable: "Manga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "GenreManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumMangaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GenreManga", x => x.Id);
                table.ForeignKey(
                    name: "FK_GenreManga_Manga_DatumMangaId",
                    column: x => x.DatumMangaId,
                    principalTable: "Manga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "SerializationManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumMangaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SerializationManga", x => x.Id);
                table.ForeignKey(
                    name: "FK_SerializationManga_Manga_DatumMangaId",
                    column: x => x.DatumMangaId,
                    principalTable: "Manga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "ThemeManga",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumMangaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ThemeManga", x => x.Id);
                table.ForeignKey(
                    name: "FK_ThemeManga_Manga_DatumMangaId",
                    column: x => x.DatumMangaId,
                    principalTable: "Manga",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Demographic",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Demographic", x => x.Id);
                table.ForeignKey(
                    name: "FK_Demographic_Anime_DatumId",
                    column: x => x.DatumId,
                    principalTable: "Anime",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Genre",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Genre", x => x.Id);
                table.ForeignKey(
                    name: "FK_Genre_Anime_DatumId",
                    column: x => x.DatumId,
                    principalTable: "Anime",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Licensor",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Licensor", x => x.Id);
                table.ForeignKey(
                    name: "FK_Licensor_Anime_DatumId",
                    column: x => x.DatumId,
                    principalTable: "Anime",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Producer",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Producer", x => x.Id);
                table.ForeignKey(
                    name: "FK_Producer_Anime_DatumId",
                    column: x => x.DatumId,
                    principalTable: "Anime",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Studio",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Studio", x => x.Id);
                table.ForeignKey(
                    name: "FK_Studio_Anime_DatumId",
                    column: x => x.DatumId,
                    principalTable: "Anime",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Theme",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Mal_id = table.Column<int>(type: "int", nullable: false),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DatumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Theme", x => x.Id);
                table.ForeignKey(
                    name: "FK_Theme_Anime_DatumId",
                    column: x => x.DatumId,
                    principalTable: "Anime",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ActorList_MovieId",
            table: "ActorList",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_Aired_PropId",
            table: "Aired",
            column: "PropId");

        migrationBuilder.CreateIndex(
            name: "IX_Anime_AiredId",
            table: "Anime",
            column: "AiredId");

        migrationBuilder.CreateIndex(
            name: "IX_Anime_BroadcastId",
            table: "Anime",
            column: "BroadcastId");

        migrationBuilder.CreateIndex(
            name: "IX_Anime_ImagesId",
            table: "Anime",
            column: "ImagesId");

        migrationBuilder.CreateIndex(
            name: "IX_Anime_TrailerId",
            table: "Anime",
            column: "TrailerId");

        migrationBuilder.CreateIndex(
            name: "IX_AppUserMovieItems_MovieId",
            table: "AppUserMovieItems",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_AppUserMovieItems_MovieItemId",
            table: "AppUserMovieItems",
            column: "MovieItemId");

        migrationBuilder.CreateIndex(
            name: "IX_AppUserTvShowItems_TvShowId",
            table: "AppUserTvShowItems",
            column: "TvShowId");

        migrationBuilder.CreateIndex(
            name: "IX_AppUserTvShowItems_TvShowItemId",
            table: "AppUserTvShowItems",
            column: "TvShowItemId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetRoleClaims_RoleId",
            table: "AspNetRoleClaims",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "RoleNameIndex",
            table: "AspNetRoles",
            column: "NormalizedName",
            unique: true,
            filter: "[NormalizedName] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserClaims_UserId",
            table: "AspNetUserClaims",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserLogins_UserId",
            table: "AspNetUserLogins",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserRoles_RoleId",
            table: "AspNetUserRoles",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "EmailIndex",
            table: "AspNetUsers",
            column: "NormalizedEmail");

        migrationBuilder.CreateIndex(
            name: "UserNameIndex",
            table: "AspNetUsers",
            column: "NormalizedUserName",
            unique: true,
            filter: "[NormalizedUserName] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_AuthorManga_DatumMangaId",
            table: "AuthorManga",
            column: "DatumMangaId");

        migrationBuilder.CreateIndex(
            name: "IX_CompanyList_MovieId",
            table: "CompanyList",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_Connections_GroupName",
            table: "Connections",
            column: "GroupName");

        migrationBuilder.CreateIndex(
            name: "IX_CountryList_MovieId",
            table: "CountryList",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_Demographic_DatumId",
            table: "Demographic",
            column: "DatumId");

        migrationBuilder.CreateIndex(
            name: "IX_DemographicManga_DatumMangaId",
            table: "DemographicManga",
            column: "DatumMangaId");

        migrationBuilder.CreateIndex(
            name: "IX_DeveloperGame_GameId",
            table: "DeveloperGame",
            column: "GameId");

        migrationBuilder.CreateIndex(
            name: "IX_DirectorList_MovieId",
            table: "DirectorList",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_Friends_AddedUserId",
            table: "Friends",
            column: "AddedUserId");

        migrationBuilder.CreateIndex(
            name: "IX_Games_Added_by_statusAddedByStatusGameId",
            table: "Games",
            column: "Added_by_statusAddedByStatusGameId");

        migrationBuilder.CreateIndex(
            name: "IX_Games_Esrb_ratingEsrbRatingGameId",
            table: "Games",
            column: "Esrb_ratingEsrbRatingGameId");

        migrationBuilder.CreateIndex(
            name: "IX_Genre_DatumId",
            table: "Genre",
            column: "DatumId");

        migrationBuilder.CreateIndex(
            name: "IX_GenreGame_GameId",
            table: "GenreGame",
            column: "GameId");

        migrationBuilder.CreateIndex(
            name: "IX_GenreList_MovieId",
            table: "GenreList",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_GenreManga_DatumMangaId",
            table: "GenreManga",
            column: "DatumMangaId");

        migrationBuilder.CreateIndex(
            name: "IX_Images_JpgId",
            table: "Images",
            column: "JpgId");

        migrationBuilder.CreateIndex(
            name: "IX_Images_WebpId",
            table: "Images",
            column: "WebpId");

        migrationBuilder.CreateIndex(
            name: "IX_ImagesManga_JpgId",
            table: "ImagesManga",
            column: "JpgId");

        migrationBuilder.CreateIndex(
            name: "IX_ImagesManga_WebpId",
            table: "ImagesManga",
            column: "WebpId");

        migrationBuilder.CreateIndex(
            name: "IX_Item_MoviesImagesId",
            table: "Item",
            column: "MoviesImagesId");

        migrationBuilder.CreateIndex(
            name: "IX_LanguageList_MovieId",
            table: "LanguageList",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_Licensor_DatumId",
            table: "Licensor",
            column: "DatumId");

        migrationBuilder.CreateIndex(
            name: "IX_Manga_ImagesId",
            table: "Manga",
            column: "ImagesId");

        migrationBuilder.CreateIndex(
            name: "IX_Manga_PublishedId",
            table: "Manga",
            column: "PublishedId");

        migrationBuilder.CreateIndex(
            name: "IX_Messages_RecipientId",
            table: "Messages",
            column: "RecipientId");

        migrationBuilder.CreateIndex(
            name: "IX_Messages_SenderId",
            table: "Messages",
            column: "SenderId");

        migrationBuilder.CreateIndex(
            name: "IX_Movies_BoxOfficeId",
            table: "Movies",
            column: "BoxOfficeId");

        migrationBuilder.CreateIndex(
            name: "IX_Movies_ImagesId",
            table: "Movies",
            column: "ImagesId");

        migrationBuilder.CreateIndex(
            name: "IX_Movies_RatingsId",
            table: "Movies",
            column: "RatingsId");

        migrationBuilder.CreateIndex(
            name: "IX_Movies_TrailerId",
            table: "Movies",
            column: "TrailerId");

        migrationBuilder.CreateIndex(
            name: "IX_Movies_WikipediaId",
            table: "Movies",
            column: "WikipediaId");

        migrationBuilder.CreateIndex(
            name: "IX_ParentPlatformGame_GameId",
            table: "ParentPlatformGame",
            column: "GameId");

        migrationBuilder.CreateIndex(
            name: "IX_ParentPlatformGame_PlatformChildGameId",
            table: "ParentPlatformGame",
            column: "PlatformChildGameId");

        migrationBuilder.CreateIndex(
            name: "IX_Photos_AppUserId",
            table: "Photos",
            column: "AppUserId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_PlatformsGame_GameId",
            table: "PlatformsGame",
            column: "GameId");

        migrationBuilder.CreateIndex(
            name: "IX_PlatformsGame_PlatformGameId",
            table: "PlatformsGame",
            column: "PlatformGameId");

        migrationBuilder.CreateIndex(
            name: "IX_PlatformsGame_RequirementsGameId",
            table: "PlatformsGame",
            column: "RequirementsGameId");

        migrationBuilder.CreateIndex(
            name: "IX_Producer_DatumId",
            table: "Producer",
            column: "DatumId");

        migrationBuilder.CreateIndex(
            name: "IX_Prop_FromId",
            table: "Prop",
            column: "FromId");

        migrationBuilder.CreateIndex(
            name: "IX_Prop_ToId",
            table: "Prop",
            column: "ToId");

        migrationBuilder.CreateIndex(
            name: "IX_PropManga_FromId",
            table: "PropManga",
            column: "FromId");

        migrationBuilder.CreateIndex(
            name: "IX_PropManga_ToId",
            table: "PropManga",
            column: "ToId");

        migrationBuilder.CreateIndex(
            name: "IX_PublishedManga_PropId",
            table: "PublishedManga",
            column: "PropId");

        migrationBuilder.CreateIndex(
            name: "IX_PublisherGame_GameId",
            table: "PublisherGame",
            column: "GameId");

        migrationBuilder.CreateIndex(
            name: "IX_RatingGame_GameId",
            table: "RatingGame",
            column: "GameId");

        migrationBuilder.CreateIndex(
            name: "IX_SerializationManga_DatumMangaId",
            table: "SerializationManga",
            column: "DatumMangaId");

        migrationBuilder.CreateIndex(
            name: "IX_Similar_MovieId",
            table: "Similar",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_StarList_MovieId",
            table: "StarList",
            column: "MovieId");

        migrationBuilder.CreateIndex(
            name: "IX_StoresGame_GameId",
            table: "StoresGame",
            column: "GameId");

        migrationBuilder.CreateIndex(
            name: "IX_StoresGame_StoreGameId",
            table: "StoresGame",
            column: "StoreGameId");

        migrationBuilder.CreateIndex(
            name: "IX_Studio_DatumId",
            table: "Studio",
            column: "DatumId");

        migrationBuilder.CreateIndex(
            name: "IX_TagGame_GameId",
            table: "TagGame",
            column: "GameId");

        migrationBuilder.CreateIndex(
            name: "IX_Theme_DatumId",
            table: "Theme",
            column: "DatumId");

        migrationBuilder.CreateIndex(
            name: "IX_ThemeManga_DatumMangaId",
            table: "ThemeManga",
            column: "DatumMangaId");

        migrationBuilder.CreateIndex(
            name: "IX_Trailer_ImagesId",
            table: "Trailer",
            column: "ImagesId");

        migrationBuilder.CreateIndex(
            name: "IX_TrueTvShow_BoxOfficeTvShowBoxOfficeId",
            table: "TrueTvShow",
            column: "BoxOfficeTvShowBoxOfficeId");

        migrationBuilder.CreateIndex(
            name: "IX_TrueTvShow_ImagesTvShowImagesId",
            table: "TrueTvShow",
            column: "ImagesTvShowImagesId");

        migrationBuilder.CreateIndex(
            name: "IX_TrueTvShow_RatingsTvShowRatingsId",
            table: "TrueTvShow",
            column: "RatingsTvShowRatingsId");

        migrationBuilder.CreateIndex(
            name: "IX_TrueTvShow_TrailerTvShowTrailerId",
            table: "TrueTvShow",
            column: "TrailerTvShowTrailerId");

        migrationBuilder.CreateIndex(
            name: "IX_TrueTvShow_TvSeriesInfoTvShowInfoId",
            table: "TrueTvShow",
            column: "TvSeriesInfoTvShowInfoId");

        migrationBuilder.CreateIndex(
            name: "IX_TrueTvShow_WikipediaTvShowWikipediaId",
            table: "TrueTvShow",
            column: "WikipediaTvShowWikipediaId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowActorList_TvShowId",
            table: "TvShowActorList",
            column: "TvShowId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowCompanyList_TvShowId",
            table: "TvShowCompanyList",
            column: "TvShowId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowCountryList_TvShowId",
            table: "TvShowCountryList",
            column: "TvShowId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowCreatorList_TvSeriesInfoTvShowInfoId",
            table: "TvShowCreatorList",
            column: "TvSeriesInfoTvShowInfoId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowGenreList_TvShowId",
            table: "TvShowGenreList",
            column: "TvShowId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowItems_TvShowImagesId",
            table: "TvShowItems",
            column: "TvShowImagesId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowLanguageList_TvShowId",
            table: "TvShowLanguageList",
            column: "TvShowId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowSimilar_TvShowId",
            table: "TvShowSimilar",
            column: "TvShowId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowStarList_TvShowId",
            table: "TvShowStarList",
            column: "TvShowId");
>>>>>>> c649f03 (Migrated to .NET 8):Proiect_licenta/Migrations/20240108120615_InitialMigration.cs

        migrationBuilder.CreateIndex(
            name: "IX_TvShowWikipedia_PlotFullTvShowPlotFullId",
            table: "TvShowWikipedia",
            column: "PlotFullTvShowPlotFullId");

        migrationBuilder.CreateIndex(
            name: "IX_TvShowWikipedia_PlotShortTvShowPlotShortId",
            table: "TvShowWikipedia",
            column: "PlotShortTvShowPlotShortId");

        migrationBuilder.CreateIndex(
            name: "IX_Wikipedia_PlotFullId",
            table: "Wikipedia",
            column: "PlotFullId");

        migrationBuilder.CreateIndex(
            name: "IX_Wikipedia_PlotShortId",
            table: "Wikipedia",
            column: "PlotShortId");

        migrationBuilder.CreateIndex(
            name: "IX_WriterList_MovieId",
            table: "WriterList",
            column: "MovieId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ActorList");

<<<<<<< HEAD:Proiect_licenta/Migrations/20220513070929_InitialMigration.cs
            migrationBuilder.DropTable(
                name: "AppUserAnimeItems");

            migrationBuilder.DropTable(
                name: "AppUserGameItems");

            migrationBuilder.DropTable(
                name: "AppUserMangaItems");

            migrationBuilder.DropTable(
                name: "AppUserMovieItems");
=======
        migrationBuilder.DropTable(
            name: "AppUserMovieItems");
>>>>>>> c649f03 (Migrated to .NET 8):Proiect_licenta/Migrations/20240108120615_InitialMigration.cs

        migrationBuilder.DropTable(
            name: "AppUserTvShowItems");

        migrationBuilder.DropTable(
            name: "AspNetRoleClaims");

        migrationBuilder.DropTable(
            name: "AspNetUserClaims");

        migrationBuilder.DropTable(
            name: "AspNetUserLogins");

        migrationBuilder.DropTable(
            name: "AspNetUserRoles");

        migrationBuilder.DropTable(
            name: "AspNetUserTokens");

        migrationBuilder.DropTable(
            name: "AuthorManga");

        migrationBuilder.DropTable(
            name: "CompanyList");

        migrationBuilder.DropTable(
            name: "Connections");

        migrationBuilder.DropTable(
            name: "CountryList");

        migrationBuilder.DropTable(
            name: "Demographic");

        migrationBuilder.DropTable(
            name: "DemographicManga");

        migrationBuilder.DropTable(
            name: "DeveloperGame");

        migrationBuilder.DropTable(
            name: "DirectorList");

        migrationBuilder.DropTable(
            name: "Friends");

        migrationBuilder.DropTable(
            name: "GamesIds");

        migrationBuilder.DropTable(
            name: "Genre");

        migrationBuilder.DropTable(
            name: "GenreGame");

        migrationBuilder.DropTable(
            name: "GenreList");

        migrationBuilder.DropTable(
            name: "GenreManga");

        migrationBuilder.DropTable(
            name: "Item");

        migrationBuilder.DropTable(
            name: "LanguageList");

        migrationBuilder.DropTable(
            name: "Licensor");

        migrationBuilder.DropTable(
            name: "Messages");

        migrationBuilder.DropTable(
            name: "ParentPlatformGame");

        migrationBuilder.DropTable(
            name: "Photos");

        migrationBuilder.DropTable(
            name: "PlatformsGame");

        migrationBuilder.DropTable(
            name: "Producer");

        migrationBuilder.DropTable(
            name: "PublisherGame");

        migrationBuilder.DropTable(
            name: "RatingGame");

        migrationBuilder.DropTable(
            name: "SerializationManga");

        migrationBuilder.DropTable(
            name: "Similar");

        migrationBuilder.DropTable(
            name: "StarList");

        migrationBuilder.DropTable(
            name: "StoresGame");

        migrationBuilder.DropTable(
            name: "Studio");

        migrationBuilder.DropTable(
            name: "TagGame");

        migrationBuilder.DropTable(
            name: "Theme");

        migrationBuilder.DropTable(
            name: "ThemeManga");

        migrationBuilder.DropTable(
            name: "TvShowActorList");

        migrationBuilder.DropTable(
            name: "TvShowCompanyList");

        migrationBuilder.DropTable(
            name: "TvShowCountryList");

        migrationBuilder.DropTable(
            name: "TvShowCreatorList");

        migrationBuilder.DropTable(
            name: "TvShowGenreList");

        migrationBuilder.DropTable(
            name: "TvShowItems");

        migrationBuilder.DropTable(
            name: "TvShowLanguageList");

        migrationBuilder.DropTable(
            name: "TvShowSimilar");

        migrationBuilder.DropTable(
            name: "TvShowStarList");

        migrationBuilder.DropTable(
            name: "WriterList");

        migrationBuilder.DropTable(
            name: "Top250Movies");

        migrationBuilder.DropTable(
            name: "TvShows");

        migrationBuilder.DropTable(
            name: "AspNetRoles");

        migrationBuilder.DropTable(
            name: "Groups");

        migrationBuilder.DropTable(
            name: "PlatformChildGame");

        migrationBuilder.DropTable(
            name: "AspNetUsers");

        migrationBuilder.DropTable(
            name: "PlatformGame");

        migrationBuilder.DropTable(
            name: "RequirementsGame");

        migrationBuilder.DropTable(
            name: "StoreGame");

        migrationBuilder.DropTable(
            name: "Games");

        migrationBuilder.DropTable(
            name: "Anime");

        migrationBuilder.DropTable(
            name: "Manga");

        migrationBuilder.DropTable(
            name: "TrueTvShow");

        migrationBuilder.DropTable(
            name: "Movies");

        migrationBuilder.DropTable(
            name: "AddedByStatusGame");

        migrationBuilder.DropTable(
            name: "EsrbRatingGame");

        migrationBuilder.DropTable(
            name: "Aired");

        migrationBuilder.DropTable(
            name: "Broadcast");

        migrationBuilder.DropTable(
            name: "Trailer");

        migrationBuilder.DropTable(
            name: "ImagesManga");

        migrationBuilder.DropTable(
            name: "PublishedManga");

        migrationBuilder.DropTable(
            name: "TvSeriesInfo");

        migrationBuilder.DropTable(
            name: "TvShowBoxOffice");

        migrationBuilder.DropTable(
            name: "TvShowImages");

        migrationBuilder.DropTable(
            name: "TvShowRatings");

        migrationBuilder.DropTable(
            name: "TvShowTrailer");

        migrationBuilder.DropTable(
            name: "TvShowWikipedia");

        migrationBuilder.DropTable(
            name: "BoxOffice");

        migrationBuilder.DropTable(
            name: "MoviesImages");

        migrationBuilder.DropTable(
            name: "MoviesTrailer");

        migrationBuilder.DropTable(
            name: "Ratings");

        migrationBuilder.DropTable(
            name: "Wikipedia");

        migrationBuilder.DropTable(
            name: "Prop");

        migrationBuilder.DropTable(
            name: "Images");

        migrationBuilder.DropTable(
            name: "JpgManga");

        migrationBuilder.DropTable(
            name: "WebpManga");

        migrationBuilder.DropTable(
            name: "PropManga");

        migrationBuilder.DropTable(
            name: "TvShowPlotFull");

        migrationBuilder.DropTable(
            name: "TvShowPlotShort");

        migrationBuilder.DropTable(
            name: "PlotFull");

        migrationBuilder.DropTable(
            name: "PlotShort");

        migrationBuilder.DropTable(
            name: "From");

        migrationBuilder.DropTable(
            name: "To");

        migrationBuilder.DropTable(
            name: "Jpg");

        migrationBuilder.DropTable(
            name: "Webp");

        migrationBuilder.DropTable(
            name: "FromManga");

        migrationBuilder.DropTable(
            name: "ToManga");
    }
}
