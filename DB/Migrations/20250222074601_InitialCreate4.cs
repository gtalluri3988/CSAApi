using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_RoleId",
                table: "Menu",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Roles_RoleId",
                table: "Menu",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Roles_RoleId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_RoleId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Menu");
        }
    }
}
