using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsProject.Migrations
{
    /// <inheritdoc />
    public partial class adjustement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_authors_authorsId",
                table: "news");

            migrationBuilder.DropIndex(
                name: "IX_news_authorsId",
                table: "news");

            migrationBuilder.DropColumn(
                name: "authorsId",
                table: "news");

            migrationBuilder.RenameColumn(
                name: "AuthId",
                table: "news",
                newName: "AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Publication",
                table: "news",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_news_AuthorId",
                table: "news",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_news_authors_AuthorId",
                table: "news",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_authors_AuthorId",
                table: "news");

            migrationBuilder.DropIndex(
                name: "IX_news_AuthorId",
                table: "news");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "news",
                newName: "AuthId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Publication",
                table: "news",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "authorsId",
                table: "news",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_news_authorsId",
                table: "news",
                column: "authorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_news_authors_authorsId",
                table: "news",
                column: "authorsId",
                principalTable: "authors",
                principalColumn: "Id");
        }
    }
}
