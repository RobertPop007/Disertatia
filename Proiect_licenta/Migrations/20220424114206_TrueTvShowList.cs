using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class TrueTvShowList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TvShowImagesId",
                table: "TvShows",
                type: "uniqueidentifier",
                nullable: true);

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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_TvShowImagesId",
                table: "TvShows",
                column: "TvShowImagesId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TvShowWikipedia_PlotFullTvShowPlotFullId",
                table: "TvShowWikipedia",
                column: "PlotFullTvShowPlotFullId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowWikipedia_PlotShortTvShowPlotShortId",
                table: "TvShowWikipedia",
                column: "PlotShortTvShowPlotShortId");

            migrationBuilder.AddForeignKey(
                name: "FK_TvShows_TvShowImages_TvShowImagesId",
                table: "TvShows",
                column: "TvShowImagesId",
                principalTable: "TvShowImages",
                principalColumn: "TvShowImagesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvShows_TvShowImages_TvShowImagesId",
                table: "TvShows");

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
                name: "TvShowLanguageList");

            migrationBuilder.DropTable(
                name: "TvShowSimilar");

            migrationBuilder.DropTable(
                name: "TvShowStarList");

            migrationBuilder.DropTable(
                name: "TrueTvShow");

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
                name: "TvShowPlotFull");

            migrationBuilder.DropTable(
                name: "TvShowPlotShort");

            migrationBuilder.DropIndex(
                name: "IX_TvShows_TvShowImagesId",
                table: "TvShows");

            migrationBuilder.DropColumn(
                name: "TvShowImagesId",
                table: "TvShows");
        }
    }
}
