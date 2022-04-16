using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class UpdateManga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorManga_Mangs_DatumMangaId",
                table: "AuthorManga");

            migrationBuilder.DropForeignKey(
                name: "FK_DemographicManga_Mangs_DatumMangaId",
                table: "DemographicManga");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreManga_Mangs_DatumMangaId",
                table: "GenreManga");

            migrationBuilder.DropForeignKey(
                name: "FK_Mangs_ImagesManga_ImagesId",
                table: "Mangs");

            migrationBuilder.DropForeignKey(
                name: "FK_Mangs_PublishedManga_PublishedId",
                table: "Mangs");

            migrationBuilder.DropForeignKey(
                name: "FK_SerializationManga_Mangs_DatumMangaId",
                table: "SerializationManga");

            migrationBuilder.DropForeignKey(
                name: "FK_ThemeManga_Mangs_DatumMangaId",
                table: "ThemeManga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mangs",
                table: "Mangs");

            migrationBuilder.RenameTable(
                name: "Mangs",
                newName: "Manga");

            migrationBuilder.RenameIndex(
                name: "IX_Mangs_PublishedId",
                table: "Manga",
                newName: "IX_Manga_PublishedId");

            migrationBuilder.RenameIndex(
                name: "IX_Mangs_ImagesId",
                table: "Manga",
                newName: "IX_Manga_ImagesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manga",
                table: "Manga",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorManga_Manga_DatumMangaId",
                table: "AuthorManga",
                column: "DatumMangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DemographicManga_Manga_DatumMangaId",
                table: "DemographicManga",
                column: "DatumMangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreManga_Manga_DatumMangaId",
                table: "GenreManga",
                column: "DatumMangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_ImagesManga_ImagesId",
                table: "Manga",
                column: "ImagesId",
                principalTable: "ImagesManga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_PublishedManga_PublishedId",
                table: "Manga",
                column: "PublishedId",
                principalTable: "PublishedManga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SerializationManga_Manga_DatumMangaId",
                table: "SerializationManga",
                column: "DatumMangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThemeManga_Manga_DatumMangaId",
                table: "ThemeManga",
                column: "DatumMangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorManga_Manga_DatumMangaId",
                table: "AuthorManga");

            migrationBuilder.DropForeignKey(
                name: "FK_DemographicManga_Manga_DatumMangaId",
                table: "DemographicManga");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreManga_Manga_DatumMangaId",
                table: "GenreManga");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_ImagesManga_ImagesId",
                table: "Manga");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_PublishedManga_PublishedId",
                table: "Manga");

            migrationBuilder.DropForeignKey(
                name: "FK_SerializationManga_Manga_DatumMangaId",
                table: "SerializationManga");

            migrationBuilder.DropForeignKey(
                name: "FK_ThemeManga_Manga_DatumMangaId",
                table: "ThemeManga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manga",
                table: "Manga");

            migrationBuilder.RenameTable(
                name: "Manga",
                newName: "Mangs");

            migrationBuilder.RenameIndex(
                name: "IX_Manga_PublishedId",
                table: "Mangs",
                newName: "IX_Mangs_PublishedId");

            migrationBuilder.RenameIndex(
                name: "IX_Manga_ImagesId",
                table: "Mangs",
                newName: "IX_Mangs_ImagesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mangs",
                table: "Mangs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorManga_Mangs_DatumMangaId",
                table: "AuthorManga",
                column: "DatumMangaId",
                principalTable: "Mangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DemographicManga_Mangs_DatumMangaId",
                table: "DemographicManga",
                column: "DatumMangaId",
                principalTable: "Mangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreManga_Mangs_DatumMangaId",
                table: "GenreManga",
                column: "DatumMangaId",
                principalTable: "Mangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mangs_ImagesManga_ImagesId",
                table: "Mangs",
                column: "ImagesId",
                principalTable: "ImagesManga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mangs_PublishedManga_PublishedId",
                table: "Mangs",
                column: "PublishedId",
                principalTable: "PublishedManga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SerializationManga_Mangs_DatumMangaId",
                table: "SerializationManga",
                column: "DatumMangaId",
                principalTable: "Mangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThemeManga_Mangs_DatumMangaId",
                table: "ThemeManga",
                column: "DatumMangaId",
                principalTable: "Mangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
