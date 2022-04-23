using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_licenta.Migrations
{
    public partial class RefactorUserMovieConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorList_Movies_MovieId",
                table: "ActorList");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMovieItems_Top250Movies_MovieItemId",
                table: "AppUserMovieItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyList_Movies_MovieId",
                table: "CompanyList");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryList_Movies_MovieId",
                table: "CountryList");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectorList_Movies_MovieId",
                table: "DirectorList");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreList_Movies_MovieId",
                table: "GenreList");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageList_Movies_MovieId",
                table: "LanguageList");

            migrationBuilder.DropForeignKey(
                name: "FK_Similar_Movies_MovieId",
                table: "Similar");

            migrationBuilder.DropForeignKey(
                name: "FK_StarList_Movies_MovieId",
                table: "StarList");

            migrationBuilder.DropForeignKey(
                name: "FK_WriterList_Movies_MovieId",
                table: "WriterList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserMovieItems",
                table: "AppUserMovieItems");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "WriterList",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "StarList",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "Similar",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Movies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "LanguageList",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "GenreList",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "DirectorList",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "CountryList",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "CompanyList",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieItemId",
                table: "AppUserMovieItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "AppUserMovieItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "ActorList",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserMovieItems",
                table: "AppUserMovieItems",
                columns: new[] { "AppUserId", "MovieId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMovieItems_MovieId",
                table: "AppUserMovieItems",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorList_Movies_MovieId",
                table: "ActorList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMovieItems_Movies_MovieId",
                table: "AppUserMovieItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMovieItems_Top250Movies_MovieItemId",
                table: "AppUserMovieItems",
                column: "MovieItemId",
                principalTable: "Top250Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyList_Movies_MovieId",
                table: "CompanyList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryList_Movies_MovieId",
                table: "CountryList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorList_Movies_MovieId",
                table: "DirectorList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreList_Movies_MovieId",
                table: "GenreList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageList_Movies_MovieId",
                table: "LanguageList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Similar_Movies_MovieId",
                table: "Similar",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StarList_Movies_MovieId",
                table: "StarList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WriterList_Movies_MovieId",
                table: "WriterList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorList_Movies_MovieId",
                table: "ActorList");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMovieItems_Movies_MovieId",
                table: "AppUserMovieItems");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMovieItems_Top250Movies_MovieItemId",
                table: "AppUserMovieItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyList_Movies_MovieId",
                table: "CompanyList");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryList_Movies_MovieId",
                table: "CountryList");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectorList_Movies_MovieId",
                table: "DirectorList");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreList_Movies_MovieId",
                table: "GenreList");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageList_Movies_MovieId",
                table: "LanguageList");

            migrationBuilder.DropForeignKey(
                name: "FK_Similar_Movies_MovieId",
                table: "Similar");

            migrationBuilder.DropForeignKey(
                name: "FK_StarList_Movies_MovieId",
                table: "StarList");

            migrationBuilder.DropForeignKey(
                name: "FK_WriterList_Movies_MovieId",
                table: "WriterList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserMovieItems",
                table: "AppUserMovieItems");

            migrationBuilder.DropIndex(
                name: "IX_AppUserMovieItems_MovieId",
                table: "AppUserMovieItems");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "AppUserMovieItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "WriterList",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "StarList",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "Similar",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "LanguageList",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "GenreList",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "DirectorList",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "CountryList",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "CompanyList",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieItemId",
                table: "AppUserMovieItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "ActorList",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserMovieItems",
                table: "AppUserMovieItems",
                columns: new[] { "AppUserId", "MovieItemId" });

            migrationBuilder.CreateTable(
                name: "KeywordListString",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Keyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordListString", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeywordListString_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordListString_MovieId",
                table: "KeywordListString",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorList_Movies_MovieId",
                table: "ActorList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMovieItems_Top250Movies_MovieItemId",
                table: "AppUserMovieItems",
                column: "MovieItemId",
                principalTable: "Top250Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyList_Movies_MovieId",
                table: "CompanyList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryList_Movies_MovieId",
                table: "CountryList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorList_Movies_MovieId",
                table: "DirectorList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreList_Movies_MovieId",
                table: "GenreList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageList_Movies_MovieId",
                table: "LanguageList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Similar_Movies_MovieId",
                table: "Similar",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StarList_Movies_MovieId",
                table: "StarList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WriterList_Movies_MovieId",
                table: "WriterList",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
