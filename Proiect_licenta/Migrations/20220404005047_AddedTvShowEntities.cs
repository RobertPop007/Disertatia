using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class AddedTvShowEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Top250Movies");

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
                name: "AppUserTvShowItem",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId1 = table.Column<int>(type: "int", nullable: false),
                    TvShowItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTvShowItem", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_AppUserTvShowItem_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTvShowItem_TvShows_TvShowItemId",
                        column: x => x.TvShowItemId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTvShowItem_AppUserId1",
                table: "AppUserTvShowItem",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTvShowItem_TvShowItemId",
                table: "AppUserTvShowItem",
                column: "TvShowItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserTvShowItem");

            migrationBuilder.DropTable(
                name: "TvShows");

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "Top250Movies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
