using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class AddedFullMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTvShowItem_TvShows_TvShowItemId",
                table: "AppUserTvShowItem");

            migrationBuilder.DropIndex(
                name: "IX_AppUserTvShowItem_TvShowItemId",
                table: "AppUserTvShowItem");

            migrationBuilder.AlterColumn<int>(
                name: "TvShowItemId",
                table: "AppUserTvShowItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TvShowItemId1",
                table: "AppUserTvShowItem",
                type: "nvarchar(450)",
                nullable: true);

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
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "ActorList",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AsCharacter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "CompanyList",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "KeywordListString",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Keyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordListString", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeywordListString_Movies_MovieId",
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
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTvShowItem_TvShowItemId1",
                table: "AppUserTvShowItem",
                column: "TvShowItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_ActorList_MovieId",
                table: "ActorList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyList_MovieId",
                table: "CompanyList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryList_MovieId",
                table: "CountryList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorList_MovieId",
                table: "DirectorList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreList_MovieId",
                table: "GenreList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_MoviesImagesId",
                table: "Item",
                column: "MoviesImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordListString_MovieId",
                table: "KeywordListString",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageList_MovieId",
                table: "LanguageList",
                column: "MovieId");

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
                name: "IX_Similar_MovieId",
                table: "Similar",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_StarList_MovieId",
                table: "StarList",
                column: "MovieId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTvShowItem_TvShows_TvShowItemId1",
                table: "AppUserTvShowItem",
                column: "TvShowItemId1",
                principalTable: "TvShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTvShowItem_TvShows_TvShowItemId1",
                table: "AppUserTvShowItem");

            migrationBuilder.DropTable(
                name: "ActorList");

            migrationBuilder.DropTable(
                name: "CompanyList");

            migrationBuilder.DropTable(
                name: "CountryList");

            migrationBuilder.DropTable(
                name: "DirectorList");

            migrationBuilder.DropTable(
                name: "GenreList");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "KeywordListString");

            migrationBuilder.DropTable(
                name: "LanguageList");

            migrationBuilder.DropTable(
                name: "Similar");

            migrationBuilder.DropTable(
                name: "StarList");

            migrationBuilder.DropTable(
                name: "WriterList");

            migrationBuilder.DropTable(
                name: "Movies");

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
                name: "PlotFull");

            migrationBuilder.DropTable(
                name: "PlotShort");

            migrationBuilder.DropIndex(
                name: "IX_AppUserTvShowItem_TvShowItemId1",
                table: "AppUserTvShowItem");

            migrationBuilder.DropColumn(
                name: "TvShowItemId1",
                table: "AppUserTvShowItem");

            migrationBuilder.AlterColumn<string>(
                name: "TvShowItemId",
                table: "AppUserTvShowItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTvShowItem_TvShowItemId",
                table: "AppUserTvShowItem",
                column: "TvShowItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTvShowItem_TvShows_TvShowItemId",
                table: "AppUserTvShowItem",
                column: "TvShowItemId",
                principalTable: "TvShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
