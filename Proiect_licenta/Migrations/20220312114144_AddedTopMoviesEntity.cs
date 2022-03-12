using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class AddedTopMoviesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Top250Movies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Top250Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Top250Movies");
        }
    }
}
