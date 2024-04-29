using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Authors_AuthorId1",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_AuthorId1",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "News");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId1",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorId1",
                table: "News",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Authors_AuthorId1",
                table: "News",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
