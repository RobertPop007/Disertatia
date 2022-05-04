using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class AddedFullGamesTables : Migration
    {
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
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_original = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metacritic = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperGame_GameId",
                table: "DeveloperGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Added_by_statusAddedByStatusGameId",
                table: "Games",
                column: "Added_by_statusAddedByStatusGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Esrb_ratingEsrbRatingGameId",
                table: "Games",
                column: "Esrb_ratingEsrbRatingGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreGame_GameId",
                table: "GenreGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentPlatformGame_GameId",
                table: "ParentPlatformGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentPlatformGame_PlatformChildGameId",
                table: "ParentPlatformGame",
                column: "PlatformChildGameId");

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
                name: "IX_PublisherGame_GameId",
                table: "PublisherGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingGame_GameId",
                table: "RatingGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_StoresGame_GameId",
                table: "StoresGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_StoresGame_StoreGameId",
                table: "StoresGame",
                column: "StoreGameId");

            migrationBuilder.CreateIndex(
                name: "IX_TagGame_GameId",
                table: "TagGame",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperGame");

            migrationBuilder.DropTable(
                name: "GenreGame");

            migrationBuilder.DropTable(
                name: "ParentPlatformGame");

            migrationBuilder.DropTable(
                name: "PlatformsGame");

            migrationBuilder.DropTable(
                name: "PublisherGame");

            migrationBuilder.DropTable(
                name: "RatingGame");

            migrationBuilder.DropTable(
                name: "StoresGame");

            migrationBuilder.DropTable(
                name: "TagGame");

            migrationBuilder.DropTable(
                name: "PlatformChildGame");

            migrationBuilder.DropTable(
                name: "PlatformGame");

            migrationBuilder.DropTable(
                name: "RequirementsGame");

            migrationBuilder.DropTable(
                name: "StoreGame");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "AddedByStatusGame");

            migrationBuilder.DropTable(
                name: "EsrbRatingGame");
        }
    }
}
