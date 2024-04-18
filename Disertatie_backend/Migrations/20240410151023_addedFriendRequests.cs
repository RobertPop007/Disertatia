using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disertatie_backend.Migrations
{
    /// <inheritdoc />
    public partial class addedFriendRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Friends",
                table: "AspNetUsers",
                newName: "FriendRequests");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    UserID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SinceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.UserID1, x.UserID2 });
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_UserID1",
                        column: x => x.UserID1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_UserID2",
                        column: x => x.UserID2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserID2",
                table: "Friends",
                column: "UserID2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.RenameColumn(
                name: "FriendRequests",
                table: "AspNetUsers",
                newName: "Friends");
        }
    }
}
