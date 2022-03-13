using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class AddedMovieListToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
