using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class residentrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Resident",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resident_RoleId",
                table: "Resident",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Roles_RoleId",
                table: "Resident",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Roles_RoleId",
                table: "Resident");

            migrationBuilder.DropIndex(
                name: "IX_Resident_RoleId",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Resident");
        }
    }
}
