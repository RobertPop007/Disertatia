using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class RemoveTvShowsForNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserTvShowItems",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    TvShowItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TvShowId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTvShowItems", x => new { x.AppUserId, x.TvShowItemId });
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserTvShowItems_TvShows_TvShowItemId",
                        column: x => x.TvShowItemId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTvShowItems_TvShowId",
                table: "AppUserTvShowItems",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTvShowItems_TvShowItemId",
                table: "AppUserTvShowItems",
                column: "TvShowItemId");
        }
    }
}
