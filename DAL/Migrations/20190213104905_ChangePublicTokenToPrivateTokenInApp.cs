using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangePublicTokenToPrivateTokenInApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicToken",
                table: "Apps",
                newName: "PrivateToken");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrivateToken",
                table: "Apps",
                newName: "PublicToken");
        }
    }
}
