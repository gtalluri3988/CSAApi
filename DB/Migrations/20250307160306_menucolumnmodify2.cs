using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class menucolumnmodify2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
        name: "SubMenuiId",
        table: "RoleMenuPermission",
        newName: "SubMenuId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
        name: "SubMenuId",
        table: "RoleMenuPermission",
        newName: "SubMenuiId");
        }
    }
}
