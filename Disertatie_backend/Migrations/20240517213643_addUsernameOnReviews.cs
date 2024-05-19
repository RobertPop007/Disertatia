using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disertatie_backend.Migrations
{
    /// <inheritdoc />
    public partial class addUsernameOnReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Reviews");
        }
    }
}
