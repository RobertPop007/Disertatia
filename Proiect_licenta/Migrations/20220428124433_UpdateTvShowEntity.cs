using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class UpdateTvShowEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TvShowId",
                table: "AppUserTvShowItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTvShowItem_TvShowId",
                table: "AppUserTvShowItem",
                column: "TvShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTvShowItem_TrueTvShow_TvShowId",
                table: "AppUserTvShowItem",
                column: "TvShowId",
                principalTable: "TrueTvShow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTvShowItem_TrueTvShow_TvShowId",
                table: "AppUserTvShowItem");

            migrationBuilder.DropIndex(
                name: "IX_AppUserTvShowItem_TvShowId",
                table: "AppUserTvShowItem");

            migrationBuilder.DropColumn(
                name: "TvShowId",
                table: "AppUserTvShowItem");
        }
    }
}
