using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class AddedFullTitleToSimilarsForSimilars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullTitle",
                table: "Similar",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullTitle",
                table: "Similar");
        }
    }
}
