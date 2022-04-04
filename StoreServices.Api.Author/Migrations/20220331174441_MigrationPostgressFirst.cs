using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StoreServices.Api.Author.Migrations
{
    /// <inheritdoc />
    public partial class MigrationPostgressFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BookAuthorGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Institute = table.Column<string>(type: "text", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BookAuthorId = table.Column<int>(type: "integer", nullable: false),
                    AcademyLevelGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademyLevels_BookAuthors_BookAuthorId",
                        column: x => x.BookAuthorId,
                        principalTable: "BookAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademyLevels_BookAuthorId",
                table: "AcademyLevels",
                column: "BookAuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademyLevels");

            migrationBuilder.DropTable(
                name: "BookAuthors");
        }
    }
}
