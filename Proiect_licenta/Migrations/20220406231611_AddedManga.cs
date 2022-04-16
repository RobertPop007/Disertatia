using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class AddedManga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FromManga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FromManga", x => x.Id);
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
                name: "PublishedManga",
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
                    table.PrimaryKey("PK_PublishedManga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublishedManga_PropManga_PropId",
                        column: x => x.PropId,
                        principalTable: "PropManga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mangs",
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
                    table.PrimaryKey("PK_Mangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mangs_ImagesManga_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "ImagesManga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mangs_PublishedManga_PublishedId",
                        column: x => x.PublishedId,
                        principalTable: "PublishedManga",
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
                        name: "FK_AuthorManga_Mangs_DatumMangaId",
                        column: x => x.DatumMangaId,
                        principalTable: "Mangs",
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
                        name: "FK_DemographicManga_Mangs_DatumMangaId",
                        column: x => x.DatumMangaId,
                        principalTable: "Mangs",
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
                        name: "FK_GenreManga_Mangs_DatumMangaId",
                        column: x => x.DatumMangaId,
                        principalTable: "Mangs",
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
                        name: "FK_SerializationManga_Mangs_DatumMangaId",
                        column: x => x.DatumMangaId,
                        principalTable: "Mangs",
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
                        name: "FK_ThemeManga_Mangs_DatumMangaId",
                        column: x => x.DatumMangaId,
                        principalTable: "Mangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorManga_DatumMangaId",
                table: "AuthorManga",
                column: "DatumMangaId");

            migrationBuilder.CreateIndex(
                name: "IX_DemographicManga_DatumMangaId",
                table: "DemographicManga",
                column: "DatumMangaId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreManga_DatumMangaId",
                table: "GenreManga",
                column: "DatumMangaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesManga_JpgId",
                table: "ImagesManga",
                column: "JpgId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesManga_WebpId",
                table: "ImagesManga",
                column: "WebpId");

            migrationBuilder.CreateIndex(
                name: "IX_Mangs_ImagesId",
                table: "Mangs",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Mangs_PublishedId",
                table: "Mangs",
                column: "PublishedId");

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
                name: "IX_SerializationManga_DatumMangaId",
                table: "SerializationManga",
                column: "DatumMangaId");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeManga_DatumMangaId",
                table: "ThemeManga",
                column: "DatumMangaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorManga");

            migrationBuilder.DropTable(
                name: "DemographicManga");

            migrationBuilder.DropTable(
                name: "GenreManga");

            migrationBuilder.DropTable(
                name: "SerializationManga");

            migrationBuilder.DropTable(
                name: "ThemeManga");

            migrationBuilder.DropTable(
                name: "Mangs");

            migrationBuilder.DropTable(
                name: "ImagesManga");

            migrationBuilder.DropTable(
                name: "PublishedManga");

            migrationBuilder.DropTable(
                name: "JpgManga");

            migrationBuilder.DropTable(
                name: "WebpManga");

            migrationBuilder.DropTable(
                name: "PropManga");

            migrationBuilder.DropTable(
                name: "FromManga");

            migrationBuilder.DropTable(
                name: "ToManga");
        }
    }
}
