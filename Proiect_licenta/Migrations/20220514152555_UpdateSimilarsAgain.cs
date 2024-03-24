using Microsoft.EntityFrameworkCore.Migrations;

namespace Disertatie_backend.Migrations
{
    public partial class UpdateSimilarsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Similar",
                newName: "FullTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullTitle",
                table: "Similar",
                newName: "Year");
        }
    }
}
