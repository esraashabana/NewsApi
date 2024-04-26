using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsProject.Migrations
{
    /// <inheritdoc />
    public partial class Add_AuthorsNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publication = table.Column<DateOnly>(type: "date", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    authorsId = table.Column<int>(type: "int", nullable: true),
                    AuthId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.Id);
                    table.ForeignKey(
                        name: "FK_news_authors_authorsId",
                        column: x => x.authorsId,
                        principalTable: "authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_news_authorsId",
                table: "news",
                column: "authorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
