using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ConfigureRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatStates_Users_UserId",
                table: "ChatStates");

            migrationBuilder.DropIndex(
                name: "IX_Users_ChatId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ChatStates_UserId",
                table: "ChatStates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChatStates");

            migrationBuilder.AddColumn<long>(
                name: "ChatStateId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChatStateId",
                table: "Users",
                column: "ChatStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ChatStates_ChatStateId",
                table: "Users",
                column: "ChatStateId",
                principalTable: "ChatStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ChatStates_ChatStateId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ChatStateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChatStateId",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ChatStates",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChatId",
                table: "Users",
                column: "ChatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatStates_UserId",
                table: "ChatStates",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatStates_Users_UserId",
                table: "ChatStates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
