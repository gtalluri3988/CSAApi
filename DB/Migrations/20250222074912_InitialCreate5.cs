using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "RoleMenuPermission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "RoleMenuPermission",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuPermission_MenuId",
                table: "RoleMenuPermission",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuPermission_RoleId",
                table: "RoleMenuPermission",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenuPermission_Menu_MenuId",
                table: "RoleMenuPermission",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleMenuPermission_Roles_RoleId",
                table: "RoleMenuPermission",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenuPermission_Menu_MenuId",
                table: "RoleMenuPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleMenuPermission_Roles_RoleId",
                table: "RoleMenuPermission");

            migrationBuilder.DropIndex(
                name: "IX_RoleMenuPermission_MenuId",
                table: "RoleMenuPermission");

            migrationBuilder.DropIndex(
                name: "IX_RoleMenuPermission_RoleId",
                table: "RoleMenuPermission");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "RoleMenuPermission");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "RoleMenuPermission");
        }
    }
}
