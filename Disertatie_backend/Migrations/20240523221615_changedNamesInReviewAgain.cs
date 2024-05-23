using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disertatie_backend.Migrations
{
    /// <inheritdoc />
    public partial class changedNamesInReviewAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_photo",
                table: "Reviews",
                newName: "UserPhoto");

            migrationBuilder.RenameColumn(
                name: "Short_description",
                table: "Reviews",
                newName: "ShortDescription");

            migrationBuilder.RenameColumn(
                name: "Main_description",
                table: "Reviews",
                newName: "MainDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPhoto",
                table: "Reviews",
                newName: "User_photo");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Reviews",
                newName: "Short_description");

            migrationBuilder.RenameColumn(
                name: "MainDescription",
                table: "Reviews",
                newName: "Main_description");
        }
    }
}
