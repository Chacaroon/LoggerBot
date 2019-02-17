using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RenameAppsToLoggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exceptions_Apps_AppId",
                table: "Exceptions");

            migrationBuilder.DropTable(
                name: "UserApp");

            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "Exceptions",
                newName: "LoggerId");

            migrationBuilder.RenameIndex(
                name: "IX_Exceptions_AppId",
                table: "Exceptions",
                newName: "IX_Exceptions_LoggerId");

            migrationBuilder.CreateTable(
                name: "Loggers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PrivateToken = table.Column<Guid>(nullable: false),
                    SubscribeToken = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loggers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogger",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoggerId = table.Column<long>(nullable: false),
                    IsSubscriber = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogger", x => new { x.UserId, x.LoggerId });
                    table.ForeignKey(
                        name: "FK_UserLogger_Loggers_LoggerId",
                        column: x => x.LoggerId,
                        principalTable: "Loggers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLogger_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogger_LoggerId",
                table: "UserLogger",
                column: "LoggerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exceptions_Loggers_LoggerId",
                table: "Exceptions",
                column: "LoggerId",
                principalTable: "Loggers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exceptions_Loggers_LoggerId",
                table: "Exceptions");

            migrationBuilder.DropTable(
                name: "UserLogger");

            migrationBuilder.DropTable(
                name: "Loggers");

            migrationBuilder.RenameColumn(
                name: "LoggerId",
                table: "Exceptions",
                newName: "AppId");

            migrationBuilder.RenameIndex(
                name: "IX_Exceptions_LoggerId",
                table: "Exceptions",
                newName: "IX_Exceptions_AppId");

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PrivateToken = table.Column<Guid>(nullable: false),
                    SubscribeToken = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserApp",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    AppId = table.Column<long>(nullable: false),
                    IsSubscriber = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApp", x => new { x.UserId, x.AppId });
                    table.ForeignKey(
                        name: "FK_UserApp_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserApp_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserApp_AppId",
                table: "UserApp",
                column: "AppId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exceptions_Apps_AppId",
                table: "Exceptions",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
