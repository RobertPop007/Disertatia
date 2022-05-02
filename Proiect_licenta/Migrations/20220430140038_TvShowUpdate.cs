using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class TvShowUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvShows_TvShowImages_TvShowImagesId",
                table: "TvShows");

            migrationBuilder.DropIndex(
                name: "IX_TvShows_TvShowImagesId",
                table: "TvShows");

            migrationBuilder.DropColumn(
                name: "TvShowImagesId",
                table: "TvShows");

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

            migrationBuilder.CreateIndex(
                name: "IX_TvShowItems_TvShowImagesId",
                table: "TvShowItems",
                column: "TvShowImagesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TvShowItems");

            migrationBuilder.AddColumn<Guid>(
                name: "TvShowImagesId",
                table: "TvShows",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_TvShowImagesId",
                table: "TvShows",
                column: "TvShowImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TvShows_TvShowImages_TvShowImagesId",
                table: "TvShows",
                column: "TvShowImagesId",
                principalTable: "TvShowImages",
                principalColumn: "TvShowImagesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
