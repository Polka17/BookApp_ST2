using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollyBookApp_ST2.Migrations
{
    public partial class LinkUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ReadingItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReadingItems_UserId",
                table: "ReadingItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingItems_Users_UserId",
                table: "ReadingItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingItems_Users_UserId",
                table: "ReadingItems");

            migrationBuilder.DropIndex(
                name: "IX_ReadingItems_UserId",
                table: "ReadingItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReadingItems");
        }
    }
}
