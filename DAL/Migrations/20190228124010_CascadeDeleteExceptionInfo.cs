using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CascadeDeleteExceptionInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exceptions_Loggers_LoggerId",
                table: "Exceptions");

            migrationBuilder.AddColumn<long>(
                name: "InnerExceptionId",
                table: "Exceptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_InnerExceptionId",
                table: "Exceptions",
                column: "InnerExceptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exceptions_Exceptions_InnerExceptionId",
                table: "Exceptions",
                column: "InnerExceptionId",
                principalTable: "Exceptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exceptions_Loggers_LoggerId",
                table: "Exceptions",
                column: "LoggerId",
                principalTable: "Loggers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exceptions_Exceptions_InnerExceptionId",
                table: "Exceptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Exceptions_Loggers_LoggerId",
                table: "Exceptions");

            migrationBuilder.DropIndex(
                name: "IX_Exceptions_InnerExceptionId",
                table: "Exceptions");

            migrationBuilder.DropColumn(
                name: "InnerExceptionId",
                table: "Exceptions");

            migrationBuilder.AddForeignKey(
                name: "FK_Exceptions_Loggers_LoggerId",
                table: "Exceptions",
                column: "LoggerId",
                principalTable: "Loggers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
