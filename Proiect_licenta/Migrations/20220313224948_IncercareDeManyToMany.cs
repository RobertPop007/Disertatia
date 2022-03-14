using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class IncercareDeManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Top250Movies_AspNetUsers_AppUserId",
                table: "Top250Movies");

            migrationBuilder.DropIndex(
                name: "IX_Top250Movies_AppUserId",
                table: "Top250Movies");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Top250Movies");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Top250Movies",
                newName: "MovieItemId");

            migrationBuilder.CreateTable(
                name: "AppUserMovieItems",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    MovieItemId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserMovieItems", x => new { x.AppUserId, x.MovieItemId });
                    table.ForeignKey(
                        name: "FK_AppUserMovieItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserMovieItems_Top250Movies_MovieItemId",
                        column: x => x.MovieItemId,
                        principalTable: "Top250Movies",
                        principalColumn: "MovieItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMovieItems_MovieItemId",
                table: "AppUserMovieItems",
                column: "MovieItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserMovieItems");

            migrationBuilder.RenameColumn(
                name: "MovieItemId",
                table: "Top250Movies",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Top250Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Top250Movies_AppUserId",
                table: "Top250Movies",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Top250Movies_AspNetUsers_AppUserId",
                table: "Top250Movies",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
